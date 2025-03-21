using BookStore.Application.Commands.ModifyBookCommand;
using BookStore.Domain.Model;
using FluentValidation;

namespace BookStore.Application.Validation
{
    public sealed class ModifyBookCommandValidator : AbstractValidator<ModifyBookCommand>
    {
        public ModifyBookCommandValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty().WithMessage("ID must be specified when modifying a book.");

            RuleFor(x => x.NewBook)
                .NotEmpty().WithMessage("New book details cannot be empty.")
                .SetValidator(new TitleValidator<BookDto?>(x => x!.Title))
                .SetValidator(new AuthorValidator<BookDto?>(x => x!.Author))
                .SetValidator(new PublicationDateValidator<BookDto?>(x => x!.PublicationDate));
        }
    }
}
