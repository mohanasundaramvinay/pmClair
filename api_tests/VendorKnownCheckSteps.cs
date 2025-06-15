using Xunit.Gherkin.Quick;
using System.Net.Http;
using System.Threading.Tasks;
using FluentAssertions;

[FeatureFile("VendorKnownCheck.feature")]
public sealed class VendorKnownCheckSteps : Feature
{
    private readonly HttpClient _client;
    private HttpResponseMessage _response;

    public VendorKnownCheckSteps()
    {
        _client = new HttpClient();
        _client.BaseAddress = new System.Uri("http://localhost:5000");
    }

    [When("I send a GET request to /api/vendor/known-vendors/check with partNo=\"(.*)\", vendNo=\"(.*)\", siteNo=\"(.*)\"")]
    public async Task WhenISendAGetRequestToApiVendorKnownVendorsCheck(string partNo, string vendNo, string siteNo)
    {
        var url = $"/api/vendor/known-vendors/check?partNo={partNo}&vendNo={vendNo}&siteNo={siteNo}";
        _response = await _client.GetAsync(url);
    }

    [Then("the API response should be: (.*)")]
    public async Task ThenTheApiResponseShouldBe(bool isKnown)
    {
        var content = await _response.Content.ReadAsStringAsync();
        bool result = bool.Parse(content);
        result.Should().Be(isKnown);
    }
}