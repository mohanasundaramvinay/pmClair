using Xunit.Gherkin.Quick;
using System.Net.Http;
using System.Threading.Tasks;
using FluentAssertions;

[FeatureFile("ProjectMaintenanceAssignedCrews.feature")]
public class ProjectMaintenanceAssignedCrewsSteps : Feature
{
    private readonly HttpClient _client;
    private HttpResponseMessage _response;

    public ProjectMaintenanceAssignedCrewsSteps()
    {
        _client = new HttpClient();
        _client.BaseAddress = new System.Uri("http://localhost:5000");
    }

    [When("I send a GET request to /api/projects/(.*)/assigned-crews")]
    public async Task WhenISendAGetRequestToApiProjectsAssignedCrews(string entityNo)
    {
        _response = await _client.GetAsync($"/api/projects/{entityNo}/assigned-crews");
    }

    [Then("the API response should be (.*)")]
    public void ThenTheApiResponseShouldBe(int statusCode)
    {
        _response.StatusCode.Should().Be((System.Net.HttpStatusCode)statusCode);
    }

    [Then("the response should contain a list of assigned crews")]
    public async Task ThenTheResponseShouldContainAListOfAssignedCrews()
    {
        var content = await _response.Content.ReadAsStringAsync();
        content.Should().StartWith("[");
        content.Should().EndWith("]");
    }

    [Then("the response should be an empty list")]
    public async Task ThenTheResponseShouldBeAnEmptyList()
    {
        var content = await _response.Content.ReadAsStringAsync();
        content.Should().Be("[]");
    }
}