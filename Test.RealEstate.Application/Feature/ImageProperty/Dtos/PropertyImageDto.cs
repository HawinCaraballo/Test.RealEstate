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
namespace Test.RealEstate.Application.Feature.ImageProperty.Dtos
{
    public class PropertyImageDto
    {
        public int IdPropertyImage { get; set; }
        public int IdProperty { get; set; }
        public byte[] File { get; set; } = new byte[0];
        public string FileName { get; set; } = string.Empty;
        public bool Enabled { get; set; }
    }
}
