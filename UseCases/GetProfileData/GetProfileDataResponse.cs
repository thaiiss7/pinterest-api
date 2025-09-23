namespace Pinterest.UseCases.GetProfileData;

public record GetProfileDataFolder(
    string Title,
    string Picture,
    int NumberOfPins
);

public record GetProfileDataResponse(
    string Username,
    string? Bio,
    int Followers,
    IEnumerable<GetProfileDataFolder> Folders
);
