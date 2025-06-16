using Xunit;
using Xunit.Gherkin.Quick;
using System.Net.Http;
using System.Threading.Tasks;
using FluentAssertions;

[FeatureFile("CustomerSearch.feature")]
public sealed class CustomerSearchSteps : Feature
{
    private readonly HttpClient _client;
    private HttpResponseMessage _response;

    public CustomerSearchSteps()
    {
        _client = new HttpClient();
        _client.BaseAddress = new System.Uri("http://localhost:5000");
    }

    [When("I send a GET request to /api/ProjectDataPoints/customers/search with searchTerm \"(.*)\"")]
    public async Task WhenISendAGetRequestToApiProjectDataPointsCustomersSearchWithSearchTerm(string searchTerm)
    {
        var requestUri = $"/api/ProjectDataPoints/customers/search?searchTerm={searchTerm}";
        _response = await _client.GetAsync(requestUri);
    }

    [Then("the API response should be (\d+)")]
    public void ThenTheApiResponseShouldBe(int statusCode)
    {
        _response.StatusCode.Should().Be((System.Net.HttpStatusCode)statusCode);
    }

    [And("the response should contain (.*)")]
    public async Task AndTheResponseShouldContain(string expectedResult)
    {
        var content = await _response.Content.ReadAsStringAsync();
        content.Should().Contain(expectedResult);
    }
}