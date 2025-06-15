using Xunit;
using Xunit.Gherkin.Quick;
using System.Net.Http;
using System.Threading.Tasks;
using FluentAssertions;

[FeatureFile("TruckingCompaniesSearch.feature")]
public sealed class TruckingCompaniesSearchSteps : Feature
{
    private readonly HttpClient _client;
    private HttpResponseMessage _response;

    public TruckingCompaniesSearchSteps()
    {
        _client = new HttpClient();
        _client.BaseAddress = new System.Uri("http://localhost:5000");
    }

    [Given("I have access to the trucking companies API")]
    public void GivenIHaveAccessToTheTruckingCompaniesAPI()
    {
        // Assume access is always available for this test
    }

    [When("I send a GET request to /api/ProjectDataPoints/trucking-companies/search with searchTerm \"(.*)\"")]
    public async Task WhenISendAGETRequestToApiProjectDataPointsTruckingCompaniesSearchWithSearchTerm(string searchTerm)
    {
        var requestUri = $"/api/ProjectDataPoints/trucking-companies/search?searchTerm={searchTerm}";
        _response = await _client.GetAsync(requestUri);
    }

    [Then("the API response should be (\d+)")]
    public void ThenTheAPIResponseShouldBe(int statusCode)
    {
        _response.StatusCode.Should().Be((System.Net.HttpStatusCode)statusCode);
    }

    [And("the response should contain (true|false)")]
    public async Task AndTheResponseShouldContain(bool expectedResult)
    {
        var content = await _response.Content.ReadAsStringAsync();
        var containsExpectedResult = content.Contains("CompanyName");
        containsExpectedResult.Should().Be(expectedResult);
    }
}