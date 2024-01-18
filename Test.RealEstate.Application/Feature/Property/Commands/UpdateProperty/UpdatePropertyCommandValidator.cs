
namespace Test.RealEstate.Application.Feature.Property.Commands.UpdateProperty
{
    using FluentValidation;
    using Test.RealEstate.Application.Feature.Property.Commands.CreateProperty;
    public class UpdatePropertyCommandValidator : AbstractValidator<CreatePropertyCommand>
    {
        public UpdatePropertyCommandValidator()
        {
            RuleFor(p => p.Name)
                .NotNull().WithMessage("Name cannot be null");

            RuleFor(p => p.Address)
                .NotNull().WithMessage("Address cannot be null");

            RuleFor(p => p.Price)
                .NotNull().WithMessage("Price cannot be null");

            RuleFor(p => p.CodeInternal)
                .NotNull().WithMessage("CodeInternal cannot be null");

            RuleFor(p => p.Year)
                .NotNull().WithMessage("Year cannot be null");

            RuleFor(p => p.IdOwner)
                .NotNull().WithMessage("IdOwner cannot be null");
        }
    }
}
