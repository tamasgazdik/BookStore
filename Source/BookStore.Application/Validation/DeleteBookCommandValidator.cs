using BookStore.Application.Commands.DeleteBookCommand;
using BookStore.Domain.Model;
using FluentValidation;

namespace BookStore.Application.Validation
{
    public sealed class DeleteBookCommandValidator : AbstractValidator<DeleteBookCommand>
    {
        public DeleteBookCommandValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty().WithMessage("ID must be specified when deleting a book.");
        }
    }
}
