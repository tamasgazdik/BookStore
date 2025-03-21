using BookStore.Domain.Model;

namespace BookStore.Application.Commands.ModifyBookCommand
{
    public sealed record ModifyBookCommand(int? Id, BookDto? NewBook) : ICommand<int?>
    {
    }
}
