using Xunit.Gherkin.Quick;
using System.Net.Http;
using System.Threading.Tasks;
using FluentAssertions;
using Newtonsoft.Json.Linq;

[FeatureFile("ExchangeRatesAPI.feature")]
public class ExchangeRatesAPISteps : Feature
{
    private HttpResponseMessage _response;
    private readonly HttpClient _client = new HttpClient();

    [Given("the Exchange Rates API is running")]
    public void GivenTheExchangeRatesAPIIsRunning()
    {
        // Assume the API is running and accessible
    }

    [When("I send a GET request to /api/lookup/exchange-rates")]
    public async Task WhenISendAGetRequestToApiLookupExchangeRates()
    {
        _response = await _client.GetAsync("http://localhost:5000/api/lookup/exchange-rates");
    }

    [Then("the API response should be a list of exchange rates with status code (.*)")]
    public async Task ThenTheApiResponseShouldBeAListOfExchangeRatesWithStatusCode(int statusCode)
    {
        _response.StatusCode.Should().Be((System.Net.HttpStatusCode)statusCode);
        var content = await _response.Content.ReadAsStringAsync();
        JArray.Parse(content).Should().NotBeEmpty();
    }

    [Then("the API response should be an error with status code (.*)")]
    public void ThenTheApiResponseShouldBeAnErrorWithStatusCode(int statusCode)
    {
        _response.StatusCode.Should().Be((System.Net.HttpStatusCode)statusCode);
    }

    [Then("each exchange rate should have a CurrencyCode, ExchangeRate, and LastUpdated")]
    public async Task ThenEachExchangeRateShouldHaveACurrencyCodeExchangeRateAndLastUpdated()
    {
        var content = await _response.Content.ReadAsStringAsync();
        var exchangeRates = JArray.Parse(content);
        foreach (var rate in exchangeRates)
        {
            rate.Should().ContainKey("CurrencyCode");
            rate.Should().ContainKey("ExchangeRate");
            rate.Should().ContainKey("LastUpdated");
        }
    }
}