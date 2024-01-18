
namespace Test.RealEstate.Application.Feature.Property.Commands.ChangePriceProperty
{
    using FluentValidation;
    public class ChangePricePropertyCommandValidator : AbstractValidator<ChangePricePropertyCommand>
    {
        public ChangePricePropertyCommandValidator() {
            RuleFor(p => p.IdProperty)
                .NotNull().WithMessage("IdProperty cannot be null");

            RuleFor(p => p.Price)
                .NotNull().WithMessage("Price cannot be null");
        }
    }
}
