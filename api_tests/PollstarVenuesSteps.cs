using Xunit;
using Xunit.Gherkin.Quick;
using System.Net.Http;
using System.Threading.Tasks;
using FluentAssertions;

[FeatureFile("PollstarVenues.feature")]
public sealed class PollstarVenuesSteps : Feature
{
    private readonly HttpClient _client;
    private HttpResponseMessage _response;

    public PollstarVenuesSteps()
    {
        _client = new HttpClient { BaseAddress = new System.Uri("http://localhost:5000") };
    }

    [Given("the API is running")]
    public void GivenTheApiIsRunning()
    {
        // Assume the API is running
    }

    [Given("the server is down")]
    public void GivenTheServerIsDown()
    {
        // Simulate server down scenario
        _client.BaseAddress = new System.Uri("http://localhost:5001");
    }

    [When("I send a GET request to (.*)")]
    public async Task WhenISendAGetRequestTo(string endpoint)
    {
        _response = await _client.GetAsync(endpoint);
    }

    [Then("the API response should be (.*)")]
    public void ThenTheApiResponseShouldBe(int statusCode)
    {
        _response.StatusCode.Should().Be((System.Net.HttpStatusCode)statusCode);
    }

    [Then("the response should contain a list of venues")]
    public async Task ThenTheResponseShouldContainAListOfVenues()
    {
        var content = await _response.Content.ReadAsStringAsync();
        content.Should().Contain("VenueId");
    }
}