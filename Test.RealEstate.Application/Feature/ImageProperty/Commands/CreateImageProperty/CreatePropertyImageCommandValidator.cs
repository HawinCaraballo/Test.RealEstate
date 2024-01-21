// ***********************************************************************
// Assembly         : Test.RealEstate.Application.Feature.ImageProperty.Commands.CreateImageProperty
// Author           : Hawin Caraballo
// Created          : 15-01-2024
//
// Last Modified By : 
// Last Modified On : 
// ***********************************************************************
// <copyright file="CreatePropertyImageCommandValidator.cs">
//     Copyright (c) All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

namespace Test.RealEstate.Application.Feature.ImageProperty.Commands.CreateImageProperty
{
    using FluentValidation;
    public class CreatePropertyImageCommandValidator : AbstractValidator<CreatePropertyImageCommand>
    {
        public CreatePropertyImageCommandValidator() {
            RuleFor(p => p.IdProperty)
                .GreaterThanOrEqualTo(0).WithMessage("IdProperty invalid")
                .NotNull().WithMessage("IdProperty cannot be null");

            RuleFor(p => p.File)
                .NotNull().WithMessage("File cannot be null");
        }
    }
}
