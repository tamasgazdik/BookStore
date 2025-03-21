using BookStore.Domain.Model;

namespace BookStore.Application.Queries.GetBooks
{
    public sealed record GetBooksQuery : IQuery<ICollection<Book>>
    {
    }
}
