using Xunit;
using Xunit.Gherkin.Quick;
using System.Net.Http;
using System.Threading.Tasks;
using FluentAssertions;

[FeatureFile("FavoriteProjects.feature")]
public sealed class FavoriteProjectsSteps : Feature
{
    private readonly HttpClient _client;
    private HttpResponseMessage _response;

    public FavoriteProjectsSteps()
    {
        _client = new HttpClient();
        _client.BaseAddress = new System.Uri("http://localhost:5000");
    }

    [Given("I have access to the ProjectDataPoints API")]
    public void GivenIHaveAccessToTheProjectDataPointsAPI()
    {
        // Assume access is granted
    }

    [Given("the user has no favorite projects")]
    public void GivenTheUserHasNoFavoriteProjects()
    {
        // Setup mock or database to ensure no favorite projects
    }

    [Given("the server is down")]
    public void GivenTheServerIsDown()
    {
        // Simulate server down scenario
    }

    [When("I send a GET request to /api/ProjectDataPoints/favorite-projects")]
    public async Task WhenISendAGETRequestToApiProjectDataPointsFavoriteProjects()
    {
        _response = await _client.GetAsync("/api/ProjectDataPoints/favorite-projects");
    }

    [Then("the API response should be a list of favorite projects with status code (.*)")]
    public async Task ThenTheAPIResponseShouldBeAListOfFavoriteProjectsWithStatusCode(int statusCode)
    {
        _response.StatusCode.Should().Be((System.Net.HttpStatusCode)statusCode);
        var content = await _response.Content.ReadAsStringAsync();
        content.Should().NotBeNullOrEmpty();
    }

    [Then("the API response should be an empty list with status code (.*)")]
    public async Task ThenTheAPIResponseShouldBeAnEmptyListWithStatusCode(int statusCode)
    {
        _response.StatusCode.Should().Be((System.Net.HttpStatusCode)statusCode);
        var content = await _response.Content.ReadAsStringAsync();
        content.Should().Be("[]");
    }

    [Then("the API response should be an error message with status code (.*)")]
    public void ThenTheAPIResponseShouldBeAnErrorMessageWithStatusCode(int statusCode)
    {
        _response.StatusCode.Should().Be((System.Net.HttpStatusCode)statusCode);
    }
}