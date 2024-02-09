using AutoService.Core.Web.Configuration;
using AutoService.Payment.Domain.Repositories;
using AutoService.Payment.Infrastructure.BackgroundJobs;
using AutoService.Payment.Infrastructure.Communication;
using AutoService.Payment.Infrastructure.Facade;
using AutoService.Payment.Infrastructure.Factory;
using AutoService.Payment.Infrastructure.Persistence;
using EasyNetQ;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AutoService.Payment.Infrastructure
{
    public static class InfrastructureExtension
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<PaymentConfig>(configuration.GetSection("PaymentConfig"));

            var connectionString = configuration.GetConnectionString("DatabaseMysql");

            services.AddDbContext<PaymentDbContext>(x =>
                 x.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));

            //services.AddScoped<HttpClient>();
            services.AddScoped<PaymentPix>();
            services.AddScoped<IPaymentCommunicationService, PaymentCommunicationService>();
            services.AddScoped<ICustomerCommunicationService, CustomerCommunicationService>();
            services.AddScoped<IPaymentFactory, PaymentFactory>();
            services.AddScoped<IPaymentRepository, PaymentRepository>();
            services.AddHostedService<ProcessPaymentBackgroundService>();
            
            services.AddAuthJwt(configuration);

            return services;
        }
    }
}
