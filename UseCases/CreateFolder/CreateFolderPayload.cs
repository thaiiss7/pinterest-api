namespace Pinterest.UseCases.CreateFolder;

public record CreateFolderPayload
{
    // informações passadas na hora que cria uma pasta
    public string Title;
    public string? Picture;
    public bool Secret;
    public Guid ProfileId;
}
