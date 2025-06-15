using Xunit;
using Xunit.Gherkin.Quick;
using System.Net.Http;
using System.Threading.Tasks;
using FluentAssertions;
using Newtonsoft.Json.Linq;

[FeatureFile("FileExplorerRootAttachmentTypes.feature")]
public sealed class FileExplorerRootAttachmentTypesSteps : Feature
{
    private readonly HttpClient _client;
    private HttpResponseMessage _response;
    private JArray _jsonResponse;

    public FileExplorerRootAttachmentTypesSteps()
    {
        _client = new HttpClient();
        _client.BaseAddress = new System.Uri("http://localhost:5000");
    }

    [When("I send a GET request to /api/FileExplorer/rootAttachmentTypes")]
    public async Task WhenISendAGetRequestToApiFileExplorerRootAttachmentTypes()
    {
        _response = await _client.GetAsync("/api/FileExplorer/rootAttachmentTypes");
        var content = await _response.Content.ReadAsStringAsync();
        _jsonResponse = JArray.Parse(content);
    }

    [Then("the API response should be 200")]
    public void ThenTheApiResponseShouldBe200()
    {
        _response.StatusCode.Should().Be(System.Net.HttpStatusCode.OK);
    }

    [Then("the API response should be 500")]
    public void ThenTheApiResponseShouldBe500()
    {
        _response.StatusCode.Should().Be(System.Net.HttpStatusCode.InternalServerError);
    }

    [Then("the response should contain a list of root attachment types")]
    public void ThenTheResponseShouldContainAListOfRootAttachmentTypes()
    {
        _jsonResponse.Should().NotBeNull();
        _jsonResponse.Should().BeOfType<JArray>();
    }

    [Then("the response should contain an error message")]
    public void ThenTheResponseShouldContainAnErrorMessage()
    {
        var errorMessage = _jsonResponse.Value<string>("error");
        errorMessage.Should().NotBeNullOrEmpty();
    }

    [Then("the response should contain a list of root attachment types with fields (.*), (.*), (.*)")]
    public void ThenTheResponseShouldContainAListOfRootAttachmentTypesWithFields(string field1, string field2, string field3)
    {
        foreach (var item in _jsonResponse)
        {
            item[field1].Should().NotBeNull();
            item[field2].Should().NotBeNull();
            item[field3].Should().NotBeNull();
        }
    }
}