using Xunit.Gherkin.Quick;
using System.Net.Http;
using System.Threading.Tasks;
using FluentAssertions;

[FeatureFile("VendorFeature.feature")]
public sealed class VendorSteps : Feature
{
    private readonly HttpClient _client;
    private HttpResponseMessage _response;

    public VendorSteps()
    {
        _client = new HttpClient { BaseAddress = new System.Uri("http://localhost:5000") };
    }

    [When("I send a GET request to /api/vendor/known-vendors/(.*)")]
    public async Task WhenISendAGetRequestToApiVendorKnownVendors(string partNo)
    {
        _response = await _client.GetAsync($"/api/vendor/known-vendors/{partNo}");
    }

    [Then("the API response should be (\d+)")]
    public void ThenTheApiResponseShouldBe(int statusCode)
    {
        _response.StatusCode.Should().Be((System.Net.HttpStatusCode)statusCode);
    }

    [Then("the response should contain a list of vendors")]
    public async Task ThenTheResponseShouldContainAListOfVendors()
    {
        var content = await _response.Content.ReadAsStringAsync();
        content.Should().StartWith("[");
        content.Should().EndWith("]");
    }

    [Then("the response should be an empty list")]
    public async Task ThenTheResponseShouldBeAnEmptyList()
    {
        var content = await _response.Content.ReadAsStringAsync();
        content.Should().Be("[]");
    }
}