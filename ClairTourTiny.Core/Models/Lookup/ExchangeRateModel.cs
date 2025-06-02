namespace ClairTourTiny.Core.Models.Lookup
{
    public class ExchangeRateModel
    {
        public string Currency { get; set; } = null!;

        public DateTime Startdate { get; set; }

        public DateTime? Enddate { get; set; }

        public double Ratetodollars { get; set; }
    }
}
