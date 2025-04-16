using Asp.Versioning;
using BookStore.Application.Commands.AddBookCommand;
using BookStore.Application.Commands.DeleteBookCommand;
using BookStore.Application.Commands.ModifyBookCommand;
using BookStore.Application.Queries.GetBookById;
using BookStore.Application.Queries.GetBooks;
using BookStore.Core.Results;
using BookStore.Domain.Model;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.WebAPI.Controllers
{
    [Route("api/v{version:apiVersion}/books")]
    [ApiVersion("1.0")]
    public class BooksV1Controller : ApiController
    {
        public BooksV1Controller(ISender sender) : base(sender)
        { }

        #region GET methods
        [HttpGet]
        public async Task<IActionResult> GetBooksAsync(CancellationToken cancellationToken)
        {
            var query = new GetBooksQuery();

            var result = await Sender.Send(query, cancellationToken);

            return Ok(result.Value);
        }

        [HttpGet]
        [Route("{id}")]
        [ActionName(nameof(GetBookByIdAsync))] // needed because of CreatedAtAction in AddBookAsync
        public async Task<IActionResult> GetBookByIdAsync(int? id, CancellationToken cancellationToken)
        {
            var query = new GetBookByIdQuery(id);

            var result = await Sender.Send(query, cancellationToken);
            if (result.IsSuccess)
            {
                return Ok(result.Value);
            }
            else
            {
                if (result.Errors!.Any(error => error.ErrorType == ErrorType.Validation))
                {
                    return BadRequest(result.Errors);
                }
                else
                {
                    return NotFound(result.Errors);
                }
            }
        }
        #endregion

        [HttpPost]
        public async Task<IActionResult> AddBookAsync(BookDto book, CancellationToken cancellationToken)
        {
            var command = new AddBookCommand(
                book.Title,
                book.Author,
                book.PublicationDate);

            var result = await Sender.Send(command, cancellationToken);

            if (result.IsSuccess)
            {

                return CreatedAtAction(
                    nameof(GetBookByIdAsync),
                    new { id = result.Value },
                    result.Value);
            }

            return BadRequest(result.Errors);
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> ModifyBookAsync(int? id, BookDto? newBook, CancellationToken cancellationToken)
        {
            var command = new ModifyBookCommand(id, newBook);

            var result = await Sender.Send(command, cancellationToken);
            if (result.IsSuccess)
            {
                return Ok(new
                {
                    id = result.Value,
                    success = result.IsSuccess
                });
            }
            else
            {
                if (result.Errors.Any(error => error.ErrorType == ErrorType.Failure))
                {
                    return NotFound(result.Errors);
                }
                else
                {
                    return BadRequest(result.Errors);
                }
            }
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteBookAsync(int? id, CancellationToken cancellationToken)
        {
            var command = new DeleteBookCommand(id);

            var result = await Sender.Send(command, cancellationToken);

            if (result.IsSuccess)
            {
                return Ok(new
                {
                    id = result.Value,
                    deleted = result.IsSuccess
                });
            }
            else
            {
                if (result.Errors.Any(error => error.ErrorType == ErrorType.Failure))
                {
                    return NotFound(result.Errors);
                }
                else
                {
                    return BadRequest(result.Errors);
                }
            }
        }
    }
}
