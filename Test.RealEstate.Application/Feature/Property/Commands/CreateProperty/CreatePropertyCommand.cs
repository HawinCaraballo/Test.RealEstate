// ***********************************************************************
// Assembly         : Test.RealEstate.Application.Feature.Property.Commands.CreateProperty
// Author           : Hawin Caraballo
// Created          : 15-01-2024
//
// Last Modified By : 
// Last Modified On : 
// ***********************************************************************
// <copyright file="CreatePropertyCommand.cs">
//     Copyright (c) All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace Test.RealEstate.Application.Feature.Property.Commands.CreateProperty
{
    using MediatR;
    using Test.RealEstate.Application.Behaviours;

    public class CreatePropertyCommand : IRequest<Response>
    {
        public string Name { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public double Price { get; set; }
        public string CodeInternal { get; set; } = string.Empty;
        public int Year { get; set; }
        public int IdOwner { get; set; }
    }
}
