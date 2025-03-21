namespace BookStore.Application.Commands.AddBookCommand
{
    public sealed record AddBookCommand(
        string? Title,
        string? Author,
        DateOnly? PublicationDate) : ICommand<int?>
    {
    }
}
