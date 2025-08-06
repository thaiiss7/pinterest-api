using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using Pinterest.Models;
using Pinterest.UseCases.CreateFolder;
using Pinterest.UseCases.DeleleFolder;
using Pinterest.UseCases.DeleteFolder;
using Pinterest.UseCases.GetFolderData;

namespace Pinterest.Endpoints;

public static class FolderEndpoints
{
    public static void ConfigureFolderEndpoints(this WebApplication app)
    {
        // MapPost para criar uma pasta
        app.MapPost("folder", async (
            [FromBody] CreateFolderPayload payload,
            [FromServices] CreateFolderUseCase useCase) =>
            {
                var result = await useCase.Do(payload);

                if (result.IsSuccess)
                    return Results.Created();

                return Results.BadRequest(result.Reason);

            });

        // MapGet para buscar a pasta por id
        // teria uma verificação em que se a pasta for privada, só pode ser acessada pelo próprio usuário
        // primeiro testar como está e depois conversar com o trevis pra não estregar o código
        app.MapGet("folder/{id}", async (
            Guid id,
            HttpContext http,
            [FromServices] GetFolderDataUseCase useCase) =>
            {
                var payload = new GetFolderDataPayload(id);
                var result = await useCase.Do(payload);

                if (!result.IsSuccess)
                {
                    return (result.IsSuccess, result.Reason) switch
                    {
                        (false, "Folder not found") => Results.NotFound(),
                        (false, _) => Results.BadRequest(),
                    };
                }

                var folder = result.Data;

                if (!folder.Secret)
                    return Results.Ok(folder);

                var userId = http.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                if (folder.Author.ID.ToString() != userId)
                    return Results.Forbid();

                return Results.Ok(folder);

            }).RequireAuthorization();

        // MapDelete para deletar uma pasta por id
        app.MapDelete("folder/{id}", async (string id, 
            HttpContext http,
            [FromServices]DeleteFolderUseCase useCase) =>
        {
            var claim = http.User.FindFirst(ClaimTypes.NameIdentifier);
            var userId = Guid.Parse(claim.Value);
            var folderId = Guid.Parse(id);
            var payload = new DeleteFolderPayload(folderId, userId);
            var result = await useCase.Do(payload);

            return (result.IsSuccess, result.Reason) switch
            {
                (false, "Folder not found") => Results.NotFound(),
                (false, _) => Results.BadRequest(),
                (true, _) => Results.Ok()
            };
        }).RequireAuthorization();

    }
}
