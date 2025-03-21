using BookStore.Domain.Model;
using FluentValidation;

namespace BookStore.Application.Validation
{
    internal class BookValidator : AbstractValidator<Book>
    {
        public BookValidator()
        {
            RuleFor(x => x)
                .NotNull().WithMessage("Book cannot be null.")
                .SetValidator(new TitleValidator<Book>(book => book!.Title))
                .SetValidator(new AuthorValidator<Book>(book => book!.Author))
                .SetValidator(new PublicationDateValidator<Book>(book => book!.PublicationDate));
        }
    }
}
