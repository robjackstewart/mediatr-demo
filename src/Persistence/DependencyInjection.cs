using Application.Common.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Persistence
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<MediatRDemoDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("MediatRDemo")));

            services.AddScoped<IMediatRDemoDbContext>(provider => provider.GetService<MediatRDemoDbContext>());

            return services;
        }
    }
}
