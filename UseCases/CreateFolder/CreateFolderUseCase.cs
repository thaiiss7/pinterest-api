namespace Pinterest.UseCases.CreateFolder;

public class CreateFolderUseCase
{
    public async Task<Result<CreateFolderResponse>> Do(CreateFolderPayload payload)
    {
        return Result<CreateFolderResponse>.Success(null);
    }
}