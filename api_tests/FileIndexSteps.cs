using Xunit.Gherkin.Quick;
using System.Net.Http;
using System.Threading.Tasks;
using FluentAssertions;
using Newtonsoft.Json;
using System.Collections.Generic;

[FeatureFile("FileIndexFeature.feature")]
public sealed class FileIndexSteps : Feature
{
    private readonly HttpClient _client = new HttpClient();
    private HttpResponseMessage _response;

    [Given("I have access to the File Explorer API")]
    public void GivenIHaveAccessToTheFileExplorerAPI()
    {
        _client.BaseAddress = new System.Uri("http://localhost:5000");
    }

    [When("I send a GET request to /api/FileExplorer/fileIndex/(.*)")]
    public async Task WhenISendAGETRequestToApiFileExplorerFileIndex(string guid)
    {
        _response = await _client.GetAsync($"/api/FileExplorer/fileIndex/{guid}");
    }

    [Then("the API response should be (\d+)")]
    public void ThenTheAPIResponseShouldBe(int statusCode)
    {
        _response.StatusCode.Should().Be((System.Net.HttpStatusCode)statusCode);
    }

    [Then("the response should contain a list of file index details")]
    public async Task ThenTheResponseShouldContainAListOfFileIndexDetails()
    {
        var content = await _response.Content.ReadAsStringAsync();
        var fileIndexDetails = JsonConvert.DeserializeObject<List<FileIndexDetails>>(content);
        fileIndexDetails.Should().NotBeNull();
        fileIndexDetails.Should().BeOfType<List<FileIndexDetails>>();
    }
}

public class FileIndexDetails
{
    public string FileName { get; set; }
    public int FileSize { get; set; }
    public string FileType { get; set; }
    public string CreatedDate { get; set; }
    public string ModifiedDate { get; set; }
    public string FilePath { get; set; }
    public bool IsDirectory { get; set; }
    public string Owner { get; set; }
    public string Permissions { get; set; }
    public string Checksum { get; set; }
}