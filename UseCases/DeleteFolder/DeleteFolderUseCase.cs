using Pinterest.UseCases.DeleleFolder;

namespace Pinterest.UseCases.DeleteFolder;

public class DeleteFolderUseCase
{
    public async Task<Result<DeleteFolderResponse>> Do(DeleteFolderPayload payload)
    {
        return Result<DeleteFolderResponse>.Success(null);
    }
}