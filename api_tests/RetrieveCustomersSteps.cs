using Xunit;
using Xunit.Gherkin.Quick;
using System.Net.Http;
using System.Threading.Tasks;
using FluentAssertions;

[FeatureFile("RetrieveCustomers.feature")]
public sealed class RetrieveCustomersSteps : Feature
{
    private readonly HttpClient _client;
    private HttpResponseMessage _response;

    public RetrieveCustomersSteps()
    {
        _client = new HttpClient();
        _client.BaseAddress = new System.Uri("http://localhost:5000");
    }

    [Given("I have access to the ProjectDataPoints API")]
    public void GivenIHaveAccessToTheProjectDataPointsAPI()
    {
        // Assume access is granted
    }

    [When("I send a GET request to /api/ProjectDataPoints/customers")]
    public async Task WhenISendAGETRequestToApiProjectDataPointsCustomers()
    {
        _response = await _client.GetAsync("/api/ProjectDataPoints/customers");
    }

    [When("I send a GET request to /api/ProjectDataPoints/invalid-customers")]
    public async Task WhenISendAGETRequestToApiProjectDataPointsInvalidCustomers()
    {
        _response = await _client.GetAsync("/api/ProjectDataPoints/invalid-customers");
    }

    [When("I simulate a server error for GET /api/ProjectDataPoints/customers")]
    public async Task WhenISimulateAServerErrorForGETApiProjectDataPointsCustomers()
    {
        // Simulate server error by sending a request to a non-existent endpoint
        _response = await _client.GetAsync("/api/ProjectDataPoints/customers?simulateError=true");
    }

    [Then("the API response should be (.*)")]
    public void ThenTheAPIResponseShouldBe(int statusCode)
    {
        _response.StatusCode.Should().Be((System.Net.HttpStatusCode)statusCode);
    }

    [Then("the response should contain a list of customers")]
    public async Task ThenTheResponseShouldContainAListOfCustomers()
    {
        var content = await _response.Content.ReadAsStringAsync();
        content.Should().NotBeNullOrEmpty();
        // Further validation of the content can be done here
    }
}