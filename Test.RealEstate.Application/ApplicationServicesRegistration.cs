
namespace Test.RealEstate.Application
{
    using FluentValidation;
    using global::System.Reflection;
    using MediatR;
    using Microsoft.Extensions.DependencyInjection;
    using Test.RealEstate.Application.Behaviours;

    public static class ApplicationServicesRegistration
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));


            return services;
        }
    }
}
