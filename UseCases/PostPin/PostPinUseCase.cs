using Pinterest.Models;
using Pinterest.Services.Pins;

namespace Pinterest.UseCases.PostPin;

public class PostPinUseCase(
    IPinsService pinsService
)
{
    public async Task<Result<PostPinResponse>> Do(PostPinPayload payload)
    {
        var pin = new Pin
        {
            Title = payload.Title,
            Picture = payload.Picture,
            ProfileID = payload.ProfileId
        };

        await pinsService.Create(pin);

        return Result<PostPinResponse>.Success(null);
    }
}