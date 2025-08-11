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
    bool Secret,
    int NumberOfpins, //(não sei ainda como vou fazer isso, depois eu penso)
    ICollection<Pin> Pins
);