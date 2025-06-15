using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit.Gherkin.Quick;
using Newtonsoft.Json;
using FluentAssertions;

[FeatureFile("UploadAllProjectFiles.feature")]
public sealed class UploadAllProjectFilesSteps : Feature
{
    private readonly HttpClient _client = new HttpClient();
    private HttpResponseMessage _response;

    [Given("the FileSharing API is running")]
    public void GivenTheFileSharingApiIsRunning()
    {
        // Assume the API is running
    }

    [When("I send a POST request to /api/FileSharing/upload-all-project-files with the following details:")]
    public async Task WhenISendAPostRequestToApiFileSharingUploadAllProjectFilesWithTheFollowingDetails(Table table)
    {
        var row = table.Rows[0];
        var requestBody = new
        {
            SelectedFolderPath = row["SelectedFolderPath"],
            Template = row["Template"],
            AttachmentCategory = row["AttachmentCategory"],
            CurrentGlobalOpsFolder = row["CurrentGlobalOpsFolder"],
            CurrentEntityNo = row["CurrentEntityNo"],
            CurrentPartNo = row["CurrentPartNo"],
            SelectedFolderAttachmentType = row["SelectedFolderAttachmentType"]
        };

        var content = new StringContent(JsonConvert.SerializeObject(requestBody), Encoding.UTF8, "application/json");
        _response = await _client.PostAsync("http://localhost:5000/api/FileSharing/upload-all-project-files", content);
    }

    [Then("the API response should be:")]
    public async Task ThenTheApiResponseShouldBe(Table table)
    {
        var expectedRow = table.Rows[0];
        var expectedResponse = new
        {
            Success = bool.Parse(expectedRow["Success"]),
            Message = expectedRow["Message"],
            FoldersProcessed = int.Parse(expectedRow["FoldersProcessed"]),
            FilesProcessed = int.Parse(expectedRow["FilesProcessed"])
        };

        var responseContent = await _response.Content.ReadAsStringAsync();
        var actualResponse = JsonConvert.DeserializeObject<dynamic>(responseContent);

        actualResponse.Success.Should().Be(expectedResponse.Success);
        actualResponse.Message.Should().Be(expectedResponse.Message);
        actualResponse.FoldersProcessed.Should().Be(expectedResponse.FoldersProcessed);
        actualResponse.FilesProcessed.Should().Be(expectedResponse.FilesProcessed);
    }
}