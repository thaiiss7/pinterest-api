
namespace Pinterest.EndPoints;

public static class PinEndpoints
{
    public static void ConfigurePinEndpoints(this WebApplication app)
    {
        // MapGet para buscar um pin pelo id
        app.MatGet("pin/{id}", async (
            string id,
            [FromServices]GetPinDataPayload(title)) =>
        {
            var payload = new GetPinDataPayload(title);
            var result = await useCase.Do(payload);

            return (result.IsSuccess, result.Reason) switch
            {
                (false, "Pin not found") => Results.NotFound(),
                (false, _) => Results.BadRequest(),
                (true, _) => Results.Ok(result.Data)
            };

        });

        // MapPost para publicar um pin
        app.MapPost("pin", async (
            [FromBody]PostPinPayload payload,
            [FromServices]PostPinUseCase useCase) =>
            {
                var result = await useCase.Do(payload);
            
                return (result.IsSuccess, result.Reason) switch
                {
                    (false, "Pin not found") => Results.NotFound(),
                    (false, _) => Results.BadRequest(),
                    (true, _) => Results.Ok(result.Data)
                };
            
            });

        // MapPost para salvar um pin em uma pasta
        app.MapPost("/save", async (
            [FromBody]SavePinPayload payload,
            [FromServices]SavePinUseCase useCase) =>
            {
                var result = await useCase.Do(payload);
            
                return (result.IsSuccess, result.Reason) switch
                {
                    (false, "Pin not found") => Results.NotFound(),
                    (false, _) => Results.BadRequest(),
                    (true, _) => Results.Ok(result.Data)
                };
            });

        // MapDelete para deletar um pin por id
        // estudar mais isso aqui depois
        app.MapDelete("pin/{id}", async (string id, 
            HttpContext http,
            [FromServices]DeletePinUseCase useCase) =>
        {
            var claim = http.User.FindFirst(ClaimTypes.NameIdentifier);
            var userId = Guid.Parse(claim.Value);
            var pinId = Guid.Parse(id);
            var payload = new DeletePinPayload(pinId, userId);
            var result = await useCase.Do(payload);

            return (result.IsSuccess, result.Reason) switch
            {
                (false, "Pin not found") => Results.NotFound(),
                (false, _) => Results.BadRequest(),
                (true, _) => Results.Ok()
            };
        }).RequireAuthorization();
    
    }
}