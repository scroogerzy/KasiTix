using FluentValidation;
using KasiTix.Api.DTOs;

namespace KasiTix.Api.Validators;

public class CreateOrderValidator
    : AbstractValidator<CreateOrderRequest>
{
    public CreateOrderValidator()
    {
        RuleFor(x => x.BuyerEmail)
            .NotEmpty()
            .EmailAddress();

        RuleFor(x => x.Lines.Count)
            .InclusiveBetween(1, 5);

        RuleForEach(x => x.Lines)
            .ChildRules(line =>
            {
                line.RuleFor(x => x.Quantity)
                    .InclusiveBetween(1, 10);
            });
    }
}
