using Pinterest.UseCases;
using Pinterest.UseCases.CreateProfile;
using Pinterest.UseCases.GetProfileData;
using Microsoft.AspNetCore.Mvc;

namespace Pinterest.Endpoints;

//MapGet para buscar os dados do usuário
//MapPost para criar um novo usuário
public static class ProfileEndpoints
{
    public static void ConfigureProfileEndpoints(this WebApplication app)
    {
        app.MapGet("profile/{username}", async (
            string username,
            [FromServices]GetProfileDataUseCase useCase) =>
        {
            var payload = new GetProfileDataPayload(username);
            var result = await useCase.Do(payload);

            return (result.IsSuccess, result.Reason) switch
            {
                (false, "User not found") => Results.NotFound(),
                (false, _) => Results.BadRequest(),
                (true, _) => Results.Ok(result.Data)
            };
        });
        
        app.MapPost("profile", async (
            [FromBody]CreateProfilePayload payload, 
            [FromServices]CreateProfileUseCase useCase) =>
        {
            var result = await useCase.Do(payload);
            if (result.IsSuccess)
                return Results.Created();
            
            return Results.BadRequest(result.Reason);
        });
    }
}
