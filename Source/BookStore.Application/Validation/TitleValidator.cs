using FluentValidation;

namespace BookStore.Application.Validation
{
    internal sealed class TitleValidator<TObject> : AbstractValidator<TObject>
    {
        public TitleValidator(Func<TObject?, string?> func, string fieldName = "Title")
        {
            RuleFor(x => func(x))
                .SetValidator(new TextInputValidator(fieldName));
        }
    }
}
