using ClairTourTiny.Core.Models.Lookup;

namespace ClairTourTiny.Core.Interfaces
{
    public interface ILookupService
    {
        List<ExchangeRateModel> GetExchangeRates();
    }
}
