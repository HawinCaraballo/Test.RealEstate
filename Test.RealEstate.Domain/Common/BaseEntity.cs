// ***********************************************************************
// Assembly         : Test.RealEstate.Domain.Common
// Author           : Hawin Caraballo
// Created          : 15-01-2024
//
// Last Modified By : 
// Last Modified On : 
// ***********************************************************************
// <copyright file="BaseEntity.cs">
//     Copyright (c) All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace Test.RealEstate.Domain.Common
{
    public abstract class BaseEntity
    {
        public string? CreatedBy { get; set; } 
        public DateTime? Created { get; set; }
        public string? LastModifiedBy { get; set; } 
        public DateTime? LastModified { get; set; }
    }
}
