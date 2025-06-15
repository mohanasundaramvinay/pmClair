using Xunit;
using Xunit.Gherkin.Quick;
using System.Net.Http;
using System.Threading.Tasks;
using FluentAssertions;

[FeatureFile("ShippingDestinations.feature")]
public sealed class ShippingDestinationsSteps : Feature
{
    private readonly HttpClient _client;
    private HttpResponseMessage _response;

    public ShippingDestinationsSteps()
    {
        _client = new HttpClient();
        _client.BaseAddress = new System.Uri("http://localhost:5000");
    }

    [Given("I have access to the ProjectDataPoints API")]
    public void GivenIHaveAccessToTheProjectDataPointsAPI()
    {
        // Assume access is always available for this test
    }

    [When("I send a GET request to /api/ProjectDataPoints/shipping-destinations")]
    public async Task WhenISendAGETRequestToApiProjectDataPointsShippingDestinations()
    {
        _response = await _client.GetAsync("/api/ProjectDataPoints/shipping-destinations");
    }

    [Then("the API response should be (.*)")]
    public void ThenTheAPIResponseShouldBe(int statusCode)
    {
        _response.StatusCode.Should().Be((System.Net.HttpStatusCode)statusCode);
    }

    [Then("the response should contain a list of shipping destinations")]
    public async Task ThenTheResponseShouldContainAListOfShippingDestinations()
    {
        var content = await _response.Content.ReadAsStringAsync();
        content.Should().Contain("DestinationId");
    }

    [Then("the response should contain an error message")]
    public async Task ThenTheResponseShouldContainAnErrorMessage()
    {
        var content = await _response.Content.ReadAsStringAsync();
        content.Should().Contain("error");
    }

    [Then("the response time should be less than (.*) milliseconds")]
    public void ThenTheResponseTimeShouldBeLessThanMilliseconds(int maxResponseTime)
    {
        _response.Headers.TryGetValues("X-Response-Time", out var values);
        var responseTime = int.Parse(values.First());
        responseTime.Should().BeLessThan(maxResponseTime);
    }
}