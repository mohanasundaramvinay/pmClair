using Xunit.Gherkin.Quick;
using System.Net.Http;
using System.Threading.Tasks;
using FluentAssertions;

[FeatureFile("BidSummaryFeature.feature")]
public sealed class BidSummarySteps : Feature
{
    private readonly HttpClient _client;
    private HttpResponseMessage _response;

    public BidSummarySteps()
    {
        _client = new HttpClient();
        _client.BaseAddress = new System.Uri("http://localhost:5000/api/");
    }

    [When("I send a GET request to /api/projects/(.*)/bid-summary")]
    public async Task WhenISendAGetRequestToApiProjectsEntityNoBidSummary(string entityNo)
    {
        _response = await _client.GetAsync($"projects/{entityNo}/bid-summary");
    }

    [Then("the API response should be (\d+)")]
    public void ThenTheApiResponseShouldBe(int statusCode)
    {
        _response.StatusCode.Should().Be((System.Net.HttpStatusCode)statusCode);
    }

    [Then("the response should contain a list of bid summaries")]
    public async Task ThenTheResponseShouldContainAListOfBidSummaries()
    {
        var content = await _response.Content.ReadAsStringAsync();
        content.Should().NotBeNullOrEmpty();
        // Further validation of the content structure can be added here
    }
}