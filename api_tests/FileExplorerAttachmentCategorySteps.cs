using Xunit.Gherkin.Quick;
using System.Net.Http;
using System.Threading.Tasks;
using FluentAssertions;

[FeatureFile("FileExplorerAttachmentCategory.feature")]
public sealed class FileExplorerAttachmentCategorySteps : Feature
{
    private readonly HttpClient _client;
    private HttpResponseMessage _response;

    public FileExplorerAttachmentCategorySteps()
    {
        _client = new HttpClient { BaseAddress = new System.Uri("http://localhost:5000") };
    }

    [When("I send a GET request to /api/FileExplorer/attachmentCategory/(.*)")]
    public async Task WhenISendAGetRequestToApiFileExplorerAttachmentCategory(string attachmentCategory)
    {
        _response = await _client.GetAsync($"/api/FileExplorer/attachmentCategory/{attachmentCategory}");
    }

    [Then("the API response status should be (\d+)")]
    public void ThenTheApiResponseStatusShouldBe(int statusCode)
    {
        _response.StatusCode.Should().Be((System.Net.HttpStatusCode)statusCode);
    }

    [Then("the response should contain the attachment category details")]
    public async Task ThenTheResponseShouldContainTheAttachmentCategoryDetails()
    {
        var content = await _response.Content.ReadAsStringAsync();
        content.Should().Contain("Id").And.Contain("Name").And.Contain("Description");
    }
}