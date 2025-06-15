using System.Net.Http;
using System.Threading.Tasks;
using Xunit.Gherkin.Quick;
using FluentAssertions;

[FeatureFile("FileSharingIndexFolderDeletion.feature")]
public sealed class FileSharingIndexFolderDeletionSteps : Feature
{
    private readonly HttpClient _client;
    private HttpResponseMessage _response;

    public FileSharingIndexFolderDeletionSteps()
    {
        _client = new HttpClient();
        _client.BaseAddress = new System.Uri("http://localhost:5000");
    }

    [Given("I have access to the File Sharing API")]
    public void GivenIHaveAccessToTheFileSharingAPI()
    {
        // Assume access is always available for this test
    }

    [When("I send a DELETE request to /api/FileSharing/index-folder with GUID \"(.*)\" and subFolderPath \"(.*)\"")]
    public async Task WhenISendADeleteRequestToApiFileSharingIndexFolderWithGuidAndSubFolderPath(string guid, string subFolderPath)
    {
        var requestUri = $"/api/FileSharing/index-folder?guid={guid}&subFolderPath={subFolderPath}";
        _response = await _client.DeleteAsync(requestUri);
    }

    [Then("the API response should be: \"(.*)\"")]
    public void ThenTheApiResponseShouldBe(string expectedStatusCode)
    {
        var expectedStatus = (System.Net.HttpStatusCode)int.Parse(expectedStatusCode);
        _response.StatusCode.Should().Be(expectedStatus);
    }
}