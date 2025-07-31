namespace Pinterest.UseCases.CreateFolder;

public record CreateFolderPayload
{
    // informações passadas na hora que cria uma pasta
    string Title;
    string ?Picture;
    Guid ProfileId;
}
