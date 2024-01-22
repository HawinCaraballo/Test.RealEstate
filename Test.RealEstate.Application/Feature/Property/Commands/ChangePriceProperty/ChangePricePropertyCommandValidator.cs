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
                .GreaterThan(0).WithMessage("IdProperty cannot be zero (0)")
                .NotNull().WithMessage("IdProperty cannot be null");

            RuleFor(p => p.Price)
                .GreaterThan(0).WithMessage("Price cannot be zero (0)")
                .NotNull().WithMessage("Price cannot be null");

        }
    }
}
