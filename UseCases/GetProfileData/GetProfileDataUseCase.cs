using Microsoft.EntityFrameworkCore;
using Pinterest.Models;

namespace Pinterest.UseCases.GetProfileData;

public class GetProfileDataUseCase(PinterestDbContext ctx)
{
    public async Task<Result<GetProfileDataResponse>> Do(GetProfileDataPayload payload)
    {
        var profile = await ctx.Profiles
        .Include(p => p.Folders)
            .ThenInclude(f => f.Pins)
        .FirstOrDefaultAsync(p => p.Username == payload.Username);

        if (profile is null)
            return Result<GetProfileDataResponse>.Failure("Profile not found");

        var response = new GetProfileDataResponse
        (
            profile.Username,
            profile.Bio,
            from f in profile.Folders
            select new GetProfileDataFolder
            (
                f.Title,
                f.Picture,
                f.Pins.Count
            )
        );

        return Result<GetProfileDataResponse>.Success(response);
    }
}