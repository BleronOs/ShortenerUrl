using AnchorzUp.Core.Interfaces;
using AnchorzUp.Core.Services;
using AnchorzUp.Infrastructure.Data;

namespace AnchorzUp.Api.Configuration
{
    public static class CoreServicesConfigration
    {
        public static IServiceCollection AddCoreServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped(typeof(IAsyncRepository<>), typeof(AnchorzUpRepository<>));
            services.AddScoped<IShortenerUrlService, ShortenerUrlService>();
            return services;
        }
    }
}
