using Pinterest.UseCases;
using Pinterest.UseCases.CreateProfile;
using Pinterest.UseCases.GetProfileData;
using Microsoft.AspNetCore.Mvc;
using Pinterest.UseCases.DeleteProfile;
using System.Security.Claims;
using Pinterest.UseCases.DeleleFolder;

namespace Pinterest.Endpoints;

public static class ProfileEndpoints
{
    public static void ConfigureProfileEndpoints(this WebApplication app)
    {
        //MapGet para buscar os dados do usuário
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
        
        //MapPost para criar um novo usuário
        app.MapPost("profile", async (
            [FromBody]CreateProfilePayload payload, 
            [FromServices]CreateProfileUseCase useCase) =>
        {
            var result = await useCase.Do(payload);
            if (result.IsSuccess)
                return Results.Created();
            
            return Results.BadRequest(result.Reason);
        });

        // MapDelete para deletar uma perfil por id
        app.MapDelete("profile/{id}", async (string id, 
            HttpContext http,
            [FromServices]DeleteProfileUseCase useCase) =>
        {
            var claim = http.User.FindFirst(ClaimTypes.NameIdentifier);
            var userId = Guid.Parse(claim.Value);
            var profileId = Guid.Parse(id);
            var payload = new DeleteFolderPayload(userId);
            var result = await useCase.Do(payload);

            return (result.IsSuccess, result.Reason) switch
            {
                (false, "Profile not found") => Results.NotFound(),
                (false, _) => Results.BadRequest(),
                (true, _) => Results.Ok()
            };
        }).RequireAuthorization();
    }
}
