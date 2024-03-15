using AutoService.Domain.Interfaces;
using AutoService.Infrastructure.Communication;
using AutoService.Infrastructure.Communication.CustomerService;
using AutoService.Infrastructure.Communication.PaymentService;
using AutoService.Infrastructure.Facade;
using AutoService.Infrastructure.Facade.MethodsPayments;
using AutoService.Infrastructure.Factory;
using AutoService.Infrastructure.Persistence;
using AutoService.Infrastructure.Persistence.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AutoService.Infrastructure
{
    public static class InfrastructureExtension
    {
        public static IServiceCollection AddInfra(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<AutoServiceDbContext>();

            // Payment services
            services.AddScoped<PaymentPix>();
            services.AddScoped<IPaymentCommunicationService, PaymentCommunicationService>();
            services.AddScoped<ICustomerCommunicationService, CustomerCommunicationService>();
            services.AddScoped<IProfessionalFacade, ProfessionalFacade>();
            services.AddScoped<IPaymentFactory, PaymentFactory>();


            //Repositories
            services.AddScoped<IPaymentRepository, PaymentRepository>();
            services.AddScoped<IProfessionalRepository, ProfessionalRepository>();
            services.AddScoped<IVehicleRepository, VehicleRepository>();
            services.AddScoped<IServiceRepository, ServiceRepository>();
            services.AddScoped<ICustomerRepository, CustomerRepository>();

            return services;
        }
    }
}
