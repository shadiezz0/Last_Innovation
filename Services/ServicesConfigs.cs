using Core.Interfaces;
using Core.Models;
using Infrastructure;
using Infrastructure.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Services
{
    public static class ServicesConfigs
    {
        public static void LoadServicesConfigration(this IServiceCollection services, IConfiguration configuration)
        {
            InfraConfigrations.LoadInfraConfigration(services,configuration);
            services.AddScoped<IUnitOfWork, UnitOfWork>();

        }
    }
}
