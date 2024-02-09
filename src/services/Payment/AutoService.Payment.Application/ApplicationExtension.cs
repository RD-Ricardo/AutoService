using AutoService.Payment.Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace AutoService.Payment.Application
{
    public static class ApplicationExtension
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddScoped<IPaymentService, PaymentService>();

            return services;
        }
    }
}
