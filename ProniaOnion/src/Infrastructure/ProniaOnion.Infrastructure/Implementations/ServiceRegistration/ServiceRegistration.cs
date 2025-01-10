using Microsoft.Extensions.DependencyInjection;
using ProniaOnion.Application.Abstractions;
using ProniaOnion.Infrastructure.Implementations.Services;

namespace ProniaOnion.Infrastructure.Implementations.ServiceRegistration
{
    public static class ServiceRegistration
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
        {
            services.AddScoped<ITokenHandler, TokenHandler>();
            return services;
        }
    }
}
