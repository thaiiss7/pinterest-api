namespace Pinterest.UseCases.DeletePin;

public record DeletePinPayload(
    Guid PinId,
    Guid UserId
);
