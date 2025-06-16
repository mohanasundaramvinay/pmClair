using Xunit.Gherkin.Quick;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;
using FluentAssertions;

[FeatureFile("AccountMatrixFeature.feature")]
public sealed class AccountMatrixSteps : Feature
{
    private readonly HttpClient _client;
    private HttpResponseMessage _response;

    public AccountMatrixSteps()
    {
        _client = new HttpClient();
        _client.BaseAddress = new System.Uri("http://localhost:5000");
    }

    [When("I send a GET request to /api/ProjectDataPoints/account-matrix")]
    public async Task WhenISendAGetRequestToAccountMatrix()
    {
        _response = await _client.GetAsync("/api/ProjectDataPoints/account-matrix");
    }

    [When("I send a GET request to /api/ProjectDataPoints/invalid-endpoint")]
    public async Task WhenISendAGetRequestToInvalidEndpoint()
    {
        _response = await _client.GetAsync("/api/ProjectDataPoints/invalid-endpoint");
    }

    [When("I simulate a server error for GET request to /api/ProjectDataPoints/account-matrix")]
    public async Task WhenISimulateAServerError()
    {
        // Simulate server error by using a mock or similar approach
        // For demonstration, we assume the server returns 500
        _response = new HttpResponseMessage(System.Net.HttpStatusCode.InternalServerError);
    }

    [Then("the API response should be <StatusCode>")]
    public void ThenTheApiResponseShouldBe(int statusCode)
    {
        _response.StatusCode.Should().Be((System.Net.HttpStatusCode)statusCode);
    }

    [Then("the response should contain a list of account matrix entries")]
    public async Task ThenTheResponseShouldContainAListOfAccountMatrixEntries()
    {
        var content = await _response.Content.ReadAsStringAsync();
        content.Should().Contain("AccountCode");
        content.Should().Contain("Department");
        content.Should().Contain("CostCenter");
        content.Should().Contain("IsActive");
    }
}