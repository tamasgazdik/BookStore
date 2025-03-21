namespace BookStore.Domain.Model
{
    public sealed record BookDto(string? Title, string? Author, DateOnly? PublicationDate)
    { }
}
