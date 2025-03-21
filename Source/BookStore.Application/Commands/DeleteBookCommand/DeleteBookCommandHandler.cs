using BookStore.Application.Repository;
using BookStore.Core.Results;
using FluentValidation;

namespace BookStore.Application.Commands.DeleteBookCommand
{
    public sealed class DeleteBookCommandHandler : ICommandHandler<DeleteBookCommand, int?>
    {
        private readonly IValidator<DeleteBookCommand> validator;
        private readonly IBookStoreRepository bookStoreRepository;

        public DeleteBookCommandHandler(
            IValidator<DeleteBookCommand> validator,
            IBookStoreRepository bookStoreRepository)
        {
            this.validator = validator;
            this.bookStoreRepository = bookStoreRepository;
        }

        public async Task<Result<int?>> Handle(DeleteBookCommand request, CancellationToken cancellationToken)
        {
            var validationResult = await validator.ValidateAsync(request);
            if (validationResult.IsValid)
            {
                var result = await bookStoreRepository.DeleteBookAsync(request.Id.Value, cancellationToken);
                if (result is not null && result.HasValue)
                {
                    return Result.Success<int?>(result.Value);
                }
                else
                {
                    return Result.Failure<int?>(
                        new Error(ErrorType.Failure, $"Book with specified ID '{request.Id}' cannot be found."));
                }
            }
            else
            {
                var validationErrors = validationResult.Errors.Select(validationError =>
                    new Error(ErrorType.Validation, validationError.ErrorMessage));

                return Result.Failure<int?>(validationErrors);
            }
        }
    }
}
