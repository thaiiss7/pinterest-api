namespace Pinterest.UseCases.GetPinData;

public record GetPinDataResponse(
    string Title,
    string Picture,
    Profile Author
);