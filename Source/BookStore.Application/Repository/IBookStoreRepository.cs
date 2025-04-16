using BookStore.Domain.Model;

namespace BookStore.Application.Repository
{
    public interface IBookStoreRepository
    {
        Task<ICollection<Book>> GetBooksAsync(CancellationToken cancellationToken = default);

        Task<Book?> GetBookByIdAsync(int id, CancellationToken cancellationToken = default);

        Task<Book?> AddBookAsync(Book book, CancellationToken cancellationToken = default);

        Task<int?> ModifyBookAsync(int id, BookDto newBook, CancellationToken cancellationToken = default);

        Task<int?> DeleteBookAsync(int id, CancellationToken cancellationToken = default);
    }
}
