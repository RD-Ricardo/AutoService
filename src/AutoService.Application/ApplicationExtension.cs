using AutoService.Application.Commands.Customer.CreateCustomer;
using AutoService.Core.Abstractions.Mediator;
using Microsoft.Extensions.DependencyInjection;

namespace AutoService.Application
{
    public static class ApplicationExtension
    {
        public static IServiceCollection AddServiceApplication(this IServiceCollection services)
        {
            services.AddMediatR(config =>
            {
                config.RegisterServicesFromAssembly(AppDomain.CurrentDomain.Load("AutoService.Application"));
            });

            services.AddScoped<IMediatorHandler, MediatorHandler>();

            return services;
        }
    }
}
