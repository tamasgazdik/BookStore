using BookStore.Application.Repository;
using BookStore.Domain.Model;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Infrastructure
{
    public sealed class BookStoreRepository : IBookStoreRepository
    {
        private readonly BookStoreDbContext bookStoreDbContext;

        public BookStoreRepository(BookStoreDbContext bookStoreDbContext)
        {
            this.bookStoreDbContext = bookStoreDbContext;
        }

        #region Query Implementations
        public async Task<ICollection<Book>> GetBooksAsync(CancellationToken cancellationToken = default)
        {
            return await bookStoreDbContext.Books.ToListAsync(cancellationToken);
        }

        public async Task<Book?> GetBookByIdAsync(int id, CancellationToken cancellationToken = default)
        {
            // in case the cancellationToken cannot be passed
            // cancellationToken.ThrowIfCancellationRequested();

            var result = await bookStoreDbContext.Books.FindAsync(id, cancellationToken);
            return result;
        }
        #endregion

        #region Command Implementations
        public async Task<int?> AddBookAsync(Book book, CancellationToken cancellationToken = default)
        {
            var result = await bookStoreDbContext.Books.AddAsync(book, cancellationToken);
            await bookStoreDbContext.SaveChangesAsync(cancellationToken);

            return result.Entity.Id;
        }

        public async Task<int?> ModifyBookAsync(int id, BookDto newBook, CancellationToken cancellationToken = default)
        {
            var bookToBeModified = await bookStoreDbContext.Books.FindAsync(id, cancellationToken);
            if (bookToBeModified is null)
            {
                return null;
            }
            else
            {
                bookToBeModified.Title = newBook.Title!;
                bookToBeModified.Author = newBook.Author!;
                bookToBeModified.PublicationDate = newBook.PublicationDate;

                await bookStoreDbContext.SaveChangesAsync(cancellationToken);

                return id;
            }
        }

        public async Task<int?> DeleteBookAsync(int id, CancellationToken cancellationToken = default)
        {
            var bookToBeDeleted = await bookStoreDbContext.Books.FindAsync(id);
            if (bookToBeDeleted is null)
            {
                return null;
            }
            else
            {
                bookStoreDbContext.Books.Remove(bookToBeDeleted);
                
                await bookStoreDbContext.SaveChangesAsync(cancellationToken);
                
                return id;
            }
        }
        #endregion
    }
}
