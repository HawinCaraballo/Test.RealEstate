// ***********************************************************************
// Assembly         : Test.RealEstate.Domain.Entities
// Author           : Hawin Caraballo
// Created          : 15-01-2024
//
// Last Modified By : 
// Last Modified On : 
// ***********************************************************************
// <copyright file="Owner.cs">
//     Copyright (c) All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace Test.RealEstate.Domain.Entities
{
    using Test.RealEstate.Domain.Common;
    public class Owner : BaseEntity
    {
        public int IdOwner { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string? Photo { get; set; }
        public DateOnly? Birthday { get; set; }
        public virtual ICollection<Property> Properties { get; set; } = new List<Property>();
    }
}
