using Xunit.Gherkin.Quick;
using System.Net.Http;
using System.Threading.Tasks;
using FluentAssertions;

[FeatureFile("CurrenciesAPI.feature")]
public sealed class CurrenciesAPISteps : Feature
{
    private readonly HttpClient _client;
    private HttpResponseMessage _response;

    public CurrenciesAPISteps()
    {
        _client = new HttpClient();
    }

    [Given("the API is running")]
    public void GivenTheAPIIsRunning()
    {
        // Assume the API is running
    }

    [Given("the server is down")]
    public void GivenTheServerIsDown()
    {
        // Simulate server down scenario
        _client.BaseAddress = new System.Uri("http://localhost:9999");
    }

    [When("I send a GET request to /api/ProjectDataPoints/currencies")]
    public async Task WhenISendAGetRequestToCurrencies()
    {
        _response = await _client.GetAsync("http://localhost:5000/api/ProjectDataPoints/currencies");
    }

    [When("I send a GET request to /api/ProjectDataPoints/currencies-invalid")]
    public async Task WhenISendAGetRequestToInvalidCurrencies()
    {
        _response = await _client.GetAsync("http://localhost:5000/api/ProjectDataPoints/currencies-invalid");
    }

    [Then("the API response should be (.*)")]
    public void ThenTheAPIResponseShouldBe(int statusCode)
    {
        _response.StatusCode.Should().Be((System.Net.HttpStatusCode)statusCode);
    }

    [Then("the response should contain a list of currencies")]
    public async Task ThenTheResponseShouldContainAListOfCurrencies()
    {
        var content = await _response.Content.ReadAsStringAsync();
        content.Should().Contain("CurrencyCode");
    }
}