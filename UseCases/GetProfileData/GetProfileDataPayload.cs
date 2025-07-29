namespace Pinterest.UseCases.GetProfileData;

public record GetProfileDataPayload
{
    private string username;

    public GetProfileDataPayload(string username)
    {
        this.username = username;
    }
}