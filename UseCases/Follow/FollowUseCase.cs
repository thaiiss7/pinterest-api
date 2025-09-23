using Microsoft.EntityFrameworkCore;
using Pinterest.Models;

namespace Pinterest.UseCases.Follow;

public class FollowUseCase(PinterestDbContext ctx)
{
    public async Task<Result<FollowResponse>> Do(FollowPayload payload)
    {
        var profile = await ctx.Profiles.FirstOrDefaultAsync(p => p.Username == payload.Username);
        var follower = await ctx.Profiles.FirstOrDefaultAsync(f => f.ID == payload.FollowerId);

        if (profile is null)
            return Result<FollowResponse>.Failure("User not found");

        if (follower is null)
            return Result<FollowResponse>.Failure("User not found");

        profile.Followers.Add(follower);
        await ctx.SaveChangesAsync();

        return Result<FollowResponse>.Success(null);
    }
}