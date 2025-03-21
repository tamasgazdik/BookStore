using BookStore.Application.Repository;
using BookStore.Core.Results;
using BookStore.Domain.Model;
using FluentValidation;

namespace BookStore.Application.Commands.AddBookCommand
{
    internal class AddBookCommandHandler : ICommandHandler<AddBookCommand, int?>
    {
        private readonly IValidator<AddBookCommand> bookValidator;
        private readonly IBookStoreRepository bookStoreRepository;

        public AddBookCommandHandler(
            IValidator<AddBookCommand> bookValidator,
            IBookStoreRepository bookStoreRepository)
        {
            this.bookValidator = bookValidator;
            this.bookStoreRepository = bookStoreRepository;
        }

        public async Task<Result<int?>> Handle(AddBookCommand request, CancellationToken cancellationToken)
        {
            var validationResult = await bookValidator.ValidateAsync(request);
            if (validationResult.IsValid)
            {
                var book = new Book
                {
                    Title = request.Title!,
                    Author = request.Author!,
                    PublicationDate = request.PublicationDate
                };

                var createdBookId = await bookStoreRepository.AddBookAsync(book, cancellationToken);
                if (createdBookId is not null && createdBookId.HasValue)
                {
                    return Result.Success<int?>(createdBookId.Value);
                }
                else
                {
                    return Result.Failure<int?>(
                        new Error(ErrorType.Failure, "Unkown error occured during book creation.")
                    );
                }
            }
            else
            {
                var errors = validationResult.Errors.Select(validationError =>
                    new Error(ErrorType.Validation, validationError.ErrorMessage));
                
                return Result.Failure<int?>(errors);
            }
        }
    }
}
