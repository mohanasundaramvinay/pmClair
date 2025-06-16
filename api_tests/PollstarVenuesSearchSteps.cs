using Xunit.Gherkin.Quick;
using System.Net.Http;
using System.Threading.Tasks;
using FluentAssertions;

[FeatureFile("PollstarVenuesSearch.feature")]
public sealed class PollstarVenuesSearchSteps : Feature
{
    private readonly HttpClient _client;
    private HttpResponseMessage _response;

    public PollstarVenuesSearchSteps()
    {
        _client = new HttpClient();
        _client.BaseAddress = new System.Uri("http://localhost:5000");
    }

    [When("I send a GET request to /api/ProjectDataPoints/pollstar-venues/search with searchTerm \"(.*)\"")]
    public async Task WhenISendAGetRequestToApiProjectDataPointsPollstarVenuesSearchWithSearchTerm(string searchTerm)
    {
        _response = await _client.GetAsync($"/api/ProjectDataPoints/pollstar-venues/search?searchTerm={searchTerm}");
    }

    [Then("the API response should be (\d+)")]
    public void ThenTheApiResponseShouldBe(int statusCode)
    {
        _response.StatusCode.Should().Be((System.Net.HttpStatusCode)statusCode);
    }

    [Then("the response should contain venues matching the search term \"(.*)\"")]
    public async Task ThenTheResponseShouldContainVenuesMatchingTheSearchTerm(string searchTerm)
    {
        var content = await _response.Content.ReadAsStringAsync();
        content.Should().Contain(searchTerm);
    }
}