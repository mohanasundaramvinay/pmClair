using System.Net;
using System.Threading.Tasks;
using Xunit.Gherkin.Quick;
using FluentAssertions;
using System.Net.Http;
using Newtonsoft.Json;

[FeatureFile("FileExplorerCloudFileUploads.feature")]
public sealed class FileExplorerCloudFileUploadsSteps : Feature
{
    private readonly HttpClient _client;
    private HttpResponseMessage _response;

    public FileExplorerCloudFileUploadsSteps()
    {
        _client = new HttpClient();
        _client.BaseAddress = new System.Uri("http://localhost:5000");
    }

    [When("I send a GET request to /api/FileExplorer/cloudFileUploads with attachmentCategory \"(.*)\", entityNo \"(.*)\", and partNo \"(.*)\"")]
    public async Task WhenISendAGetRequestToApiFileExplorerCloudFileUploads(string attachmentCategory, string entityNo, string partNo)
    {
        var url = $"/api/FileExplorer/cloudFileUploads?attachmentCategory={attachmentCategory}&entityNo={entityNo}&partNo={partNo}";
        _response = await _client.GetAsync(url);
    }

    [Then("the API response should be \"(.*)\"")]
    public void ThenTheApiResponseShouldBe(string statusCode)
    {
        var expectedStatusCode = (HttpStatusCode)int.Parse(statusCode);
        _response.StatusCode.Should().Be(expectedStatusCode);
    }
}