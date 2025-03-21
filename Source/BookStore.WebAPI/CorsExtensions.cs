using Microsoft.EntityFrameworkCore;
using System.Text;

namespace BookStore.WebAPI
{
    internal static class CorsExtensions
    {
        private const string BOOK_STORE_CORS_POLICY = "BookStoreCorsPolicy";
        private static bool corsConfigurationIsFound;

        public static IServiceCollection AddCustomCors(this IServiceCollection serviceCollection, IConfiguration configuration)
        {
            var corsConfiguration = configuration.GetSection("Cors:AllowedOrigins").Get<string[]>();

            if (corsConfiguration is not null)
            {
                corsConfigurationIsFound = true;
                serviceCollection.AddCors(options =>
                    {
                        options.AddPolicy(BOOK_STORE_CORS_POLICY, policy =>
                        {
                            if (corsConfiguration.Contains("*"))
                            {
                                policy.AllowAnyOrigin();
                            }
                            else
                            {
                                policy.WithOrigins(corsConfiguration ?? []);
                            }
                            policy.AllowAnyMethod();
                            policy.AllowAnyHeader();
                        });
                    }); 
            }

            return serviceCollection;
        }

        public static IApplicationBuilder UseCustomCors(this IApplicationBuilder applicationBuilder)
        {
            if (corsConfigurationIsFound)
            {
                applicationBuilder.UseCors(BOOK_STORE_CORS_POLICY);
            }
            return applicationBuilder;
        }
    }
}
