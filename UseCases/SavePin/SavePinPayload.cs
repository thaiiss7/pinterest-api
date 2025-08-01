namespace Pinterest.UseCases.SavePin;

public record SavePinPayload(
    Guid PinId,
    Guid FolderId
);