namespace Pinterest.UseCases.GetFolderData;

public class GetFolderDataUseCase
{
    public async Task<Result<GetFolderDataResponse>> Do(GetFolderDataPayload payload)
    {
        return Result<GetFolderDataResponse>.Success(null);
    }
}