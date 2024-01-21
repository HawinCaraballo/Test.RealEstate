// ***********************************************************************
// Assembly         : Test.RealEstate.Application.Feature.ImageProperty.Commands.CreateImageProperty
// Author           : Hawin Caraballo
// Created          : 15-01-2024
//
// Last Modified By : 
// Last Modified On : 
// ***********************************************************************
// <copyright file="CreatePropertyImageCommand.cs">
//     Copyright (c) All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace Test.RealEstate.Application.Feature.ImageProperty.Commands.CreateImageProperty
{
    using MediatR;
    using Test.RealEstate.Application.Behaviours;
    public class CreatePropertyImageCommand : IRequest<Response>
    {
        public int IdProperty { get; set; }
        public byte[] File { get; set; } = new byte[0];
        public string FileName { get; set; } = string.Empty;
        public bool Enabled { get; set; }
    }
}
