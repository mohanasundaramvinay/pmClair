using Xunit.Gherkin.Quick;
using System.Net.Http;
using System.Threading.Tasks;
using FluentAssertions;
using Newtonsoft.Json.Linq;

[FeatureFile("PollstarArtistsSearch.feature")]
public sealed class PollstarArtistsSearchSteps : Feature
{
    private readonly HttpClient _client = new HttpClient();
    private HttpResponseMessage _response;
    private JArray _responseContent;

    [Given("I have access to the Pollstar artists API")]
    public void GivenIHaveAccessToThePollstarArtistsAPI()
    {
        _client.BaseAddress = new System.Uri("http://localhost:5000");
    }

    [When("I send a GET request to /api/ProjectDataPoints/pollstar-artists/search with searchTerm \"(.*)\"")]
    public async Task WhenISendAGETRequestToApiProjectDataPointsPollstarArtistsSearchWithSearchTerm(string searchTerm)
    {
        _response = await _client.GetAsync($"/api/ProjectDataPoints/pollstar-artists/search?searchTerm={searchTerm}");
        var content = await _response.Content.ReadAsStringAsync();
        _responseContent = JArray.Parse(content);
    }

    [Then("the API response should be (\d+)")]
    public void ThenTheAPIResponseShouldBe(int statusCode)
    {
        _response.StatusCode.Should().Be((System.Net.HttpStatusCode)statusCode);
    }

    [And("the response should contain (\d+) artists")]
    public void AndTheResponseShouldContainArtists(int expectedCount)
    {
        _responseContent.Count.Should().Be(expectedCount);
    }
}