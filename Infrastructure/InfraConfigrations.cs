using Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure
{
    public static class InfraConfigrations
    {
        public static void LoadInfraConfigration(this IServiceCollection services, IConfiguration configuration)
        {
            // Context Class Configration
            services.AddDbContext<InnovationDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
        }
    }
}
