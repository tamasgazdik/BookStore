using Microsoft.Extensions.DependencyInjection;

namespace BookStore.Application.Commands
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddMediatR(this IServiceCollection services)
        {
            services.AddMediatR(config =>
            {
                config.Lifetime = ServiceLifetime.Scoped;
                config.RegisterServicesFromAssembly(AssemblyReference.Assembly);
            });

            return services;
        }
    }
}
