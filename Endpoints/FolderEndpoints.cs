using Microsoft.AspNetCore.Mvc;
using Pinterest.UseCases.CreateFolder;

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

                return (result.IsSuccess, result.Reason) switch
                {
                    (false, "Post not found") => Results.NotFound(),
                    (false, _) => Results.BadRequest(),
                    (true, _) => Results.Ok(result.Data)
                };

            });

        // MapGet para buscar a pasta por id
        

    }
}
