using FluentValidation;
using KasiTix.Api.DTOs;

namespace KasiTix.Api.Validators;

public class CreateTicketTypeValidator
    : AbstractValidator<CreateTicketTypeRequest>
{
    public CreateTicketTypeValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty();

        RuleFor(x => x.Price)
            .GreaterThanOrEqualTo(0);

        RuleFor(x => x.Capacity)
            .InclusiveBetween(1, 10000);
    }
}
