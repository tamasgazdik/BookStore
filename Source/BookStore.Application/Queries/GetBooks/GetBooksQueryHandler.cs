using BookStore.Application.Repository;
using BookStore.Core.Results;
using BookStore.Domain.Model;

namespace BookStore.Application.Queries.GetBooks
{
    public class GetBooksQueryHandler : IQueryHandler<GetBooksQuery, ICollection<Book>>
    {
        private readonly IBookStoreRepository bookStoreRepository;

        public GetBooksQueryHandler(IBookStoreRepository bookStoreRepository)
        {
            this.bookStoreRepository = bookStoreRepository;
        }

        public async Task<Result<ICollection<Book>>> Handle(GetBooksQuery request, CancellationToken cancellationToken)
        {
            var books = await bookStoreRepository.GetBooksAsync(cancellationToken);
            return Result.Success(books);
        }
    }
}
