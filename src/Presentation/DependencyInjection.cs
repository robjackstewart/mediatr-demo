using Application.Common.Interfaces;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;

namespace Presentation
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPresentation(this IServiceCollection services)
        {
            services.AddSwaggerDocument();

            services.AddHealthChecks();

            services.AddHttpContextAccessor();

            services
                .AddMvc()
                .AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<IMediatRDemoDbContext>());

            return services;
        }
    }
}
