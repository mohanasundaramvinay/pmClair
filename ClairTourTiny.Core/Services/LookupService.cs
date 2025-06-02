using ClairTourTiny.Core.Interfaces;
using ClairTourTiny.Core.Models.Lookup;
using ClairTourTiny.Infrastructure;

namespace ClairTourTiny.Core.Services
{
    public class LookupService : ILookupService
    {
        private readonly ClairTourTinyContext _clairTourTinyContext;

        public LookupService(ClairTourTinyContext clairTourTinyContext)
        {
            _clairTourTinyContext = clairTourTinyContext;
        }

        public List<ExchangeRateModel> GetExchangeRates()
        {
            return _clairTourTinyContext.ExchangeRateBooks.Select(exRate => new ExchangeRateModel()
            {
                Currency = exRate.Currency,
                Enddate = exRate.Enddate,
                Ratetodollars = exRate.Ratetodollars,
                Startdate = exRate.Startdate
            }).ToList();
        }
    }
}
