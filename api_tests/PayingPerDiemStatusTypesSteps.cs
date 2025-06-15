using Xunit;
using Xunit.Gherkin.Quick;
using System.Net.Http;
using System.Threading.Tasks;
using FluentAssertions;

[FeatureFile("PayingPerDiemStatusTypes.feature")]
public sealed class PayingPerDiemStatusTypesSteps : Feature
{
    private readonly HttpClient _client;
    private HttpResponseMessage _response;

    public PayingPerDiemStatusTypesSteps()
    {
        _client = new HttpClient();
        _client.BaseAddress = new System.Uri("http://localhost:5000");
    }

    [When("I send a GET request to /api/ProjectDataPoints/paying-per-diem-status-types")]
    public async Task WhenISendAGetRequestToApiProjectDataPointsPayingPerDiemStatusTypes()
    {
        _response = await _client.GetAsync("/api/ProjectDataPoints/paying-per-diem-status-types");
    }

    [Then("the API response should be (.*)")]
    public void ThenTheApiResponseShouldBe(int statusCode)
    {
        _response.StatusCode.Should().Be((System.Net.HttpStatusCode)statusCode);
    }

    [And("the response should contain a list of per diem status types")]
    public async Task AndTheResponseShouldContainAListOfPerDiemStatusTypes()
    {
        var content = await _response.Content.ReadAsStringAsync();
        content.Should().Contain("StatusCode");
        content.Should().Contain("Description");
    }

    [And("the response should contain an error message")]
    public async Task AndTheResponseShouldContainAnErrorMessage()
    {
        var content = await _response.Content.ReadAsStringAsync();
        content.Should().Contain("error");
    }
}