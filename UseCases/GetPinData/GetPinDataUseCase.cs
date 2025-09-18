using Microsoft.EntityFrameworkCore;
using Pinterest.Models;

namespace Pinterest.UseCases.GetPinData;

public class GetPinDataUseCase(PinterestDbContext ctx)
{
    public async Task<Result<GetPinDataResponse>> Do(GetPinDataPayload payload)
    {
        var pin = await ctx.Pins
        .Include(p => p.Author)
        .FirstOrDefaultAsync(p => p.ID == payload.PinId);

        if (pin is null)
            return Result<GetPinDataResponse>.Failure("Pin not found");

        var response = new GetPinDataResponse
        (
            pin.Title,
            pin.Picture,
            pin.Author.Username
        );

        return Result<GetPinDataResponse>.Success(response);
    }
}