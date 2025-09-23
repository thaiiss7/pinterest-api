namespace Pinterest.UseCases.Follow;

public record FollowPayload
(
    string Username,
    Guid FollowerId
);