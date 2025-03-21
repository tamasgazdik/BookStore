using FluentValidation;

namespace BookStore.Application.Validation
{
    internal sealed class PublicationDateValidator<TObject> : AbstractValidator<TObject>
    {
        public PublicationDateValidator(Func<TObject?, DateOnly?> func, string fieldName = "PublicationDate")
        {
            RuleFor(x => func(x))
                .NotEmpty().WithMessage($"{fieldName} cannot be empty.")
                .Must(BeInPast).WithMessage($"{fieldName} cannot exceed the date of today.");
        }

        public static bool BeInPast(DateOnly? dateOnly)
        {
            return dateOnly <= DateOnly.FromDateTime(DateTime.Today);
        }
    }
}
