using Microsoft.EntityFrameworkCore;
using Pinterest.Models;

namespace Pinterest.UseCases.DeleteProfile;

public class DeleteProfileUseCase(PinterestDbContext ctx)
{
    public async Task<Result<DeleteProfileResponse>> Do(DeleteProfilePayload payload)
    {
        var profile = await ctx.Profiles
        .FirstOrDefaultAsync(p => p.ID == payload.UserId);

        if (profile.ID != payload.UserId)
            return Result<DeleteProfileResponse>.Failure("Unathorized");

        if (profile is null)
            return Result<DeleteProfileResponse>.Failure("Profile not found");

        foreach (var folder in profile.Folders)
        {
            ctx.Folders.Remove(folder);
        }

        foreach (var pin in profile.CreatedPins)
        {
            ctx.Pins.Remove(pin);
        }

        ctx.Profiles.Remove(profile);
        await ctx.SaveChangesAsync();

        return Result<DeleteProfileResponse>.Success(null);
    }
}