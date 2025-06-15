using Xunit.Gherkin.Quick;
using System.Net.Http;
using System.Threading.Tasks;
using FluentAssertions;

[FeatureFile("ProjectPartBids.feature")]
public sealed class ProjectPartBidsSteps : Feature
{
    private readonly HttpClient _client = new HttpClient();
    private HttpResponseMessage _response;

    [When("I send a GET request to /api/projects/(.*)/part-bids")]
    public async Task WhenISendAGetRequestToApiProjectsEntityNoPartBids(string entityNo)
    {
        _response = await _client.GetAsync($"http://localhost:5000/api/projects/{entityNo}/part-bids");
    }

    [Then("the API response should be (.*)")]
    public void ThenTheApiResponseShouldBe(int statusCode)
    {
        _response.StatusCode.Should().Be((System.Net.HttpStatusCode)statusCode);
    }

    [Then("the response should contain a list of part bids")]
    public async Task ThenTheResponseShouldContainAListOfPartBids()
    {
        var content = await _response.Content.ReadAsStringAsync();
        content.Should().StartWith("[");
        content.Should().EndWith("]");
    }
}