using Pinterest.Models;
using Pinterest.Services.Pins;

namespace Pinterest.UseCases.SavePin;

public class SavePinUseCase(
    IPinsService pinsService
)
{
    public async Task<Result<SavePinResponse>> Do(SavePinPayload payload)
    {
        await pinsService.Save(payload.PinId, payload.FolderId);

        return Result<SavePinResponse>.Success(null);
    }
}