namespace Pinterest.UseCases.PostPin;

public class PostPinUseCase
{
    public async Task<Result<PostPinResponse>> Do(PostPinPayload payload)
    {
        return Result<PostPinResponse>.Success(null);
    }
}