namespace Pinterest.Endpoints;

public static class FolderEndpoints
{
    public static void ConfigureFolderEndpoints(this WebApplication app)
    {
        // MapPost para criar uma pasta
        app.MapPost("folder", async (
            [FromBody]CreateFolderPayload payload,
            [FromServices]CreateFolderUseCase useCase) => 
            {
                var result = await useCase.Do(payload);
                if (result.IsSuccess)
                
            });

        // MapGet para buscar a pasta por id

    }
}
