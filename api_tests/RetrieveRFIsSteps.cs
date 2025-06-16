using Xunit.Gherkin.Quick;
using System.Net.Http;
using System.Threading.Tasks;
using FluentAssertions;

[FeatureFile("RetrieveRFIs.feature")]
public sealed class RetrieveRFIsSteps : Feature
{
    private readonly HttpClient _client = new HttpClient();
    private HttpResponseMessage _response;

    [Given("I have access to the Project Maintenance API")]
    public void GivenIHaveAccessToTheProjectMaintenanceAPI()
    {
        _client.BaseAddress = new System.Uri("http://localhost:5000/api/");
    }

    [When("I send a GET request to /api/projects/(.*)/rfis")]
    public async Task WhenISendAGETRequestToApiProjectsEntityNoRfis(string entityNo)
    {
        _response = await _client.GetAsync($"projects/{entityNo}/rfis");
    }

    [Then("the API response should be a list of RFIs with status code (.*)")]
    public void ThenTheAPIResponseShouldBeAListOfRFIsWithStatusCode(int statusCode)
    {
        _response.StatusCode.Should().Be((System.Net.HttpStatusCode)statusCode);
        // Additional checks for response content can be added here
    }

    [Then("the API response should be an error with status code (.*)")]
    public void ThenTheAPIResponseShouldBeAnErrorWithStatusCode(int statusCode)
    {
        _response.StatusCode.Should().Be((System.Net.HttpStatusCode)statusCode);
    }
}