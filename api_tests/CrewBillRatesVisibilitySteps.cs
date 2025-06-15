using Xunit;
using Xunit.Gherkin.Quick;
using System.Net.Http;
using System.Threading.Tasks;
using FluentAssertions;

[FeatureFile("CrewBillRatesVisibility.feature")]
public sealed class CrewBillRatesVisibilitySteps : Feature
{
    private readonly HttpClient _client;
    private HttpResponseMessage _response;

    public CrewBillRatesVisibilitySteps()
    {
        _client = new HttpClient();
        _client.BaseAddress = new System.Uri("http://localhost:5000");
    }

    [Given("I have access to the ProjectDataPoints API")]
    public void GivenIHaveAccessToTheProjectDataPointsAPI()
    {
        // Assume access is granted
    }

    [When("I send a GET request to /api/ProjectDataPoints/crew-bill-rates-visibility")]
    public async Task WhenISendAGETRequestToApiProjectDataPointsCrewBillRatesVisibility()
    {
        _response = await _client.GetAsync("/api/ProjectDataPoints/crew-bill-rates-visibility");
    }

    [Then("the API response should be {int}")]
    public void ThenTheAPIResponseShouldBe(int statusCode)
    {
        _response.StatusCode.Should().Be((System.Net.HttpStatusCode)statusCode);
    }

    [And("the response should contain visibility settings for the user role {string}")]
    public async Task AndTheResponseShouldContainVisibilitySettingsForTheUserRole(string userRole)
    {
        var content = await _response.Content.ReadAsStringAsync();
        content.Should().Contain(userRole);
    }
}