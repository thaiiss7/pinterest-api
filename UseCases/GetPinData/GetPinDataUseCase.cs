namespace Pinterest.UseCases.GetPinData;

public class GetPinDataUseCase
{
    public async Task<Result<GetPinDataResponse>> Do(GetPinDataPayload payload)
    {
        return Result<GetPinDataResponse>.Success(null);
    }
}