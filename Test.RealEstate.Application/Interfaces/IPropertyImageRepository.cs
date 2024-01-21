// ***********************************************************************
// Assembly         : Test.RealEstate.Application.Interfaces
// Author           : Hawin Caraballo
// Created          : 15-01-2024
//
// Last Modified By : 
// Last Modified On : 
// ***********************************************************************
// <copyright file="IPropertyImageRepository.cs">
//     Copyright (c) All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace Test.RealEstate.Application.Interfaces
{
    using Test.RealEstate.Domain.Entities;
    public interface IPropertyImageRepository : IAsyncRepository<PropertyImage>
    {
    }
}
