// ***********************************************************************
// Assembly         : Test.RealEstate.Infraestructure.Identity.Configurations
// Author           : Hawin Caraballo
// Created          : 21-01-2024
//
// Last Modified By : 
// Last Modified On : 
// ***********************************************************************
// <copyright file="RoleConfiguration.cs">
//     Copyright (c) All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace Test.RealEstate.Infraestructure.Identity.Configurations
{
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    public class RoleConfiguration : IEntityTypeConfiguration<IdentityRole>
    {
        public void Configure(EntityTypeBuilder<IdentityRole> builder)
        {
            builder.HasData(new IdentityRole
            {
                Id= "ae996865-2dc7-4daf-a1c3-55f62774c622",
                Name = "Administrator",
                NormalizedName = "ADMINISTRATOR",
            },
            new IdentityRole
            {
                Id = "16a4ea03-893c-498d-a886-553a044211c6",
                Name = "Operator",
                NormalizedName = "OPERATOR",
            });
        }
    }
}
