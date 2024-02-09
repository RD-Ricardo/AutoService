using AutoService.Core.Web.Configuration;
using AutoService.ProfessionalAccount.Domain.Interfaces;
using AutoService.ProfessionalAccount.Infrastructure.Persistence;
using AutoService.ProfessionalAccount.Infrastructure.Persistence.Repostiories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AutoService.ProfessionalAccount.Infrastructure
{
    public static class InfrastructureExtenstion
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
           var connectionString = configuration.GetConnectionString("DatabaseMysql");

           services.AddDbContext<ProfessionalAccountDbContext>(x =>
                x.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));

            services.AddScoped<IProfessionalRepository, ProfessionalRepository>();

            services.AddAuthJwt(configuration);

            return services;
        }
    }
}
