namespace Pinterest.UseCases.CommentPin;

public record CommentPinPayload
(
    Guid UserId,
    Guid PinId,
    string Text
);