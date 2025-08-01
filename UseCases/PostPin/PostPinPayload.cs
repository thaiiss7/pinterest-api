namespace Pinterest.UseCases.PostPin;

public record PostPinPayload
{
    public string Title;
    public string Picture;
    public Guid ProfileId;
};
