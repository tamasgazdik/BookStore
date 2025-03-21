using BookStore.Domain.Model;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Infrastructure
{
    public class BookStoreDbContext : DbContext
    {
        public BookStoreDbContext(DbContextOptions<BookStoreDbContext> dbContextOptions) : base(dbContextOptions)
        { }

        public DbSet<Book> Books { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Book>().HasData(
                new Book { Id = 1, Title = "The Catcher in the Rye", Author = "J.D. Salinger", PublicationDate = new DateOnly(1951, 7, 16) },
                new Book { Id = 2, Title = "To Kill a Mockingbird", Author = "Harper Lee", PublicationDate = new DateOnly(1960, 7, 11) },
                new Book { Id = 3, Title = "1984", Author = "George Orwell", PublicationDate = new DateOnly(1949, 6, 8) },
                new Book { Id = 4, Title = "Pride and Prejudice", Author = "Jane Austen", PublicationDate = new DateOnly(1813, 1, 28) },
                new Book { Id = 5, Title = "The Great Gatsby", Author = "F. Scott Fitzgerald", PublicationDate = new DateOnly(1925, 4, 10) },
                new Book { Id = 6, Title = "Moby-Dick", Author = "Herman Melville", PublicationDate = new DateOnly(1851, 10, 18) },
                new Book { Id = 7, Title = "War and Peace", Author = "Leo Tolstoy", PublicationDate = new DateOnly(1869, 1, 1) },
                new Book { Id = 8, Title = "The Hobbit", Author = "J.R.R. Tolkien", PublicationDate = new DateOnly(1937, 9, 21) },
                new Book { Id = 9, Title = "Crime and Punishment", Author = "Fyodor Dostoevsky", PublicationDate = new DateOnly(1866, 1, 1) },
                new Book { Id = 10, Title = "The Odyssey", Author = "Homer", PublicationDate = new DateOnly(0701, 1, 1) });
        }
    }
}
