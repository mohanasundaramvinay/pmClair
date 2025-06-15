using Xunit;
using Xunit.Gherkin.Quick;
using System.Net.Http;
using System.Threading.Tasks;
using FluentAssertions;

[FeatureFile("ProjectPhases.feature")]
public sealed class ProjectPhasesSteps : Feature
{
    private readonly HttpClient _client;
    private HttpResponseMessage _response;

    public ProjectPhasesSteps()
    {
        _client = new HttpClient { BaseAddress = new System.Uri("http://localhost:5000") };
    }

    [When("I send a GET request to /api/projects/(.*)/phases")]
    public async Task WhenISendAGetRequestToApiProjectsEntityNoPhases(string entityNo)
    {
        _response = await _client.GetAsync($"/api/projects/{entityNo}/phases");
    }

    [Then("the API response should be (\d+)")]
    public void ThenTheApiResponseShouldBe(int statusCode)
    {
        _response.StatusCode.Should().Be((System.Net.HttpStatusCode)statusCode);
    }

    [Then("the response should contain a list of phases")]
    public async Task ThenTheResponseShouldContainAListOfPhases()
    {
        var content = await _response.Content.ReadAsStringAsync();
        content.Should().Contain("PhaseId");
    }
}