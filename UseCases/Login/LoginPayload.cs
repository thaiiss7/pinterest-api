namespace Pinterest.UseCases.Login;

public record LoginPayload(
    string Login,
    string Password
);