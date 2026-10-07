using FluentValidation;
using KasiTix.Api.DTOs;

namespace KasiTix.Api.Validators;

public class CreateEventValidator
    : AbstractValidator<CreateEventRequest>
{
    public CreateEventValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty()
            .MaximumLength(120);

        RuleFor(x => x.Venue)
            .NotEmpty();

        RuleFor(x => x.StartsAt)
            .GreaterThan(DateTime.UtcNow);
    }
}
