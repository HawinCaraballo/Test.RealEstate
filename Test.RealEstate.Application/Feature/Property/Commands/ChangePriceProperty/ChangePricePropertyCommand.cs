// ***********************************************************************
// Assembly         : Test.RealEstate.Application.Feature.Property.Commands.ChangePriceProperty
// Author           : Hawin Caraballo
// Created          : 15-01-2024
//
// Last Modified By : 
// Last Modified On : 
// ***********************************************************************
// <copyright file="ChangePricePropertyCommand.cs">
//     Copyright (c) All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace Test.RealEstate.Application.Feature.Property.Commands.ChangePriceProperty
{
    using MediatR;
    using Test.RealEstate.Application.Behaviours;
    public class ChangePricePropertyCommand : IRequest<Response>
    {
        public int IdProperty { get; set; }
        public double Price { get; set; }
    }
}
