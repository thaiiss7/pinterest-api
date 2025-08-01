using Microsoft.EntityFrameworkCore;
using Pinterest.Models;

namespace Pinterest.Services.Pins;

public class EFPinService(PinterestDbContext ctx) : IPinsService
{
    public async Task<Folder> Save(Guid pinId, Guid folderId)
    {
        var folder = await ctx.Folders.FirstOrDefaultAsync(f => f.ID == folderId);
        var pin = await ctx.Pins.FirstOrDefaultAsync(p => p.ID == pinId);
        folder.Pins.Add(pin);
        await ctx.SaveChangesAsync();
        
        return folder;
    }
}