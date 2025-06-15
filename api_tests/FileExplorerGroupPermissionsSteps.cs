using Xunit.Gherkin.Quick;
using System.Net.Http;
using System.Threading.Tasks;
using FluentAssertions;

[FeatureFile("FileExplorerGroupPermissions.feature")]
public sealed class FileExplorerGroupPermissionsSteps : Feature
{
    private readonly HttpClient _client;
    private HttpResponseMessage _response;

    public FileExplorerGroupPermissionsSteps()
    {
        _client = new HttpClient();
        _client.BaseAddress = new System.Uri("http://localhost:5000");
    }

    [When("I send a GET request to /api/FileExplorer/groupPermissions/(.*)")]
    public async Task WhenISendAGetRequestToApiFileExplorerGroupPermissions(string attachmentCategory)
    {
        _response = await _client.GetAsync($"/api/FileExplorer/groupPermissions/{attachmentCategory}");
    }

    [Then("the API response should be (\d+)")]
    public void ThenTheApiResponseShouldBe(int statusCode)
    {
        _response.StatusCode.Should().Be((System.Net.HttpStatusCode)statusCode);
    }

    [Then("the response should contain a list of group permissions")]
    public async Task ThenTheResponseShouldContainAListOfGroupPermissions()
    {
        var content = await _response.Content.ReadAsStringAsync();
        content.Should().NotBeNullOrEmpty();
        // Further validation of the content structure can be added here
    }
}