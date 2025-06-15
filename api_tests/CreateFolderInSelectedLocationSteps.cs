using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Xunit.Gherkin.Quick;
using Newtonsoft.Json;

[FeatureFile("CreateFolderInSelectedLocation.feature")]
public sealed class CreateFolderInSelectedLocationSteps : Feature
{
    private readonly HttpClient _client = new HttpClient();
    private HttpResponseMessage _response;

    [Given("I have access to the FileSharing API")]
    public void GivenIHaveAccessToTheFileSharingAPI()
    {
        _client.BaseAddress = new System.Uri("http://localhost:5000");
    }

    [When("I send a POST request to /api/FileSharing/create-folder-in-selected with the following details: \"(.*)\", \"(.*)\", \"(.*)\", \"(.*)\", \"(.*)\", \"(.*)\", \"(.*)\"")]
    public async Task WhenISendAPOSTRequestToCreateFolderInSelected(string newFolderName, string currentGlobalOpsFolder, string attachmentCategory, string entityNo, string selectedNodePath, string dropboxEnabled, string isLoadingTree)
    {
        var requestBody = new
        {
            NewFolderName = newFolderName,
            CurrentGlobalOpsFolder = currentGlobalOpsFolder,
            AttachmentCategory = attachmentCategory,
            EntityNo = entityNo,
            SelectedNodePath = selectedNodePath,
            DropboxEnabled = bool.Parse(dropboxEnabled),
            IsLoadingTree = bool.Parse(isLoadingTree)
        };

        var content = new StringContent(JsonConvert.SerializeObject(requestBody), Encoding.UTF8, "application/json");
        _response = await _client.PostAsync("/api/FileSharing/create-folder-in-selected", content);
    }

    [Then("the API response should be: \"(.*)\", \"(.*)\", \"(.*)\"")]
    public async Task ThenTheAPIResponseShouldBe(string expectedSuccess, string expectedMessage, string expectedFolderPath)
    {
        var responseContent = await _response.Content.ReadAsStringAsync();
        var responseObject = JsonConvert.DeserializeObject<dynamic>(responseContent);

        Assert.Equal(bool.Parse(expectedSuccess), (bool)responseObject.Success);
        Assert.Equal(expectedMessage, (string)responseObject.Message);
        Assert.Equal(expectedFolderPath, (string)responseObject.FolderPath);
    }
}