using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit.Gherkin.Quick;
using Newtonsoft.Json;
using FluentAssertions;

[FeatureFile("CreateFolderFeature.feature")]
public sealed class CreateFolderSteps : Feature
{
    private readonly HttpClient _client;
    private HttpResponseMessage _response;
    private string _responseContent;

    public CreateFolderSteps()
    {
        _client = new HttpClient();
        _client.BaseAddress = new System.Uri("http://localhost:5000");
    }

    [Given("the FileSharing API is running")]
    public void GivenTheFileSharingApiIsRunning()
    {
        // Assume the API is running
    }

    [When("I send a POST request to /api/FileSharing/create-folder with the following details: \"(.*)\", \"(.*)\", \"(.*)\", \"(.*)\", \"(.*)\"")]
    public async Task WhenISendAPostRequestToApiFileSharingCreateFolderWithTheFollowingDetails(string newFolderName, string attachmentCategorySubFolderPath, string attachmentCategory, string entityNo, string dropboxEnabled)
    {
        var requestBody = new
        {
            NewFolderName = newFolderName,
            AttachmentCategorySubFolderPath = attachmentCategorySubFolderPath,
            AttachmentCategory = attachmentCategory,
            EntityNo = entityNo,
            DropboxEnabled = bool.Parse(dropboxEnabled)
        };

        var content = new StringContent(JsonConvert.SerializeObject(requestBody), Encoding.UTF8, "application/json");
        _response = await _client.PostAsync("/api/FileSharing/create-folder", content);
        _responseContent = await _response.Content.ReadAsStringAsync();
    }

    [Then("the API response should be success with message \"(.*)\" and folder path \"(.*)\"")]
    public void ThenTheApiResponseShouldBeSuccessWithMessageAndFolderPath(string expectedMessage, string expectedFolderPath)
    {
        _response.IsSuccessStatusCode.Should().BeTrue();
        var responseObject = JsonConvert.DeserializeObject<dynamic>(_responseContent);
        ((string)responseObject.Message).Should().Be(expectedMessage);
        ((string)responseObject.FolderPath).Should().Be(expectedFolderPath);
    }

    [Then("the API response should be failure with message \"(.*)\"")]
    public void ThenTheApiResponseShouldBeFailureWithMessage(string expectedMessage)
    {
        _response.IsSuccessStatusCode.Should().BeFalse();
        var responseObject = JsonConvert.DeserializeObject<dynamic>(_responseContent);
        ((string)responseObject.Message).Should().Be(expectedMessage);
    }
}