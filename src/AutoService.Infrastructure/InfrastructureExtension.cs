using AutoService.Domain.Interfaces;
using AutoService.Infrastructure.Communication.CustomerService;
using AutoService.Infrastructure.Communication.DTOs;
using AutoService.Infrastructure.Communication.PaymentService;
using AutoService.Infrastructure.Facade;
using AutoService.Infrastructure.Facade.MethodsPayments;
using AutoService.Infrastructure.Factory;
using AutoService.Infrastructure.Persistence;
using AutoService.Infrastructure.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AutoService.Infrastructure
{
    public static class InfrastructureExtension
    {
        public static IServiceCollection AddInfra(this IServiceCollection services, IConfiguration configuration)
        {
            var connection = "";

            services.AddDbContext<AutoServiceDbContext>(x => x.UseMySql(connection, ServerVersion.AutoDetect(connection), (options) =>
            {
                options.MaxBatchSize(100);
                options.CommandTimeout(100);
                options.EnableRetryOnFailure();
            }));


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
