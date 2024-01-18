namespace Test.RealEstate.Application.Feature.Property.Commands.CreateProperty
{
    using FluentValidation;

    public class CreatePropertyCommandValidator : AbstractValidator<CreatePropertyCommand>
    {
        public CreatePropertyCommandValidator()
        {
            RuleFor(p => p.Name)
                .NotNull().NotEmpty().WithMessage("Name cannot be null");

            RuleFor(p => p.Address)
                .NotNull().NotEmpty().WithMessage("Address cannot be null");

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
