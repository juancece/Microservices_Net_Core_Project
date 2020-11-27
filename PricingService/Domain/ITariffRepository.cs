namespace PricingService.Domain
{
    public interface ITariffRepository
    {
        Tariff WithCode(string code);

        bool Exists(string code);
        
        void Add(Tariff tariff);
    }
}