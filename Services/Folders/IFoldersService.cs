using Pinterest.Models;

namespace Pinterest.Services.Folders;

public interface IFoldersService
{
    Task<Guid> Create(Folder folder);
}