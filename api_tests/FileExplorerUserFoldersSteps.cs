using Xunit.Gherkin.Quick;
using System.Net.Http;
using System.Threading.Tasks;
using FluentAssertions;

[FeatureFile("FileExplorerUserFolders.feature")]
public sealed class FileExplorerUserFoldersSteps : Feature
{
    private readonly HttpClient _client;
    private HttpResponseMessage _response;

    public FileExplorerUserFoldersSteps()
    {
        _client = new HttpClient();
        _client.BaseAddress = new System.Uri("http://localhost:5000");
    }

    [Given("I have access to the File Explorer API")]
    public void GivenIHaveAccessToTheFileExplorerAPI()
    {
        // Assume access is granted
    }

    [When("I send a GET request to /api/FileExplorer/userFolders/(.*)")]
    public async Task WhenISendAGETRequestToApiFileExplorerUserFolders(string entityNo)
    {
        _response = await _client.GetAsync($"/api/FileExplorer/userFolders/{entityNo}");
    }

    [Then("the API response should be (\d+)")]
    public void ThenTheAPIResponseShouldBe(int statusCode)
    {
        _response.StatusCode.Should().Be((System.Net.HttpStatusCode)statusCode);
    }

    [Then("the response should contain a list of user folders")]
    public async Task ThenTheResponseShouldContainAListOfUserFolders()
    {
        var content = await _response.Content.ReadAsStringAsync();
        content.Should().NotBeNullOrEmpty();
        // Further validation of the content structure can be added here
    }
}