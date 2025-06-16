using Xunit;
using Xunit.Gherkin.Quick;
using System.Net.Http;
using System.Threading.Tasks;
using FluentAssertions;

[FeatureFile("GetNextAvailableProjectNumber.feature")]
public sealed class GetNextAvailableProjectNumberSteps : Feature
{
    private readonly HttpClient _client;
    private HttpResponseMessage _response;

    public GetNextAvailableProjectNumberSteps()
    {
        _client = new HttpClient();
        _client.BaseAddress = new System.Uri("http://localhost:5000/api/");
    }

    [When("I send a GET request to /api/projects/next")]
    public async Task WhenISendAGetRequestToApiProjectsNext()
    {
        _response = await _client.GetAsync("projects/next");
    }

    [Then("the API response should be a valid integer")]
    public async Task ThenTheApiResponseShouldBeAValidInteger()
    {
        var content = await _response.Content.ReadAsStringAsync();
        int result;
        bool isInteger = int.TryParse(content, out result);
        isInteger.Should().BeTrue();
    }

    [Then("the status code should be (.*)")]
    public void ThenTheStatusCodeShouldBe(int statusCode)
    {
        ((int)_response.StatusCode).Should().Be(statusCode);
    }
}