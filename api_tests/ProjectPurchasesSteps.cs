using Xunit.Gherkin.Quick;
using System.Net.Http;
using System.Threading.Tasks;
using FluentAssertions;

[FeatureFile("ProjectPurchases.feature")]
public sealed class ProjectPurchasesSteps : Feature
{
    private readonly HttpClient _client = new HttpClient();
    private HttpResponseMessage _response;

    [Given("I have access to the Project Maintenance API")]
    public void GivenIHaveAccessToTheProjectMaintenanceAPI()
    {
        _client.BaseAddress = new System.Uri("http://localhost:5000");
    }

    [When("I send a GET request to /api/projects/(.*)/purchases")]
    public async Task WhenISendAGETRequestToApiProjectsEntityNoPurchases(string entityNo)
    {
        _response = await _client.GetAsync($"/api/projects/{entityNo}/purchases");
    }

    [Then("the API response should be (\d+)")]
    public void ThenTheAPIResponseShouldBe(int statusCode)
    {
        _response.StatusCode.Should().Be((System.Net.HttpStatusCode)statusCode);
    }

    [Then("the response should contain a list of purchases")]
    public async Task ThenTheResponseShouldContainAListOfPurchases()
    {
        var content = await _response.Content.ReadAsStringAsync();
        content.Should().NotBeNullOrEmpty();
        // Further assertions can be added here to validate the structure of the response
    }
}