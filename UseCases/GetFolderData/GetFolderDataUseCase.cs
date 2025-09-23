using Microsoft.EntityFrameworkCore;
using Pinterest.Models;

namespace Pinterest.UseCases.GetFolderData;

public class GetFolderDataUseCase(PinterestDbContext ctx)
{
    public async Task<Result<GetFolderDataResponse>> Do(GetFolderDataPayload payload)
    {
        var folder = await ctx.Folders
        .Include(f => f.Pins)
            .ThenInclude(p => p.Author)
        .Include(f => f.Author)
        .FirstOrDefaultAsync(f => f.ID == payload.FolderId);

        if (folder is null)
            return Result<GetFolderDataResponse>.Failure("Folder not found");

        var response = new GetFolderDataResponse
        (
            folder.Title,
            folder.Author.Username,
            folder.ProfileID,
            folder.Secret,
            folder.Pins.Count,
            from p in folder.Pins
            select new GetFolderDataPin
            (
                p.Title,
                p.Picture,
                p.Author.Username
            )
        );

        return Result<GetFolderDataResponse>.Success(response);
    }
}