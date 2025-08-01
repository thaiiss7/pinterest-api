using Pinterest.Services.Pins;

namespace Pinterest.UseCases.SavePin;

public class SavePinUseCase(
    IPinsService pinsService
)
{
    public async Task<Result<SavePinResponse>> Do(SavePinPayload payload)
    {
        var folder = payload.FolderId;
        

        return Result<SavePinResponse>.Success(null);
    }
}