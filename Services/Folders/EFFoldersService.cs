using Pinterest.Models;

namespace Pinterest.Services.Folders;

public class EFFoldersService(PinterestDbContext ctx) : IFoldersService
{
    public async Task<Guid> Create(Folder folder)
    {
        ctx.Folders.Add(folder);
        await ctx.SaveChangesAsync();
        return folder.ID;
    }
}