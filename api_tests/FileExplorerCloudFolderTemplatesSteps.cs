using Xunit;
using Xunit.Gherkin.Quick;
using System.Net.Http;
using System.Threading.Tasks;
using FluentAssertions;

[FeatureFile("FileExplorerCloudFolderTemplates.feature")]
public sealed class FileExplorerCloudFolderTemplatesSteps : Feature
{
    private readonly HttpClient _client;
    private HttpResponseMessage _response;

    public FileExplorerCloudFolderTemplatesSteps()
    {
        _client = new HttpClient();
        _client.BaseAddress = new System.Uri("http://localhost:5000");
    }

    [Given("the File Explorer API is running")]
    public void GivenTheFileExplorerApiIsRunning()
    {
        // Assume the API is running for the purpose of this test
    }

    [When("I send a GET request to /api/FileExplorer/cloudFolderTemplates")]
    public async Task WhenISendAGetRequestToApiFileExplorerCloudFolderTemplates()
    {
        _response = await _client.GetAsync("/api/FileExplorer/cloudFolderTemplates");
    }

    [Then("the API response should be a list of cloud folder templates with status code (.*)")]
    public async Task ThenTheApiResponseShouldBeAListOfCloudFolderTemplatesWithStatusCode(int statusCode)
    {
        _response.StatusCode.Should().Be((System.Net.HttpStatusCode)statusCode);
        var content = await _response.Content.ReadAsStringAsync();
        content.Should().NotBeNullOrEmpty();
        // Further assertions can be made based on the expected structure of the response
    }

    [Then("the API response should be an error message with status code (.*)")]
    public void ThenTheApiResponseShouldBeAnErrorMessageWithStatusCode(int statusCode)
    {
        _response.StatusCode.Should().Be((System.Net.HttpStatusCode)statusCode);
        // Further assertions can be made based on the expected error message
    }
}