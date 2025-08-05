namespace Pinterest.UseCases.DeleleFolder;

public record DeleteFolderPayload(
    Guid FolderId,
    Guid UserId
);
