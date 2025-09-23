using Microsoft.EntityFrameworkCore;
using Pinterest.Models;
using Pinterest.UseCases.DeleleFolder;

namespace Pinterest.UseCases.DeleteFolder;

public class DeleteFolderUseCase(PinterestDbContext ctx)
{
    public async Task<Result<DeleteFolderResponse>> Do(DeleteFolderPayload payload)
    {
        var folder = await ctx.Folders.FirstOrDefaultAsync(f => f.ID == payload.FolderId);

        if (folder.ProfileID != payload.UserId)
            return Result<DeleteFolderResponse>.Failure("You are not the owner of this folder");

        if (folder is null)
            return Result<DeleteFolderResponse>.Failure("Folder not found");

        ctx.Folders.Remove(folder);
        await ctx.SaveChangesAsync();

        return Result<DeleteFolderResponse>.Success(null);
    }
}