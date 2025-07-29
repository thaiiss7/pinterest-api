namespace Pinterest.UseCases.GetProfileData;

public record GetProfileDataFolder(
    string Title,
    string Picture,
    // int NumberOfPins
    // vou ver como implemento depois
);

public record GetProfileDataResponse(
    string Username,
    string Bio,
    ICollection<GetProfileDataFolder> Folders
);
