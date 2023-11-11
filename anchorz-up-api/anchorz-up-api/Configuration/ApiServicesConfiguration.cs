namespace AnchorzUp.Api.Configuration
{
    public static class ApiServicesConfiguration
    {
        public static IServiceCollection AddApiServices(this IServiceCollection services, IConfiguration configuration)
        {
            var domainUrl = configuration.GetSection("DomainUrl").Get<DomainUrl>();
            services.AddSingleton(ServiceProvider => domainUrl);
            return services;
        }
    }
}
