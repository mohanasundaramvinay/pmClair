using Xunit;
using Xunit.Gherkin.Quick;
using System.Net.Http;
using System.Threading.Tasks;
using FluentAssertions;

[FeatureFile("VendorSubhireStatuses.feature")]
public sealed class VendorSubhireStatusesSteps : Feature
{
    private readonly HttpClient _client;
    private HttpResponseMessage _response;

    public VendorSubhireStatusesSteps()
    {
        _client = new HttpClient { BaseAddress = new System.Uri("http://localhost:5000") };
    }

    [Given("the Vendor API is running")]
    public void GivenTheVendorApiIsRunning()
    {
        // Assume the API is running
    }

    [Given("the Vendor API is running with a simulated server error")]
    public void GivenTheVendorApiIsRunningWithASimulatedServerError()
    {
        // Simulate server error setup if needed
    }

    [When("I send a GET request to /api/vendor/subhire-statuses")]
    public async Task WhenISendAGetRequestToApiVendorSubhireStatuses()
    {
        _response = await _client.GetAsync("/api/vendor/subhire-statuses");
    }

    [Then("the API response should be (\d+)")]
    public void ThenTheApiResponseShouldBe(int statusCode)
    {
        _response.StatusCode.Should().Be((System.Net.HttpStatusCode)statusCode);
    }

    [Then("the response should contain a list of subhire statuses")]
    public async Task ThenTheResponseShouldContainAListOfSubhireStatuses()
    {
        var content = await _response.Content.ReadAsStringAsync();
        content.Should().NotBeNullOrEmpty();
        // Further validation of the content structure can be added here
    }
}