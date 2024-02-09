using AutoService.ProfessionalAccount.Application.UseCases.ContractFullAccess;
using AutoService.ProfessionalAccount.Application.UseCases.LoginUser;
using AutoService.ProfessionalAccount.Application.UseCases.RegisterUser;
using Microsoft.Extensions.DependencyInjection;

namespace AutoService.ProfessionalAccount.Application
{
    public static class ApplicationExtension
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddScoped<UserLoginUseCase>();
            services.AddScoped<UserRegisterUseCase>();
            services.AddScoped<ContractFullAccessUseCase>();

            return services;
        }
    }
}
