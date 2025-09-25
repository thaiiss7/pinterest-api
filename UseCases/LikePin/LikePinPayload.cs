namespace Pinterest.UseCases.LikePin;

public record LikePinPayload
(
    Guid PinId,
    Guid Userid
);