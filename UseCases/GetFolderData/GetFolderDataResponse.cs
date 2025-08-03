using Pinterest.Models;

namespace Pinterest.UseCases.GetFolderData;

public record GetFolderDataPin(
    string Title,
    string Picture,
    Profile Author
);
public record GetFolderDataResponse(
    string Title,
    Profile Author,
    //int NumberOfpins,
    ICollection<Pin> Pins
);