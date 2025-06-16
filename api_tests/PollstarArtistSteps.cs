using Xunit.Gherkin.Quick;
using System.Net.Http;
using System.Threading.Tasks;
using FluentAssertions;

[FeatureFile("PollstarArtistFeature.feature")]
public class PollstarArtistSteps : Feature
{
    private readonly HttpClient _client;
    private HttpResponseMessage _response;

    public PollstarArtistSteps()
    {
        _client = new HttpClient { BaseAddress = new System.Uri("http://localhost:5000") };
    }

    [When("I send a GET request to /api/ProjectDataPoints/pollstar-artists/(.*)")]
    public async Task WhenISendAGetRequestToApiProjectDataPointsPollstarArtists(string artistId)
    {
        _response = await _client.GetAsync($"/api/ProjectDataPoints/pollstar-artists/{artistId}");
    }

    [Then("the API response should be (.*)")]
    public void ThenTheApiResponseShouldBe(int statusCode)
    {
        _response.StatusCode.Should().Be((System.Net.HttpStatusCode)statusCode);
    }

    [And("the response should contain the artist details if (.*) is 200")]
    public async Task AndTheResponseShouldContainTheArtistDetailsIfIs200(int statusCode)
    {
        if (statusCode == 200)
        {
            var content = await _response.Content.ReadAsStringAsync();
            content.Should().Contain("Id").And.Contain("Name").And.Contain("Genre");
        }
    }
}