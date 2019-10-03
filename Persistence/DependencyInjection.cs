using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Kwaffeur.Application.Common.Interfaces;

namespace Kwaffeur.Persistence
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<KwaffeurDbContext>(options =>
              //  options.UseSqlServer(configuration.GetConnectionString("KwaffeurDatabase")));
              options.UseSqlite("Data Source=kwaffeur.db"));
            services.AddScoped<IKwaffeurDbContext>(provider => provider.GetService<KwaffeurDbContext>());

            return services;
        }
    }
}
