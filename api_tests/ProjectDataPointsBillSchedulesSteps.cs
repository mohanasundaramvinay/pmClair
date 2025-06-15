using Xunit;
using Xunit.Gherkin.Quick;
using System.Net.Http;
using System.Threading.Tasks;
using FluentAssertions;

[FeatureFile("ProjectDataPointsBillSchedules.feature")]
public sealed class ProjectDataPointsBillSchedulesSteps : Feature
{
    private readonly HttpClient _client;
    private HttpResponseMessage _response;

    public ProjectDataPointsBillSchedulesSteps()
    {
        _client = new HttpClient();
        _client.BaseAddress = new System.Uri("http://localhost:5000");
    }

    [Given("I have access to the Project Data Points API")]
    public void GivenIHaveAccessToTheProjectDataPointsAPI()
    {
        // Assume access is granted
    }

    [When("I send a GET request to /api/ProjectDataPoints/bill-schedules")]
    public async Task WhenISendAGETRequestToApiProjectDataPointsBillSchedules()
    {
        _response = await _client.GetAsync("/api/ProjectDataPoints/bill-schedules");
    }

    [Then("the API response should be (.*)")]
    public void ThenTheAPIResponseShouldBe(int statusCode)
    {
        _response.StatusCode.Should().Be((System.Net.HttpStatusCode)statusCode);
    }

    [Then("the response should contain a list of bill schedules")]
    public async Task ThenTheResponseShouldContainAListOfBillSchedules()
    {
        var content = await _response.Content.ReadAsStringAsync();
        content.Should().NotBeNullOrEmpty();
        // Further validation of the content structure can be added here
    }

    [Then("the response should contain an error message")]
    public async Task ThenTheResponseShouldContainAnErrorMessage()
    {
        var content = await _response.Content.ReadAsStringAsync();
        content.Should().Contain("error");
    }
}