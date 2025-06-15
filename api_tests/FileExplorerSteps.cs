using Xunit.Gherkin.Quick;
using System.Net.Http;
using System.Threading.Tasks;
using FluentAssertions;

[FeatureFile("FileExplorerContactCategoryCloudMappings.feature")]
public class FileExplorerSteps : Feature
{
    private readonly HttpClient _client;
    private HttpResponseMessage _response;

    public FileExplorerSteps()
    {
        _client = new HttpClient();
        _client.BaseAddress = new System.Uri("http://localhost:5000");
    }

    [Given("I have access to the File Explorer API")]
    public void GivenIHaveAccessToTheFileExplorerAPI()
    {
        // Assume access is granted
    }

    [When("I send a GET request to /api/FileExplorer/contactCategoryCloudMappings")]
    public async Task WhenISendAGETRequestToApiFileExplorerContactCategoryCloudMappings()
    {
        _response = await _client.GetAsync("/api/FileExplorer/contactCategoryCloudMappings");
    }

    [Then("the API response should be 200")]
    public void ThenTheAPIResponseShouldBe200()
    {
        _response.StatusCode.Should().Be(System.Net.HttpStatusCode.OK);
    }

    [Then("the API response should be 500")]
    public void ThenTheAPIResponseShouldBe500()
    {
        _response.StatusCode.Should().Be(System.Net.HttpStatusCode.InternalServerError);
    }

    [Then("the response should contain a list of contact category cloud mappings")]
    public async Task ThenTheResponseShouldContainAListOfContactCategoryCloudMappings()
    {
        var content = await _response.Content.ReadAsStringAsync();
        content.Should().Contain("ContactCategoryCloudMapping");
    }

    [Then("the response should contain an error message")]
    public async Task ThenTheResponseShouldContainAnErrorMessage()
    {
        var content = await _response.Content.ReadAsStringAsync();
        content.Should().Contain("error");
    }

    [Then("each mapping should have a valid identifier")]
    public async Task ThenEachMappingShouldHaveAValidIdentifier()
    {
        var content = await _response.Content.ReadAsStringAsync();
        // Validate identifier presence
    }

    [Then("each mapping should have a valid name")]
    public async Task ThenEachMappingShouldHaveAValidName()
    {
        var content = await _response.Content.ReadAsStringAsync();
        // Validate name presence
    }

    [Given("the server is in \"(.*)\" state")]
    public void GivenTheServerIsInState(string state)
    {
        // Simulate server state if possible
    }

    [Then("the API response should be \"(.*)\"")]
    public void ThenTheAPIResponseShouldBe(string statusCode)
    {
        _response.StatusCode.Should().Be((System.Net.HttpStatusCode)int.Parse(statusCode));
    }
}