using FluentValidation;

namespace BookStore.Application.Validation
{
    internal sealed class AuthorValidator<TObject> : AbstractValidator<TObject>
    {
        public AuthorValidator(Func<TObject, string?> func, string fieldName = "Author")
        {
            RuleFor(x => func(x))
                .SetValidator(new TextInputValidator(fieldName));
        }
    }
}
