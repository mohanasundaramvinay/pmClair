using Xunit.Gherkin.Quick;
using System.Net.Http;
using System.Threading.Tasks;
using FluentAssertions;

[FeatureFile("PollstarArtists.feature")]
public sealed class PollstarArtistsSteps : Feature
{
    private readonly HttpClient _client = new HttpClient();
    private HttpResponseMessage _response;

    [Given("the Pollstar Artists API is available")]
    public void GivenThePollstarArtistsApiIsAvailable()
    {
        // Assume API is running and available
    }

    [Given("I am not authorized")]
    public void GivenIAmNotAuthorized()
    {
        // Simulate unauthorized access by not setting authorization headers
    }

    [When("I send a GET request to /api/ProjectDataPoints/pollstar-artists")]
    public async Task WhenISendAGetRequestToPollstarArtists()
    {
        _response = await _client.GetAsync("http://localhost:5000/api/ProjectDataPoints/pollstar-artists");
    }

    [When("I send a GET request to /api/ProjectDataPoints/pollstar-artist")]
    public async Task WhenISendAGetRequestToInvalidEndpoint()
    {
        _response = await _client.GetAsync("http://localhost:5000/api/ProjectDataPoints/pollstar-artist");
    }

    [When("I simulate a server error for GET /api/ProjectDataPoints/pollstar-artists")]
    public void WhenISimulateAServerError()
    {
        // Simulate server error by mocking or other means
    }

    [Then("the API response should be (.*)")]
    public void ThenTheApiResponseShouldBe(int statusCode)
    {
        _response.StatusCode.Should().Be(statusCode);
    }

    [Then("the response should contain a list of artists")]
    public async Task ThenTheResponseShouldContainAListOfArtists()
    {
        var content = await _response.Content.ReadAsStringAsync();
        content.Should().Contain("["); // Basic check for JSON array
    }

    [Then("the response should be an empty list")]
    public async Task ThenTheResponseShouldBeAnEmptyList()
    {
        var content = await _response.Content.ReadAsStringAsync();
        content.Should().Be("[]");
    }
}