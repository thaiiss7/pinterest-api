using Pinterest.Models;

namespace Pinterest.UseCases.GetFolderData;

public record GetFolderDataPin(
    string Title,
    string Picture,
    string AuthorName
);
public record GetFolderDataResponse(
    string Title,
    string AuthorName,
    bool Secret,
    int NumberOfpins,
    IEnumerable<GetFolderDataPin> Pins
);