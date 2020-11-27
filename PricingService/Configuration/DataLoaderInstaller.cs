using Microsoft.Extensions.DependencyInjection;
using PricingService.Init;

namespace PricingService.Configuration
{
    public static class DataLoaderInstaller
    {
        public static IServiceCollection AddPricingDemoInitializer(this IServiceCollection services)
        {
            services.AddSingleton<DataLoader>();
            return services;
        }
    }
}