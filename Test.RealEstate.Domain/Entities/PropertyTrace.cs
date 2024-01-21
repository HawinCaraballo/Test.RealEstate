// ***********************************************************************
// Assembly         : Test.RealEstate.Domain.Entities
// Author           : Hawin Caraballo
// Created          : 15-01-2024
//
// Last Modified By : 
// Last Modified On : 
// ***********************************************************************
// <copyright file="PropertyTrace.cs">
//     Copyright (c) All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace Test.RealEstate.Domain.Entities
{
    using Test.RealEstate.Domain.Common;
    public class PropertyTrace : BaseEntity
    {
        public int IdPropertyTrace { get; set; }
        public DateTime DateSale { get; set; }
        public string Name { get; set; } = null!;
        public double Value { get; set; }
        public double Tax { get; set; }
        public int IdProperty { get; set; }
        public virtual Property IdPropertyNavigation { get; set; }

    }
}
