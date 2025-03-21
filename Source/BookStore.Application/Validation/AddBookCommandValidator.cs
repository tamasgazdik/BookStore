using BookStore.Application.Commands.AddBookCommand;
using FluentValidation;

namespace BookStore.Application.Validation
{
    public sealed class AddBookCommandValidator : AbstractValidator<AddBookCommand>
    {
        public AddBookCommandValidator()
        {
            RuleFor(x => x)
                .NotNull().WithMessage("AddBookCommand cannot be null.")
                .SetValidator(new TitleValidator<AddBookCommand>(x => x!.Title))
                .SetValidator(new AuthorValidator<AddBookCommand>(x => x!.Author))
                .SetValidator(new PublicationDateValidator<AddBookCommand>(x => x!.PublicationDate));
        }
    }
}
