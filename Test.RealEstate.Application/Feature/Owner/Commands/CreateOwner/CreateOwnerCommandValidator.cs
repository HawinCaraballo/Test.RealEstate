using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.RealEstate.Application.Feature.Owner.Commands.CreateOwner
{
    public class CreateOwnerCommandValidator : AbstractValidator<CreateOwnerCommand>
    {
        public CreateOwnerCommandValidator() 
        {
            RuleFor(p => p.Name)
                .NotNull().WithMessage("Name cannot be null");

            RuleFor(p => p.Address)
                .NotNull().WithMessage("Address cannot be null");
        }
    }
}
