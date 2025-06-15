using Xunit.Gherkin.Quick;
using System.Net.Http;
using System.Threading.Tasks;
using FluentAssertions;

[FeatureFile("ProjectBillingPeriods.feature")]
public sealed class ProjectBillingPeriodsSteps : Feature
{
    private readonly HttpClient _client = new HttpClient();
    private HttpResponseMessage _response;

    [Given("I have access to the Project Maintenance API")]
    public void GivenIHaveAccessToTheProjectMaintenanceAPI()
    {
        _client.BaseAddress = new System.Uri("http://localhost:5000/api/");
    }

    [When("I send a GET request to /api/projects/(.*)/billing-periods")]
    public async Task WhenISendAGETRequestToApiProjectsEntityNoBillingPeriods(string entityNo)
    {
        _response = await _client.GetAsync($"projects/{entityNo}/billing-periods");
    }

    [Then("the API response should be (\d+)")]
    public void ThenTheAPIResponseShouldBe(int statusCode)
    {
        _response.StatusCode.Should().Be((System.Net.HttpStatusCode)statusCode);
    }

    [Then("the response should contain a list of billing periods")]
    public async Task ThenTheResponseShouldContainAListOfBillingPeriods()
    {
        var content = await _response.Content.ReadAsStringAsync();
        content.Should().NotBeNullOrEmpty();
        // Further validation of the content structure can be added here
    }
}