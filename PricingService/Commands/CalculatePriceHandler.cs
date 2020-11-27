using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using FluentValidation;
using MediatR;
using PricingService.Api.Commands;
using PricingService.Domain;

namespace PricingService.Commands
{
    public class CalculatePriceHandler : IRequestHandler<CalculatePriceCommand, CalculatePriceResult>
    {
        private ITariffRepository allTariffs;
        private CalculatePriceCommandValidator commandValidator = new CalculatePriceCommandValidator();

        public CalculatePriceHandler(ITariffRepository allTariffs)
        {
            this.allTariffs = allTariffs;
        }

        public async Task<CalculatePriceResult> Handle(CalculatePriceCommand cmd, CancellationToken cancellationToken)
        {
            commandValidator.ValidateAndThrow(cmd);
            
            var tariff = allTariffs.WithCode(cmd.ProductCode);

            var calculation = tariff.CalculatePrice(ToCalculation(cmd));

            return ToResult(calculation);
        }

        private Calculation ToCalculation(CalculatePriceCommand cmd)
        {
            return new Calculation(
                cmd.ProductCode,
                cmd.PolicyFrom,
                cmd.PolicyTo,
                cmd.SelectedCovers,
                cmd.Answers.ToDictionary(a => a.QuestionCode, a=> a.GetAnswer()));
        }

        private CalculatePriceResult ToResult(Calculation calculation)
        {
            return new CalculatePriceResult
            {
                TotalPrice = calculation.TotalPremium,
                CoverPrices = calculation.Covers.ToDictionary(c => c.Key, c => c.Value.Price)
            };
        }
        
    }
}