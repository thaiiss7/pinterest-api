using Microsoft.EntityFrameworkCore;
using Pinterest.Models;

namespace Pinterest.UseCases.DeletePin;

public class DeletePinUseCase(PinterestDbContext ctx)
{
    public async Task<Result<DeletePinResponse>> Do(DeletePinPayload payload)
    {
        var pin = await ctx.Pins
        .Include(p => p.Folders)
            .ThenInclude(f => f.Pins)
        .FirstOrDefaultAsync(p => p.ID == payload.PinId);

        if (pin.ProfileID != payload.UserId)
            return Result<DeletePinResponse>.Failure("You are not the owner of this Pin");

        if (pin is null)
            return Result<DeletePinResponse>.Failure("Pin not found");

        // foreach (var folder in pin.Folders)
        // {
        //     ctx.Folders.Pins.Remove(pin);
        // }

        ctx.Pins.Remove(pin);
        await ctx.SaveChangesAsync();

        return Result<DeletePinResponse>.Success(null);
    }
}