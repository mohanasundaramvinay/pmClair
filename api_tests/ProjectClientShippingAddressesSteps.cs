using Xunit.Gherkin.Quick;
using System.Net.Http;
using System.Threading.Tasks;
using FluentAssertions;

[FeatureFile("ProjectClientShippingAddresses.feature")]
public sealed class ProjectClientShippingAddressesSteps : Feature
{
    private readonly HttpClient _client = new HttpClient();
    private HttpResponseMessage _response;

    [When("I send a GET request to /api/projects/(.*)/client-shipping-addresses")]
    public async Task WhenISendAGetRequestToApiProjectsEntityNoClientShippingAddresses(string entityNo)
    {
        var url = $"http://localhost:5000/api/projects/{entityNo}/client-shipping-addresses";
        _response = await _client.GetAsync(url);
    }

    [Then("the API response should be (.*)")]
    public void ThenTheApiResponseShouldBe(int statusCode)
    {
        _response.StatusCode.Should().Be((System.Net.HttpStatusCode)statusCode);
    }

    [Then("the response should contain a list of client shipping addresses")]
    public async Task ThenTheResponseShouldContainAListOfClientShippingAddresses()
    {
        var content = await _response.Content.ReadAsStringAsync();
        content.Should().NotBeNullOrEmpty();
        // Further validation of the JSON structure can be added here
    }
}