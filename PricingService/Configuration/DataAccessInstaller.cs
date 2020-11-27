using Microsoft.Extensions.DependencyInjection;
using PricingService.DataAccess;
using PricingService.Domain;

namespace PricingService.Configuration
{
    public static class DataAccessInstaller
    {
        public static IServiceCollection AddPricingDataAccess(this IServiceCollection services)
        {
            services.AddSingleton<ITariffRepository, InMemoryTariffRepository>();
            return services;
        }
    }
}