using Asp.Versioning;
using Infrastructure;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/v{version:apiVersion}")]
    [ApiVersion("1.0")]
    public class BooksV1Controller : ControllerBase
    {
        private readonly BookStoreDbContext bookStoreDbContext;

        public BooksV1Controller(BookStoreDbContext bookStoreDbContext)
        {
            this.bookStoreDbContext = bookStoreDbContext;
        }

        [HttpGet]
        [Route("books")]
        public IActionResult GetBooks()
        {
            var books = bookStoreDbContext.Books;
            return Ok(books);
        }
    }
}
