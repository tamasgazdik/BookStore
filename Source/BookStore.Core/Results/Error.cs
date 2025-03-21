namespace BookStore.Core.Results
{
    public record Error(ErrorType ErrorType, string? ErrorMessage)
    { }

    public enum ErrorType
    {
        Failure = 0,
        Validation = 1,
    }
}