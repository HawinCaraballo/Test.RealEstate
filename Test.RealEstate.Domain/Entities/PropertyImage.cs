// ***********************************************************************
// Assembly         : Test.RealEstate.Domain.Entities
// Author           : Hawin Caraballo
// Created          : 15-01-2024
//
// Last Modified By : 
// Last Modified On : 
// ***********************************************************************
// <copyright file="PropertyImage.cs">
//     Copyright (c) All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace Test.RealEstate.Domain.Entities
{
    using Test.RealEstate.Domain.Common;
    public class PropertyImage : BaseEntity
    {
        public int IdPropertyImage { get; set; }
        public int IdProperty { get; set; }
        public byte[] File { get; set; } = [];
        public bool Enabled { get; set; }
        public string FileName { get; set; } = string.Empty;
        public virtual Property IdPropertyNavigation { get; set; } = null!;
    }
}
