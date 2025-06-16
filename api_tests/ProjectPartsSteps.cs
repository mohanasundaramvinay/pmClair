using Xunit.Gherkin.Quick;
using System.Net.Http;
using System.Threading.Tasks;
using FluentAssertions;

[FeatureFile("ProjectParts.feature")]
public sealed class ProjectPartsSteps : Feature
{
    private readonly HttpClient _client = new HttpClient();
    private HttpResponseMessage _response;

    [When("I send a GET request to /api/projects/(.*)/parts")]
    public async Task WhenISendAGetRequestToApiProjectsParts(string entityNo)
    {
        var url = $"http://localhost:5000/api/projects/{entityNo}/parts";
        _response = await _client.GetAsync(url);
    }

    [Then("the API response should be (.*)")]
    public void ThenTheApiResponseShouldBe(int statusCode)
    {
        _response.StatusCode.Should().Be((System.Net.HttpStatusCode)statusCode);
    }

    [Then("the response should contain a list of parts")]
    public async Task ThenTheResponseShouldContainAListOfParts()
    {
        var content = await _response.Content.ReadAsStringAsync();
        content.Should().NotBeNullOrEmpty();
        // Further validation of the content structure can be added here
    }
}