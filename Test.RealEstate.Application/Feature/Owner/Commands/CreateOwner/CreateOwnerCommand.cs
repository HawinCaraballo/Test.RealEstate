// ***********************************************************************
// Assembly         : Test.RealEstate.Application.Feature.ImageProperty.Dtos
// Author           : Hawin Caraballo
// Created          : 15-01-2024
//
// Last Modified By : 
// Last Modified On : 
// ***********************************************************************
// <copyright file="PropertyImageDto.cs">
//     Copyright (c) All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace Test.RealEstate.Application.Feature.Owner.Commands.CreateOwner
{
    using MediatR;
    using Test.RealEstate.Application.Behaviours;
    public class CreateOwnerCommand : IRequest<Response>
    {
        public string Name { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string? Photo { get; set; }
        public DateOnly? Birthday { get; set; }
    }
}
