namespace BookStore.Application.Commands.DeleteBookCommand
{
    public sealed record DeleteBookCommand(int? Id) : ICommand<int?>
    {
    }
}
