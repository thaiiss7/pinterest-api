namespace Pinterest.UseCases.DeleteProfile;

public class DeleteProfileUseCase
{
    public async Task<Result<DeleteProfileResponse>> Do(DeleteProfilePayload payload)
    {
        return Result<DeleteProfileResponse>.Success(null);
    }
}