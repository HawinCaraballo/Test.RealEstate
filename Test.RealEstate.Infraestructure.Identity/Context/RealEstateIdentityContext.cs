// ***********************************************************************
// Assembly         : Test.RealEstate.Infraestructure.Identity.Context
// Author           : Hawin Caraballo
// Created          : 21-01-2024
//
// Last Modified By : 
// Last Modified On : 
// ***********************************************************************
// <copyright file="RealEstateIdentityContext.cs">
//     Copyright (c) All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace Test.RealEstate.Infraestructure.Identity.Context
{
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;
    using Test.RealEstate.Infraestructure.Identity.Configurations;
    using Test.RealEstate.Infraestructure.Identity.Models;
    public class RealEstateIdentityContext : IdentityDbContext<ApplicationUser>
    {
        public RealEstateIdentityContext(DbContextOptions<RealEstateIdentityContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfiguration(new RoleConfiguration());
            builder.ApplyConfiguration(new UserConfiguration());
            builder.ApplyConfiguration(new UserRoleConfiguration());
        }
    }
}
