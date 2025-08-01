using Pinterest.Services.JWT;
using Pinterest.Services.Password;
using Pinterest.Services.Profiles;

namespace Pinterest.UseCases.Login;

public class LoginUseCase(
    IProfileService profileService,
    IPasswordService passwordService,
    IJWTService jWTService
)
{
    public async Task<Result<LoginResponse>> Do(LoginPayload payload)
    {
        var user = await profileService.FindByLogin(payload.Login);
        if (user is null)
            return Result<LoginResponse>.Failure("User not found");

        var passwordMatch = passwordService
            .Compare(payload.Password, user.Password);

        if (!passwordMatch)
            return Result<LoginResponse>.Failure("User not found");

        var jwt = jWTService.CreateToken(new(
            user.ID, user.Username
        ));

        return Result<LoginResponse>.Success(new LoginResponse(jwt));
    }
}