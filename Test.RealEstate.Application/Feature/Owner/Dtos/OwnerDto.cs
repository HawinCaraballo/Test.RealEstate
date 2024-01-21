// ***********************************************************************
// Assembly         : Test.RealEstate.Application.Feature.Owner.Dtos
// Author           : Hawin Caraballo
// Created          : 15-01-2024
//
// Last Modified By : 
// Last Modified On : 
// ***********************************************************************
// <copyright file="OwnerDto.cs">
//     Copyright (c) All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace Test.RealEstate.Application.Feature.Owner.Dtos
{
    public class OwnerDto
    {
        public int IdOwner { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string? Photo { get; set; }
        public DateOnly? Birthday { get; set; }
    }
}
