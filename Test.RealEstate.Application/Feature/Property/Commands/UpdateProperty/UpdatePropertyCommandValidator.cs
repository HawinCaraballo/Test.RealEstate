
namespace Test.RealEstate.Application.Feature.Property.Commands.UpdateProperty
{
    using FluentValidation;
    using Test.RealEstate.Application.Feature.Property.Commands.CreateProperty;
    public class UpdatePropertyCommandValidator : AbstractValidator<UpdatePropertyCommand>
    {
        public UpdatePropertyCommandValidator()
        {
            RuleFor(p => p.IdProperty)
                .NotNull().WithMessage("Name cannot be null");
        }
    }
}
