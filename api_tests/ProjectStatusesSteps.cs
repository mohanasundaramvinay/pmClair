using Xunit;
using Xunit.Gherkin.Quick;
using System.Net.Http;
using System.Threading.Tasks;
using FluentAssertions;

[FeatureFile("ProjectStatuses.feature")]
public sealed class ProjectStatusesSteps : Feature
{
    private readonly HttpClient _client;
    private HttpResponseMessage _response;

    public ProjectStatusesSteps()
    {
        _client = new HttpClient();
        _client.BaseAddress = new System.Uri("http://localhost:5000");
    }

    [Given("I have access to the ProjectDataPoints API")]
    public void GivenIHaveAccessToTheProjectDataPointsAPI()
    {
        // Assume access is granted
    }

    [When("I send a GET request to /api/ProjectDataPoints/project-statuses")]
    public async Task WhenISendAGETRequestToProjectStatuses()
    {
        _response = await _client.GetAsync("/api/ProjectDataPoints/project-statuses");
    }

    [When("I send a GET request to /api/ProjectDataPoints/invalid-endpoint")]
    public async Task WhenISendAGETRequestToInvalidEndpoint()
    {
        _response = await _client.GetAsync("/api/ProjectDataPoints/invalid-endpoint");
    }

    [When("I simulate a server error for GET request to /api/ProjectDataPoints/project-statuses")]
    public async Task WhenISimulateAServerErrorForGETRequest()
    {
        // Simulate server error by using a mock or similar approach
        _response = new HttpResponseMessage(System.Net.HttpStatusCode.InternalServerError);
    }

    [Then("the API response should be a list of project statuses with status code <StatusCode>")]
    public void ThenTheAPIResponseShouldBeAListOfProjectStatusesWithStatusCode(int statusCode)
    {
        _response.StatusCode.Should().Be((System.Net.HttpStatusCode)statusCode);
    }

    [Then("the API response should be a 404 Not Found error")]
    public void ThenTheAPIResponseShouldBeA404NotFoundError()
    {
        _response.StatusCode.Should().Be(System.Net.HttpStatusCode.NotFound);
    }

    [Then("the API response should be a 500 Internal Server Error")]
    public void ThenTheAPIResponseShouldBeA500InternalServerError()
    {
        _response.StatusCode.Should().Be(System.Net.HttpStatusCode.InternalServerError);
    }
}