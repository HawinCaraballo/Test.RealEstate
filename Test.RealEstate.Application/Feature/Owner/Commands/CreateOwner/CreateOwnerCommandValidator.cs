// ***********************************************************************
// Assembly         : Test.RealEstate.Application.Feature.Owner.Commands.CreateOwner
// Author           : Hawin Caraballo
// Created          : 15-01-2024
//
// Last Modified By : 
// Last Modified On : 
// ***********************************************************************
// <copyright file="CreateOwnerCommandValidator.cs">
//     Copyright (c) All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace Test.RealEstate.Application.Feature.Owner.Commands.CreateOwner
{
    using FluentValidation;
    public class CreateOwnerCommandValidator : AbstractValidator<CreateOwnerCommand>
    {
        public CreateOwnerCommandValidator() 
        {
            RuleFor(p => p.Name)
                .Empty().WithMessage("Name cannot be empty")
                .NotNull().WithMessage("Name cannot be null");

            RuleFor(p => p.Address)
                .Empty().WithMessage("Address cannot be empty")
                .NotNull().WithMessage("Address cannot be null");
        }
    }
}
