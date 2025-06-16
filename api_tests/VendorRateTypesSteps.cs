using Xunit;
using Xunit.Gherkin.Quick;
using System.Net.Http;
using System.Threading.Tasks;
using FluentAssertions;
using Newtonsoft.Json;
using System.Collections.Generic;

[FeatureFile("VendorRateTypes.feature")]
public sealed class VendorRateTypesSteps : Feature
{
    private readonly HttpClient _client;
    private HttpResponseMessage _response;
    private string _scenario;

    public VendorRateTypesSteps()
    {
        _client = new HttpClient();
        _client.BaseAddress = new System.Uri("http://localhost:5000");
    }

    [Given("the Vendor API is running")]
    public void GivenTheVendorApiIsRunning()
    {
        // Assume the API is running
    }

    [Given("the server is experiencing issues")]
    public void GivenTheServerIsExperiencingIssues()
    {
        // Simulate server issues if possible
    }

    [When("I send a GET request to /api/vendor-rate-types")]
    public async Task WhenISendAGetRequestToApiVendorRateTypes()
    {
        _response = await _client.GetAsync("/api/vendor/rate-types");
    }

    [Then("the API response should be 200")]
    public void ThenTheApiResponseShouldBe200()
    {
        _response.StatusCode.Should().Be(System.Net.HttpStatusCode.OK);
    }

    [Then("the API response should be 500")]
    public void ThenTheApiResponseShouldBe500()
    {
        _response.StatusCode.Should().Be(System.Net.HttpStatusCode.InternalServerError);
    }

    [Then("the response should contain a list of rate types")]
    public async Task ThenTheResponseShouldContainAListOfRateTypes()
    {
        var content = await _response.Content.ReadAsStringAsync();
        var rateTypes = JsonConvert.DeserializeObject<List<RateTypeDto>>(content);
        rateTypes.Should().NotBeNull();
        rateTypes.Should().NotBeEmpty();
    }

    [Then("each rate type should have an Id, Name, and Description")]
    public async Task ThenEachRateTypeShouldHaveAnIdNameAndDescription()
    {
        var content = await _response.Content.ReadAsStringAsync();
        var rateTypes = JsonConvert.DeserializeObject<List<RateTypeDto>>(content);
        foreach (var rateType in rateTypes)
        {
            rateType.Id.Should().NotBe(0);
            rateType.Name.Should().NotBeNullOrWhiteSpace();
            rateType.Description.Should().NotBeNullOrWhiteSpace();
        }
    }

    [Then("the response should contain an error message")]
    public async Task ThenTheResponseShouldContainAnErrorMessage()
    {
        var content = await _response.Content.ReadAsStringAsync();
        content.Should().Contain("An error occurred");
    }
}

public class RateTypeDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
}