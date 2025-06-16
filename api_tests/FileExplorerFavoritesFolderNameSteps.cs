using System.Net;
using System.Threading.Tasks;
using Xunit;
using Xunit.Gherkin.Quick;
using FluentAssertions;
using System.Net.Http;
using System.Net.Http.Json;

[FeatureFile("FileExplorerFavoritesFolderName.feature")]
public sealed class FileExplorerFavoritesFolderNameSteps : Feature
{
    private readonly HttpClient _client;
    private HttpResponseMessage _response;

    public FileExplorerFavoritesFolderNameSteps()
    {
        _client = new HttpClient { BaseAddress = new System.Uri("http://localhost:5000") };
    }

    [Given("the File Explorer API is running")]
    public void GivenTheFileExplorerApiIsRunning()
    {
        // Assume the API is running and accessible
    }

    [When("I send a GET request to /api/FileExplorer/favoritesFolderName")]
    public async Task WhenISendAGetRequestToApiFileExplorerFavoritesFolderName()
    {
        _response = await _client.GetAsync("/api/FileExplorer/favoritesFolderName");
    }

    [Then("the response status code should be 200")]
    public void ThenTheResponseStatusCodeShouldBe200()
    {
        _response.StatusCode.Should().Be(HttpStatusCode.OK);
    }

    [Then("the response should contain the favorites folder name")]
    public async Task ThenTheResponseShouldContainTheFavoritesFolderName()
    {
        var folderName = await _response.Content.ReadAsStringAsync();
        folderName.Should().NotBeNullOrEmpty();
    }

    [Then("the response status code should be 500")]
    public void ThenTheResponseStatusCodeShouldBe500()
    {
        _response.StatusCode.Should().Be(HttpStatusCode.InternalServerError);
    }

    [Then("the response should contain an error message")]
    public async Task ThenTheResponseShouldContainAnErrorMessage()
    {
        var errorMessage = await _response.Content.ReadAsStringAsync();
        errorMessage.Should().Contain("An error occurred while retrieving favorites folder name");
    }
}