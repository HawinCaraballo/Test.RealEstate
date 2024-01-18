namespace Test.RealEstate.Application.Feature.ImageProperty.Commands.CreateImageProperty
{
    using FluentValidation;
    public class CreatePropertyImageCommandValidator : AbstractValidator<CreatePropertyImageCommand>
    {
        public CreatePropertyImageCommandValidator() {
            RuleFor(p => p.IdProperty)
                .NotNull().WithMessage("IdProperty cannot be null");

            RuleFor(p => p.File)
                .NotNull().WithMessage("File cannot be null");
        }
    }
}
