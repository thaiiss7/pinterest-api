namespace Pinterest.UseCases.PostPin;

public record PostPinPayload(
    string Title,
    string Picture,
    Guid ProfileId
);
