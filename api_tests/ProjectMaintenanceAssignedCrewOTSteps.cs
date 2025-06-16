using Xunit;
using Xunit.Gherkin.Quick;
using System.Net.Http;
using System.Threading.Tasks;
using FluentAssertions;

[FeatureFile("ProjectMaintenanceAssignedCrewOT.feature")]
public sealed class ProjectMaintenanceAssignedCrewOTSteps : Feature
{
    private readonly HttpClient _client;
    private HttpResponseMessage _response;

    public ProjectMaintenanceAssignedCrewOTSteps()
    {
        _client = new HttpClient();
        _client.BaseAddress = new System.Uri("http://localhost:5000");
    }

    [When("I send a GET request to /api/projects/(.*)/assigned-crew/ot")]
    public async Task WhenISendAGetRequestToApiProjectsEntityNoAssignedCrewOt(string entityNo)
    {
        _response = await _client.GetAsync($"/api/projects/{entityNo}/assigned-crew/ot");
    }

    [Then("the API response should be (.*)")]
    public void ThenTheApiResponseShouldBe(int statusCode)
    {
        _response.StatusCode.Should().Be((System.Net.HttpStatusCode)statusCode);
    }

    [And("the response should contain a list of assigned crew overtime data")]
    public async Task AndTheResponseShouldContainAListOfAssignedCrewOvertimeData()
    {
        var content = await _response.Content.ReadAsStringAsync();
        content.Should().NotBeNullOrEmpty();
        // Further validation of the content structure can be added here
    }
}