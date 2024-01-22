// ***********************************************************************
// Assembly         : Test.RealEstate.Infraestructure.Identity.Configurations
// Author           : Hawin Caraballo
// Created          : 21-01-2024
//
// Last Modified By : 
// Last Modified On : 
// ***********************************************************************
// <copyright file="UserConfiguration.cs">
//     Copyright (c) All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace Test.RealEstate.Infraestructure.Identity.Configurations
{
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using Test.RealEstate.Infraestructure.Identity.Models;
    public class UserConfiguration : IEntityTypeConfiguration<ApplicationUser>
    {
        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            var hasher = new PasswordHasher<ApplicationUser>();
            builder.HasData(new ApplicationUser
            {
                Id = "74a9570a-5b44-4799-aade-d7560ab83428",
                Email = "admin@RealEstate.com",
                NormalizedEmail = "admin@RealEstate.com",
                Name = "Admin",
                LastName = "Administrator",
                UserName = "Admin",
                NormalizedUserName = "Admin",
                PasswordHash = hasher.HashPassword(null, "admin2024$"),
                EmailConfirmed = true
            },
            new ApplicationUser
            {
                Id = "fc5b7bfd-538d-46fe-adc3-ecf448ede70d",
                Email = "MarioBaraco@RealEstate.com",
                NormalizedEmail = "MarioBaraco@RealEstate.com",
                Name = "Mario",
                LastName = "Baraco",
                UserName = "MarioBaraco",
                NormalizedUserName = "MarioBaraco",
                PasswordHash = hasher.HashPassword(null, "maba2024$"),
                EmailConfirmed = true
            });
        }
    }
}
