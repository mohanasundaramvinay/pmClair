using Xunit.Gherkin.Quick;
using System.Net.Http;
using System.Threading.Tasks;
using FluentAssertions;
using Newtonsoft.Json;
using System.Collections.Generic;

[FeatureFile("VendorAddresses.feature")]
public class VendorAddressesSteps : Feature
{
    private readonly HttpClient _client;
    private HttpResponseMessage _response;
    private string _vendNo;

    public VendorAddressesSteps()
    {
        _client = new HttpClient();
        _client.BaseAddress = new System.Uri("http://localhost:5000");
    }

    [Given("I have access to the vendor API")]
    public void GivenIHaveAccessToTheVendorAPI()
    {
        // Assume access is always available for this test
    }

    [When("I send a GET request to /api/vendor/addresses/(.*)")]
    public async Task WhenISendAGETRequestToApiVendorAddresses(string vendNo)
    {
        _vendNo = vendNo;
        _response = await _client.GetAsync($"/api/vendor/addresses/{vendNo}");
    }

    [Then("the API response should be (\d+)")]
    public void ThenTheAPIResponseShouldBe(int statusCode)
    {
        _response.StatusCode.Should().Be((System.Net.HttpStatusCode)statusCode);
    }

    [Then("the response should contain a list of vendor addresses")]
    public async Task ThenTheResponseShouldContainAListOfVendorAddresses()
    {
        var content = await _response.Content.ReadAsStringAsync();
        var addresses = JsonConvert.DeserializeObject<List<VendorAddressDto>>(content);
        addresses.Should().NotBeNull();
        addresses.Should().NotBeEmpty();
    }

    [Then("the response should be an empty list")]
    public async Task ThenTheResponseShouldBeAnEmptyList()
    {
        var content = await _response.Content.ReadAsStringAsync();
        var addresses = JsonConvert.DeserializeObject<List<VendorAddressDto>>(content);
        addresses.Should().BeEmpty();
    }
}