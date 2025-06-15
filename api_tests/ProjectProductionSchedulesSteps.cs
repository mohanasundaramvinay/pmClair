using Xunit;
using Xunit.Gherkin.Quick;
using System.Net.Http;
using System.Threading.Tasks;
using FluentAssertions;

[FeatureFile("ProjectProductionSchedules.feature")]
public sealed class ProjectProductionSchedulesSteps : Feature
{
    private readonly HttpClient _client;
    private HttpResponseMessage _response;

    public ProjectProductionSchedulesSteps()
    {
        _client = new HttpClient { BaseAddress = new System.Uri("http://localhost:5000") };
    }

    [When("I send a GET request to /api/projects/(.*)/production-schedules")]
    public async Task WhenISendAGetRequestToApiProjectsProductionSchedules(string entityNo)
    {
        _response = await _client.GetAsync($"/api/projects/{entityNo}/production-schedules");
    }

    [Then("the API response should be (\d+)")]
    public void ThenTheApiResponseShouldBe(int statusCode)
    {
        _response.StatusCode.Should().Be((System.Net.HttpStatusCode)statusCode);
    }

    [Then("the response should contain a list of production schedules")]
    public async Task ThenTheResponseShouldContainAListOfProductionSchedules()
    {
        var content = await _response.Content.ReadAsStringAsync();
        content.Should().NotBeNullOrEmpty();
        // Further validation of the content structure can be added here
    }
}