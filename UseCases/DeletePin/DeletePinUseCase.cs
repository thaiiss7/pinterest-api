namespace Pinterest.UseCases.DeletePin;

public class DeletePinUseCase
{
    public async Task<Result<DeletePinResponse>> Do(DeletePinPayload payload)
    {
        return Result<DeletePinResponse>.Success(null);
    }
}