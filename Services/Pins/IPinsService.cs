using Pinterest.Models;

namespace Pinterest.Services.Pins;

public interface IPinsService
{
    Task<Folder> Save(Guid pinId, Guid folderId);
    Task<Guid> Create(Pin pin);
}