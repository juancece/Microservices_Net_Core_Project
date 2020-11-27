using PricingService.Domain;

namespace PricingService.Init
{
    public class DataLoader
    {
        private ITariffRepository allTariffs;

        public DataLoader(ITariffRepository allTariffs)
        {
            this.allTariffs = allTariffs;
        }

        public void Seed()
        {
            allTariffs.Add(DemoTariffFactory.Travel());
        }
    }
}