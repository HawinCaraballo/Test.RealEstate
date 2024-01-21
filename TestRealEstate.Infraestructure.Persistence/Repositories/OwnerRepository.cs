// ***********************************************************************
// Assembly         : Test.RealEstate.Infraestructure.Persistence.Repositories
// Author           : Hawin Caraballo
// Created          : 15-01-2024
//
// Last Modified By : 
// Last Modified On : 
// ***********************************************************************
// <copyright file="OwnerRepository.cs">
//     Copyright (c) All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace Test.RealEstate.Infraestructure.Persistence.Repositories
{
    using Test.RealEstate.Application.Interfaces;
    using Test.RealEstate.Domain.Entities;
    using Test.RealEstate.Infraestructure.Persistence.Context;
    public class OwnerRepository : RepositoryBase<Owner>, IOwnerRepository
    {
        public OwnerRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
