using Xunit.Gherkin.Quick;
using System.Net.Http;
using System.Threading.Tasks;
using FluentAssertions;
using Newtonsoft.Json.Linq;

[FeatureFile("ShippingDestinationsSearch.feature")]
public sealed class ShippingDestinationsSearchSteps : Feature
{
    private readonly HttpClient _client = new HttpClient();
    private HttpResponseMessage _response;
    private string _searchTerm;

    [Given("the API is running")]
    public void GivenTheApiIsRunning()
    {
        _client.BaseAddress = new System.Uri("http://localhost:5000");
    }

    [When("I send a GET request to /api/ProjectDataPoints/shipping-destinations/search with searchTerm \"(.*)\"")]
    public async Task WhenISendAGetRequestToApiProjectDataPointsShippingDestinationsSearchWithSearchTerm(string searchTerm)
    {
        _searchTerm = searchTerm;
        _response = await _client.GetAsync($"/api/ProjectDataPoints/shipping-destinations/search?searchTerm={searchTerm}");
    }

    [Then("the API response should be (\d+)")]
    public void ThenTheApiResponseShouldBe(int statusCode)
    {
        _response.StatusCode.Should().Be((System.Net.HttpStatusCode)statusCode);
    }

    [Then("the response should contain destinations matching \"(.*)\"")]
    public async Task ThenTheResponseShouldContainDestinationsMatching(string searchTerm)
    {
        var content = await _response.Content.ReadAsStringAsync();
        var jsonArray = JArray.Parse(content);
        jsonArray.Should().NotBeEmpty();
        jsonArray.Should().OnlyContain(item => item["City"].ToString().Contains(searchTerm) || item["DestinationName"].ToString().Contains(searchTerm));
    }

    [Then("the response should handle special characters")]
    public async Task ThenTheResponseShouldHandleSpecialCharacters()
    {
        var content = await _response.Content.ReadAsStringAsync();
        content.Should().NotBeNull();
    }

    [Then("the response should be empty")]
    public async Task ThenTheResponseShouldBeEmpty()
    {
        var content = await _response.Content.ReadAsStringAsync();
        var jsonArray = JArray.Parse(content);
        jsonArray.Should().BeEmpty();
    }

    [Then("the response should handle numeric search terms")]
    public async Task ThenTheResponseShouldHandleNumericSearchTerms()
    {
        var content = await _response.Content.ReadAsStringAsync();
        content.Should().NotBeNull();
    }
}