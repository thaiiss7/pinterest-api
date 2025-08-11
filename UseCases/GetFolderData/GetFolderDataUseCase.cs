using Pinterest.Models;

namespace Pinterest.UseCases.GetFolderData;

public class GetFolderDataUseCase(PinterestDbContext db)
{
    public async Task<Result<GetFolderDataResponse>> Do(GetFolderDataPayload payload)
    {
        // var folder = await db.Folders
        //     .Where(f => f.id == payload.FolderId)
        //     .Select(f => new GetFolderDataResponse(
        //         f.Title,
        //         f.Author,
        //         f.Secret,
        //         f.Pins,
        //         f.Pins.Count
        //     ))
              

        return Result<GetFolderDataResponse>.Success(null);
    }
}