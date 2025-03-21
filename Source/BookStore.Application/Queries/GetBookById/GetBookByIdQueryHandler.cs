using BookStore.Application.Queries.GetBookById.Errors;
using BookStore.Application.Repository;
using BookStore.Core.Results;
using BookStore.Domain.Model;

namespace BookStore.Application.Queries.GetBookById
{
    public sealed class GetBookByIdQueryHandler : IQueryHandler<GetBookByIdQuery, Book?>
    {
        private readonly IBookStoreRepository bookStoreRepository;

        public GetBookByIdQueryHandler(IBookStoreRepository bookStoreRepository)
        {
            this.bookStoreRepository = bookStoreRepository;
        }

        public async Task<Result<Book?>> Handle(GetBookByIdQuery request, CancellationToken cancellationToken)
        {
            if (request.id is null || !request.id.HasValue)
            {
                return Result.Failure<Book?>(new Error(ErrorType.Validation, "ID cannot be empty when querying for a book."));
            }

            var book = await bookStoreRepository.GetBookByIdAsync(request.id.Value);
            if (book is not null)
            {
                return Result.Success(book)!;
            }
            else
            {
                return Result.Failure(
                    [ new Error(ErrorType.Failure, $"Book with specified ID '{request.id.Value}' cannot be found.") ], 
                    book);
            }
        }
    }
}
