using Xunit.Gherkin.Quick;
using System.Net.Http;
using System.Threading.Tasks;
using FluentAssertions;

[FeatureFile("ShippingRequests.feature")]
public sealed class ShippingRequestsSteps : Feature
{
    private readonly HttpClient _client;
    private HttpResponseMessage _response;

    public ShippingRequestsSteps()
    {
        _client = new HttpClient();
        _client.BaseAddress = new System.Uri("http://localhost:5000");
    }

    [When("I send a GET request to /api/ProjectDataPoints/shipping-requests/(.*)")]
    public async Task WhenISendAGetRequestToApiProjectDataPointsShippingRequests(string projectNumber)
    {
        _response = await _client.GetAsync($"/api/ProjectDataPoints/shipping-requests/{projectNumber}");
    }

    [Then("the API response should be (\d+)")]
    public void ThenTheApiResponseShouldBe(int statusCode)
    {
        _response.StatusCode.Should().Be((System.Net.HttpStatusCode)statusCode);
    }

    [Then("the response should contain a list of shipping requests")]
    public async Task ThenTheResponseShouldContainAListOfShippingRequests()
    {
        var content = await _response.Content.ReadAsStringAsync();
        content.Should().Contain("shippingRequests");
    }
}