// ***********************************************************************
// Assembly         : Test.RealEstate.Infraestructure.Identity.Configurations
// Author           : Hawin Caraballo
// Created          : 21-01-2024
//
// Last Modified By : 
// Last Modified On : 
// ***********************************************************************
// <copyright file="UserRoleConfiguration.cs">
//     Copyright (c) All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace Test.RealEstate.Infraestructure.Identity.Configurations
{
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    public class UserRoleConfiguration : IEntityTypeConfiguration<IdentityUserRole<string>>
    {
        public void Configure(EntityTypeBuilder<IdentityUserRole<string>> builder)
        {
            builder.HasData(new IdentityUserRole<string>
            {
                RoleId = "ae996865-2dc7-4daf-a1c3-55f62774c622",
                UserId = "74a9570a-5b44-4799-aade-d7560ab83428"
            },
            new IdentityUserRole<string>
            {
                RoleId = "16a4ea03-893c-498d-a886-553a044211c6",
                UserId = "fc5b7bfd-538d-46fe-adc3-ecf448ede70d"
            });
        }
    }
}
