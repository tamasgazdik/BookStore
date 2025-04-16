using BookStore.Domain.Model;

namespace BookStore.Application.Commands.AddBookCommand
{
    public sealed record AddBookCommand(
        string? Title,
        string? Author,
        DateOnly? PublicationDate) : ICommand<Book?>
    {
    }
}
