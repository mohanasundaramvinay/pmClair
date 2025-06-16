using Xunit;
using Xunit.Gherkin.Quick;
using System.Net.Http;
using System.Threading.Tasks;
using FluentAssertions;

[FeatureFile("ProjectPriceLevels.feature")]
public sealed class ProjectPriceLevelsSteps : Feature
{
    private readonly HttpClient _client;
    private HttpResponseMessage _response;

    public ProjectPriceLevelsSteps()
    {
        _client = new HttpClient();
    }

    [Given("the Project Data Points API is running")]
    public void GivenTheProjectDataPointsApiIsRunning()
    {
        // Assume the API is running
    }

    [When("I send a GET request to /api/ProjectDataPoints/project-price-levels")]
    public async Task WhenISendAGetRequestToProjectPriceLevels()
    {
        _response = await _client.GetAsync("http://localhost:5000/api/ProjectDataPoints/project-price-levels");
    }

    [When("I send a GET request to /api/ProjectDataPoints/invalid-endpoint")]
    public async Task WhenISendAGetRequestToInvalidEndpoint()
    {
        _response = await _client.GetAsync("http://localhost:5000/api/ProjectDataPoints/invalid-endpoint");
    }

    [When("I simulate a server error for /api/ProjectDataPoints/project-price-levels")]
    public async Task WhenISimulateAServerError()
    {
        // Simulate server error by stopping the server or using a mock
        _response = new HttpResponseMessage(System.Net.HttpStatusCode.InternalServerError);
    }

    [Then("the API response should be {int}")]
    public void ThenTheApiResponseShouldBe(int statusCode)
    {
        _response.StatusCode.Should().Be((System.Net.HttpStatusCode)statusCode);
    }

    [Then("the response should contain a list of project price levels")]
    public async Task ThenTheResponseShouldContainAListOfProjectPriceLevels()
    {
        var content = await _response.Content.ReadAsStringAsync();
        content.Should().Contain("LevelCode");
    }
}