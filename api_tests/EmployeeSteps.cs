using Xunit.Gherkin.Quick;
using System.Net.Http;
using System.Threading.Tasks;
using FluentAssertions;

[FeatureFile("EmployeeFeature.feature")]
public sealed class EmployeeSteps : Feature
{
    private readonly HttpClient _client;
    private HttpResponseMessage _response;

    public EmployeeSteps()
    {
        _client = new HttpClient();
        _client.BaseAddress = new System.Uri("http://localhost:5000");
    }

    [When("I send a GET request to /api/ProjectDataPoints/employees")]
    public async Task WhenISendAGetRequestToEmployees()
    {
        _response = await _client.GetAsync("/api/ProjectDataPoints/employees");
    }

    [When("I send a GET request to /api/ProjectDataPoints/invalid-endpoint")]
    public async Task WhenISendAGetRequestToInvalidEndpoint()
    {
        _response = await _client.GetAsync("/api/ProjectDataPoints/invalid-endpoint");
    }

    [When("I simulate a server error for GET /api/ProjectDataPoints/employees")]
    public async Task WhenISimulateAServerErrorForEmployees()
    {
        // Simulate server error by sending a request to a known failing endpoint
        _response = await _client.GetAsync("/api/ProjectDataPoints/employees?simulateError=true");
    }

    [Then("the API response should be (.*)")]
    public void ThenTheApiResponseShouldBe(int statusCode)
    {
        _response.StatusCode.Should().Be((System.Net.HttpStatusCode)statusCode);
    }

    [Then("the response should contain a list of employees")]
    public async Task ThenTheResponseShouldContainAListOfEmployees()
    {
        var content = await _response.Content.ReadAsStringAsync();
        content.Should().Contain("employeeId");
        content.Should().Contain("name");
    }
}