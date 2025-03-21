using FluentValidation;

namespace BookStore.Application.Validation
{
    internal class TextInputValidator : AbstractValidator<string?>
    {
        public TextInputValidator(string fieldName)
        {
            RuleFor(x => x)
                .NotEmpty().WithMessage($"{fieldName} cannot be empty.")
                .MaximumLength(100).WithMessage($"{fieldName} must be shorter than or equal to 100 characters.")
                .Must(NotStartOrEndWithWhitespaces).WithMessage($"{fieldName} must not start or end with whitespace.")
                .Must(BeInPascalCase).WithMessage($"{fieldName} must be specified in pascal case.");
        }

        private static bool BeInPascalCase(string text)
        {
            var words = text.Split(' ');

            if (words.Any(word => !(char.IsSymbol(word[0]) || char.IsNumber(word[0])) &&
                                    char.IsLower(word[0])
                                    ))
            {
                return false;
            }
            return true;
        }

        private static bool NotStartOrEndWithWhitespaces(string text)
        {
            if (char.IsWhiteSpace(text[0]) ||
                char.IsWhiteSpace(text[^1]))
            {
                // this is wrong, the title is not valid
                return false;
            }
            return true;
        }
    }
}
