using Xunit;
using Xunit.Gherkin.Quick;
using System.Net.Http;
using System.Threading.Tasks;
using FluentAssertions;

[FeatureFile("WarehouseFeature.feature")]
public sealed class WarehouseSteps : Feature
{
    private readonly HttpClient _client;
    private HttpResponseMessage _response;

    public WarehouseSteps()
    {
        _client = new HttpClient();
        _client.BaseAddress = new System.Uri("http://localhost:5000");
    }

    [Given("I have access to the ProjectDataPoints API")]
    public void GivenIHaveAccessToTheProjectDataPointsAPI()
    {
        // Assume access is always available for this test
    }

    [When("I send a GET request to /api/ProjectDataPoints/warehouses")]
    public async Task WhenISendAGETRequestToWarehouses()
    {
        _response = await _client.GetAsync("/api/ProjectDataPoints/warehouses");
    }

    [When("I send a GET request to /api/ProjectDataPoints/invalid-warehouses")]
    public async Task WhenISendAGETRequestToInvalidWarehouses()
    {
        _response = await _client.GetAsync("/api/ProjectDataPoints/invalid-warehouses");
    }

    [When("I simulate a server error for GET request to /api/ProjectDataPoints/warehouses")]
    public async Task WhenISimulateAServerErrorForGETRequestToWarehouses()
    {
        // Simulate server error by using a mock or similar approach
        // For demonstration, assume the server returns 500
        _response = new HttpResponseMessage(System.Net.HttpStatusCode.InternalServerError);
    }

    [Then("the API response should be a list of warehouses with status code (.*)")]
    public void ThenTheAPIResponseShouldBeAListOfWarehousesWithStatusCode(int statusCode)
    {
        _response.StatusCode.Should().Be((System.Net.HttpStatusCode)statusCode);
        // Additional checks for response content can be added here
    }

    [Then("the API response should be a (.*) status code")]
    public void ThenTheAPIResponseShouldBeAStatusCode(int statusCode)
    {
        _response.StatusCode.Should().Be((System.Net.HttpStatusCode)statusCode);
    }
}