// ***********************************************************************
// Assembly         : Test.RealEstate.Infraestructure.Persistence
// Author           : Hawin Caraballo
// Created          : 15-01-2024
//
// Last Modified By : 
// Last Modified On : 
// ***********************************************************************
// <copyright file="InfrastructureServiceRegistration.cs">
//     Copyright (c) All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace Test.RealEstate.Infraestructure.Persistence
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Test.RealEstate.Application.Interfaces;
    using Test.RealEstate.Infraestructure.Persistence.Context;
    using Test.RealEstate.Infraestructure.Persistence.Repositories;
    public static class InfrastructureServiceRegistration
    {
        public static IServiceCollection AddInfrastuctureServices(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            services.AddScoped(typeof(IAsyncRepository<>), typeof(RepositoryBase<>));
            services.AddTransient<IPropertyRepository, PropertyRepository>();
            services.AddTransient<IPropertyImageRepository, PropertyImageRepository>();
            services.AddTransient<IOwnerRepository, OwnerRepository>();

            return services;
        }
    }
}
