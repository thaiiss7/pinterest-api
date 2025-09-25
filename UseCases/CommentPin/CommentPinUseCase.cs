using Microsoft.EntityFrameworkCore;
using Pinterest.Models;

namespace Pinterest.UseCases.CommentPin;

public class CommentPinUseCase(PinterestDbContext ctx)
{
    public async Task<Result<CommentPinResponse>> Do(CommentPinPayload payload)
    {
        var user = await ctx.Profiles.FirstOrDefaultAsync(p => p.ID == payload.UserId);
        var pin = await ctx.Pins
        .Include(p => p.Comments)
        .FirstOrDefaultAsync(p => p.ID == payload.PinId);

        if (user is null)
            return Result<CommentPinResponse>.Failure("User not found");

        if (pin is null)
            return Result<CommentPinResponse>.Failure("Pin not found");

        // var comment = new Comment
        // {
        //     Text = payload.Text,
        //     Author = payload.
        // }
    }
}