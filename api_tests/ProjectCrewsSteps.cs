using Xunit.Gherkin.Quick;
using System.Net.Http;
using System.Threading.Tasks;
using FluentAssertions;

[FeatureFile("ProjectCrews.feature")]
public sealed class ProjectCrewsSteps : Feature
{
    private readonly HttpClient _client = new HttpClient();
    private HttpResponseMessage _response;

    [When("I send a GET request to /api/projects/(.*)/crews")]
    public async Task WhenISendAGetRequestToApiProjectsCrews(string entityNo)
    {
        var url = $"http://localhost:5000/api/projects/{entityNo}/crews";
        _response = await _client.GetAsync(url);
    }

    [Then("the API response should be (\d+)")]
    public void ThenTheApiResponseShouldBe(int statusCode)
    {
        _response.StatusCode.Should().Be((System.Net.HttpStatusCode)statusCode);
    }

    [Then("the response should contain a list of crews")]
    public async Task ThenTheResponseShouldContainAListOfCrews()
    {
        var content = await _response.Content.ReadAsStringAsync();
        content.Should().NotBeNullOrEmpty();
        // Further validation of the JSON structure can be added here
    }
}