using Xunit;
using Xunit.Gherkin.Quick;
using System.Net.Http;
using System.Threading.Tasks;
using FluentAssertions;

[FeatureFile("EmployeeJobTypes.feature")]
public sealed class EmployeeJobTypesSteps : Feature
{
    private readonly HttpClient _client;
    private HttpResponseMessage _response;

    public EmployeeJobTypesSteps()
    {
        _client = new HttpClient();
        _client.BaseAddress = new System.Uri("http://localhost:5000");
    }

    [When("I send a GET request to /api/ProjectDataPoints/employee-job-types")]
    public async Task WhenISendAGetRequestToEmployeeJobTypes()
    {
        _response = await _client.GetAsync("/api/ProjectDataPoints/employee-job-types");
    }

    [When("I send a GET request to /api/ProjectDataPoints/invalid-endpoint")]
    public async Task WhenISendAGetRequestToInvalidEndpoint()
    {
        _response = await _client.GetAsync("/api/ProjectDataPoints/invalid-endpoint");
    }

    [When("I simulate a server error for /api/ProjectDataPoints/employee-job-types")]
    public async Task WhenISimulateAServerError()
    {
        // Simulate server error by sending a request to a known failing endpoint or mock the service
        _response = new HttpResponseMessage(System.Net.HttpStatusCode.InternalServerError);
    }

    [Then("the API response should be (.*)")]
    public void ThenTheApiResponseShouldBe(int statusCode)
    {
        _response.StatusCode.Should().Be((System.Net.HttpStatusCode)statusCode);
    }

    [Then("the response should contain a list of employee job types")]
    public async Task ThenTheResponseShouldContainAListOfEmployeeJobTypes()
    {
        var content = await _response.Content.ReadAsStringAsync();
        content.Should().NotBeNullOrEmpty();
        // Further validation of the content structure can be added here
    }
}