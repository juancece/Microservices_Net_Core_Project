namespace PricingService.Domain
{
    public interface ITariffRepository
    {
        Tariff WithCode(string code);

        void Add(Tariff tariff);
    }
}