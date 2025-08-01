namespace Pinterest;

public record Result<T>(
    T Data,
    bool IsSuccess,
    string Reason
)
{
    public static Result<T> Success(T data)
    => new(data, true, string.Empty);

    public static Result<T> Failure(string reason)
    => new(default, false, reason);
}