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
            services.AddScoped<IPropertyRepository, PropertyRepository>();
            services.AddScoped<IPropertyImageRepository, PropertyImageRepository>();
            services.AddScoped<IOwnerRepository, OwnerRepository>();

            return services;
        }
    }
}
