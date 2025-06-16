using Xunit.Gherkin.Quick;
using System.Net.Http;
using System.Threading.Tasks;
using FluentAssertions;

[FeatureFile("ExpensePeriodTypes.feature")]
public sealed class ExpensePeriodTypesSteps : Feature
{
    private readonly HttpClient _client;
    private HttpResponseMessage _response;

    public ExpensePeriodTypesSteps()
    {
        _client = new HttpClient();
    }

    [Given("the API is running and accessible")]
    public void GivenTheApiIsRunningAndAccessible()
    {
        // Assume the API is running and accessible
    }

    [Given("the server is down")]
    public void GivenTheServerIsDown()
    {
        // Simulate server down scenario
        _client.BaseAddress = new System.Uri("http://localhost:9999");
    }

    [When("I send a GET request to /api/ProjectDataPoints/expense-period-types")]
    public async Task WhenISendAGetRequestToExpensePeriodTypes()
    {
        _response = await _client.GetAsync("http://localhost:5000/api/ProjectDataPoints/expense-period-types");
    }

    [When("I send a GET request to /api/ProjectDataPoints/invalid-endpoint")]
    public async Task WhenISendAGetRequestToInvalidEndpoint()
    {
        _response = await _client.GetAsync("http://localhost:5000/api/ProjectDataPoints/invalid-endpoint");
    }

    [Then("the API response should be (.*)")]
    public void ThenTheApiResponseShouldBe(int statusCode)
    {
        _response.StatusCode.Should().Be((System.Net.HttpStatusCode)statusCode);
    }

    [Then("the response should contain a list of expense period types")]
    public async Task ThenTheResponseShouldContainAListOfExpensePeriodTypes()
    {
        var content = await _response.Content.ReadAsStringAsync();
        content.Should().Contain("PeriodTypeCode");
    }
}