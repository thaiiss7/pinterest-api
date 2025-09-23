namespace Pinterest.Data;

public record CreateFolderData
(
    string Title,
    string? Picture,
    bool Secret
);