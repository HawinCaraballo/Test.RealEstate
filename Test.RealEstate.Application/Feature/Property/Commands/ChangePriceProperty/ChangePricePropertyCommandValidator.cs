
namespace Test.RealEstate.Application.Feature.Property.Commands.ChangePriceProperty
{
    using FluentValidation;
    using Test.RealEstate.Application.Interfaces;

    public class ChangePricePropertyCommandValidator : AbstractValidator<ChangePricePropertyCommand>
    {
        private readonly IPropertyRepository repository;
        public ChangePricePropertyCommandValidator(IPropertyRepository propertyRepository)
        {
            this.repository = propertyRepository;

            RuleFor(p => p.IdProperty)
                .NotNull()
                .GreaterThanOrEqualTo(0)   
                .WithMessage("IdProperty cannot be null");

            RuleFor(p => p.Price)
                .NotNull()
                .GreaterThanOrEqualTo(0)
                .WithMessage("Price cannot be null");

            RuleFor(p => p.Mensaje)
                .NotEmpty()
                .WithMessage("no se permite mensaje vacio.");
        }
    }
}
