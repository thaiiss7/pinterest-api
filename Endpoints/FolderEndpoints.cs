using Microsoft.AspNetCore.Mvc;
using Pinterest.UseCases.CreateFolder;
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
        app.MapGet("folder/{id}", async (
            Guid id,
            [FromServices] GetFolderDataUseCase useCase) =>
            {
                var payload = new GetFolderDataPayload(id);
                var result = await useCase.Do(payload);

                return (result.IsSuccess, result.Reason) switch
                {
                    (false, "Folder not found") => Results.NotFound(),
                    (false, _) => Results.BadRequest(),
                    (true, _) => Results.Ok(result.Data)
                };
            });

    }
}
