// ***********************************************************************
// Assembly         : Test.RealEstate.Application.Feature.Property.Commands.UpdateProperty
// Author           : Hawin Caraballo
// Created          : 15-01-2024
//
// Last Modified By : 
// Last Modified On : 
// ***********************************************************************
// <copyright file="UpdatePropertyCommandValidator.cs">
//     Copyright (c) All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace Test.RealEstate.Application.Feature.Property.Commands.UpdateProperty
{
    using FluentValidation;    
    public class UpdatePropertyCommandValidator : AbstractValidator<UpdatePropertyCommand>
    {
        public UpdatePropertyCommandValidator()
        {
            RuleFor(p => p.IdProperty)
                .GreaterThan(0).WithMessage("IdProperty cannot be zero (0)")
                .NotNull().WithMessage("Name cannot be null");
        }
    }
}
