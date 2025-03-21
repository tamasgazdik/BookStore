using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace BookStore.Application.Validation
{
    public static class ServiceCollectionExtensions
    {
        public static void AddCustomValidators(this IServiceCollection services)
        {
            // validators can be added manually if FluentValidation's DI is not used
            // or multiple validators for the same type exist
            //services.AddScoped<IValidator<AddBookCommand>, AddBookCommandValidator>();
            //services.AddScoped<IValidator<ModifyBookCommand>, ModifyBookCommandValidator>();
                
            services.AddValidatorsFromAssembly(AssemblyReference.Assembly, ServiceLifetime.Scoped);
        }
    }
}
