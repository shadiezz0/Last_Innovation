using Core.Interfaces.InterfacesPages;
using Core.Models;
using Infrastructure.Contexts;
using Infrastructure.Repositories.ReposPages;
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

            services.AddScoped<IUser, UserRepos>();
            services.AddScoped<IAbout, AboutRepos>();
            services.AddScoped<IContact, ContactRepos>();
            services.AddScoped<IMyServices , MyServiceRepos>();
            services.AddScoped<ISlider , SliderRepos>();
            services.AddScoped<ITeam , TeamRepos>();
            services.AddScoped<IWork, WorkRepos>();

        }
    }
}
