using Xunit.Gherkin.Quick;
using System.Net.Http;
using System.Threading.Tasks;
using FluentAssertions;
using Newtonsoft.Json.Linq;

[FeatureFile("ProjectFolderGuid.feature")]
public sealed class ProjectFolderGuidSteps : Feature
{
    private readonly HttpClient _client = new HttpClient();
    private HttpResponseMessage _response;
    private string _responseContent;

    [Given("I have access to the FileSharing API")]
    public void GivenIHaveAccessToTheFileSharingAPI()
    {
        _client.BaseAddress = new System.Uri("http://localhost:5000");
    }

    [When("I send a GET request to /api/FileSharing/project-folder-guid with entityNo \"(.*)\"")]
    public async Task WhenISendAGetRequestWithEntityNo(string entityNo)
    {
        var url = $"/api/FileSharing/project-folder-guid?entityNo={entityNo}";
        _response = await _client.GetAsync(url);
        _responseContent = await _response.Content.ReadAsStringAsync();
    }

    [When("I send a GET request to /api/FileSharing/project-folder-guid without entityNo")]
    public async Task WhenISendAGetRequestWithoutEntityNo()
    {
        var url = "/api/FileSharing/project-folder-guid";
        _response = await _client.GetAsync(url);
        _responseContent = await _response.Content.ReadAsStringAsync();
    }

    [Then("the API response should be (\d+) with GUID \"(.*)\" and message \"(.*)\"")]
    public void ThenTheApiResponseShouldBeWithGuidAndMessage(int statusCode, string expectedGuid, string expectedMessage)
    {
        _response.StatusCode.Should().Be((System.Net.HttpStatusCode)statusCode);
        var jsonResponse = JObject.Parse(_responseContent);
        jsonResponse["Guid"].ToString().Should().Be(expectedGuid);
        jsonResponse["Message"].ToString().Should().Be(expectedMessage);
    }

    [Then("the API response should be (\d+) with message \"(.*)\"")]
    public void ThenTheApiResponseShouldBeWithMessage(int statusCode, string expectedMessage)
    {
        _response.StatusCode.Should().Be((System.Net.HttpStatusCode)statusCode);
        var jsonResponse = JObject.Parse(_responseContent);
        jsonResponse["Message"].ToString().Should().Be(expectedMessage);
    }
}