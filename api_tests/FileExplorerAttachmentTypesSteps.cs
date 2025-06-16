using Xunit.Gherkin.Quick;
using System.Net.Http;
using System.Threading.Tasks;
using FluentAssertions;

[FeatureFile("FileExplorerAttachmentTypes.feature")]
public sealed class FileExplorerAttachmentTypesSteps : Feature
{
    private readonly HttpClient _client;
    private HttpResponseMessage _response;

    public FileExplorerAttachmentTypesSteps()
    {
        _client = new HttpClient();
        _client.BaseAddress = new System.Uri("http://localhost:5000");
    }

    [When("I send a GET request to /api/FileExplorer/attachmentTypes/(.*)")]
    public async Task WhenISendAGetRequestToApiFileExplorerAttachmentTypes(string attachmentCategory)
    {
        _response = await _client.GetAsync($"/api/FileExplorer/attachmentTypes/{attachmentCategory}");
    }

    [Then("the API response should be 200 OK")]
    public void ThenTheApiResponseShouldBe200Ok()
    {
        _response.StatusCode.Should().Be(System.Net.HttpStatusCode.OK);
    }

    [Then("the API response should be 404 Not Found")]
    public void ThenTheApiResponseShouldBe404NotFound()
    {
        _response.StatusCode.Should().Be(System.Net.HttpStatusCode.NotFound);
    }

    [Then("the API response should be 400 Bad Request")]
    public void ThenTheApiResponseShouldBe400BadRequest()
    {
        _response.StatusCode.Should().Be(System.Net.HttpStatusCode.BadRequest);
    }

    [Then("the response should contain a list of attachment types")]
    public async Task ThenTheResponseShouldContainAListOfAttachmentTypes()
    {
        var content = await _response.Content.ReadAsStringAsync();
        content.Should().Contain("Id").And.Contain("Name").And.Contain("Permissions");
    }
}