using Pinterest.Models;
using Pinterest.Services.Folders;

namespace Pinterest.UseCases.CreateFolder;

public class CreateFolderUseCase(
    IFoldersService foldersService
)
{
    public async Task<Result<CreateFolderResponse>> Do(CreateFolderPayload payload)
    {
        var folder = new Folder
        {
            Title = payload.Title,
            Picture = payload.Picture,
            Secret = payload.Secret,
            ProfileID = payload.ProfileId
        };

        await foldersService.Create(folder);

        return Result<CreateFolderResponse>.Success(null);
    }
}