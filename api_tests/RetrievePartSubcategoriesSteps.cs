using Xunit.Gherkin.Quick;
using System.Net.Http;
using System.Threading.Tasks;
using FluentAssertions;

[FeatureFile("RetrievePartSubcategories.feature")]
public sealed class RetrievePartSubcategoriesSteps : Feature
{
    private readonly HttpClient _client;
    private HttpResponseMessage _response;

    public RetrievePartSubcategoriesSteps()
    {
        _client = new HttpClient();
        _client.BaseAddress = new System.Uri("http://localhost:5000");
    }

    [When("I send a GET request to /api/ProjectDataPoints/parts/subcategories/(.*)")]
    public async Task WhenISendAGetRequestToApiProjectDataPointsPartsSubcategories(string categoryCode)
    {
        _response = await _client.GetAsync($"/api/ProjectDataPoints/parts/subcategories/{categoryCode}");
    }

    [Then("the API response should be (\d+)")]
    public void ThenTheApiResponseShouldBe(int statusCode)
    {
        _response.StatusCode.Should().Be((System.Net.HttpStatusCode)statusCode);
    }

    [Then("the response should contain a list of subcategories")]
    public async Task ThenTheResponseShouldContainAListOfSubcategories()
    {
        var content = await _response.Content.ReadAsStringAsync();
        content.Should().StartWith("[");
        content.Should().EndWith("]");
    }
}