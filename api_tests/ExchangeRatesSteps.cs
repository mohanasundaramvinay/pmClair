using Xunit.Gherkin.Quick;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using FluentAssertions;

[FeatureFile("ExchangeRatesFeature.feature")]
public class ExchangeRatesSteps : Feature
{
    private readonly HttpClient _client;
    private HttpResponseMessage _response;

    public ExchangeRatesSteps()
    {
        _client = new HttpClient { BaseAddress = new System.Uri("http://localhost:5000") };
    }

    [When("I send a GET request to /api/lookup/exchange-rates")]
    public async Task WhenISendAGetRequestToApiLookupExchangeRates()
    {
        _response = await _client.GetAsync("/api/lookup/exchange-rates");
    }

    [Then("the API response should be a list of exchange rates with status code (.*)")]
    public void ThenTheApiResponseShouldBeAListOfExchangeRatesWithStatusCode(int statusCode)
    {
        _response.StatusCode.Should().Be((HttpStatusCode)statusCode);
        _response.Content.Headers.ContentType.MediaType.Should().Be("application/json");
    }

    [Then("the API response should be an error with status code (.*)")]
    public void ThenTheApiResponseShouldBeAnErrorWithStatusCode(int statusCode)
    {
        _response.StatusCode.Should().Be((HttpStatusCode)statusCode);
    }
}