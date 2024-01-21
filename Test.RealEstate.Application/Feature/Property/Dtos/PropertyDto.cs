// ***********************************************************************
// Assembly         : Test.RealEstate.Application.Feature.Property.Dtos
// Author           : Hawin Caraballo
// Created          : 15-01-2024
//
// Last Modified By : 
// Last Modified On : 
// ***********************************************************************
// <copyright file="PropertyDto.cs">
//     Copyright (c) All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace Test.RealEstate.Application.Feature.Property.Dtos
{
    public class PropertyDto
    {
        public int IdProperty { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public double Price { get; set; }
        public string CodeInternal { get; set; } = string.Empty;
        public int Year { get; set; }
        public int IdOwner { get; set; }
    }
}
