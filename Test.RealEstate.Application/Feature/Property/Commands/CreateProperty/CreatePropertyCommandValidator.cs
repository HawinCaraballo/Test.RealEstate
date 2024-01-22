// ***********************************************************************
// Assembly         : Test.RealEstate.Application.Feature.Property.Commands.CreateProperty
// Author           : Hawin Caraballo
// Created          : 15-01-2024
//
// Last Modified By : 
// Last Modified On : 
// ***********************************************************************
// <copyright file="CreatePropertyCommandValidator.cs">
//     Copyright (c) All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace Test.RealEstate.Application.Feature.Property.Commands.CreateProperty
{
    using FluentValidation;

    public class CreatePropertyCommandValidator : AbstractValidator<CreatePropertyCommand>
    {
        public CreatePropertyCommandValidator()
        {
            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("Name cannot be empty")
                .NotNull().WithMessage("Name cannot be null");

            RuleFor(p => p.Address)
                .NotEmpty().WithMessage("Address cannot be empty")
                .NotNull().WithMessage("Address cannot be null");

            RuleFor(p => p.Price)
                .NotNull().WithMessage("Price cannot be null");

            RuleFor(p => p.Year)
                .GreaterThan(0).WithMessage("Year cannot be zero (0)")
                .NotNull().WithMessage("Year cannot be null");

            RuleFor(p => p.IdOwner)
                .GreaterThan(0).WithMessage("IdOwner cannot be zero (0)")
                .NotNull().WithMessage("IdOwner cannot be null");
        }
    }
}
