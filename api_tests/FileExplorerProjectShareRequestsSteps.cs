using Xunit.Gherkin.Quick;
using System.Net.Http;
using System.Threading.Tasks;
using FluentAssertions;

[FeatureFile("FileExplorerProjectShareRequests.feature")]
public sealed class FileExplorerProjectShareRequestsSteps : Feature
{
    private readonly HttpClient _client;
    private HttpResponseMessage _response;

    public FileExplorerProjectShareRequestsSteps()
    {
        _client = new HttpClient();
        _client.BaseAddress = new System.Uri("http://localhost:5000");
    }

    [When("I send a GET request to /api/FileExplorer/projectShareRequests/(.*)")]
    public async Task WhenISendAGetRequestToApiFileExplorerProjectShareRequests(string entityNo)
    {
        _response = await _client.GetAsync($"/api/FileExplorer/projectShareRequests/{entityNo}");
    }

    [Then("the API response should be (\d+)")]
    public void ThenTheApiResponseShouldBe(int statusCode)
    {
        _response.StatusCode.Should().Be((System.Net.HttpStatusCode)statusCode);
    }

    [Then("the response should contain a list of project share requests")]
    public async Task ThenTheResponseShouldContainAListOfProjectShareRequests()
    {
        var content = await _response.Content.ReadAsStringAsync();
        content.Should().Contain("requestId");
    }

    [Then("the response should contain an error message")]
    public async Task ThenTheResponseShouldContainAnErrorMessage()
    {
        var content = await _response.Content.ReadAsStringAsync();
        content.Should().Contain("error");
    }
}