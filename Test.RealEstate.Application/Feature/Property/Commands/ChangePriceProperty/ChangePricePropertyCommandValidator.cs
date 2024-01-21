// ***********************************************************************
// Assembly         : Test.RealEstate.Application.Feature.Property.Commands.ChangePriceProperty
// Author           : Hawin Caraballo
// Created          : 15-01-2024
//
// Last Modified By : 
// Last Modified On : 
// ***********************************************************************
// <copyright file="ChangePricePropertyCommandValidator.cs">
//     Copyright (c) All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace Test.RealEstate.Application.Feature.Property.Commands.ChangePriceProperty
{
    using FluentValidation;    
    public class ChangePricePropertyCommandValidator : AbstractValidator<ChangePricePropertyCommand>
    {
        
        public ChangePricePropertyCommandValidator()
        {
            RuleFor(p => p.IdProperty)
                .GreaterThanOrEqualTo(0).WithMessage("IdProperty invalid")
                .NotNull().WithMessage("IdProperty cannot be null");

            RuleFor(p => p.Price)
                .GreaterThanOrEqualTo(0).WithMessage("Price invalid")
                .NotNull().WithMessage("Price cannot be null");

        }
    }
}
