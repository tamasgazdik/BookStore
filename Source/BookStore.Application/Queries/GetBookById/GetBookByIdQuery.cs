using BookStore.Domain.Model;

namespace BookStore.Application.Queries.GetBookById
{
    public sealed record GetBookByIdQuery(int? id) : IQuery<Book?>
    {
    }
}
