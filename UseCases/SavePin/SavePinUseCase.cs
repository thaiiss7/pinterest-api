namespace Pinterest.UseCases.SavePin;

public class SavePinUseCase
{
    public async Task<Result<SavePinResponse>> Do(SavePinPayload payload)
    {
        return Result<SavePinResponse>.Success(null);
    }
}