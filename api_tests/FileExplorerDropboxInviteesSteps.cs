using Xunit.Gherkin.Quick;
using System.Net.Http;
using System.Threading.Tasks;
using FluentAssertions;

[FeatureFile("FileExplorerDropboxInvitees.feature")]
public sealed class FileExplorerDropboxInviteesSteps : Feature
{
    private readonly HttpClient _client;
    private HttpResponseMessage _response;

    public FileExplorerDropboxInviteesSteps()
    {
        _client = new HttpClient();
        _client.BaseAddress = new System.Uri("http://localhost:5000");
    }

    [Given("I have access to the File Explorer API")]
    public void GivenIHaveAccessToTheFileExplorerAPI()
    {
        // Assume access is always available for this test
    }

    [When("I send a GET request to /api/FileExplorer/dropboxInvitees/(.*)")]
    public async Task WhenISendAGETRequestToApiFileExplorerDropboxInvitees(string entityNo)
    {
        _response = await _client.GetAsync($"/api/FileExplorer/dropboxInvitees/{entityNo}");
    }

    [Then("the API response should be (\d+)")]
    public void ThenTheAPIResponseShouldBe(int statusCode)
    {
        _response.StatusCode.Should().Be((System.Net.HttpStatusCode)statusCode);
    }

    [And("the response should contain a list of invitees")]
    public async Task AndTheResponseShouldContainAListOfInvitees()
    {
        var content = await _response.Content.ReadAsStringAsync();
        content.Should().Contain("InviteeId");
    }
}