using Xunit.Gherkin.Quick;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Collections.Generic;
using FluentAssertions;

[FeatureFile("TaxCodesFeature.feature")]
public sealed class TaxCodesSteps : Feature
{
    private readonly HttpClient _client;
    private HttpResponseMessage _response;
    private string _responseContent;

    public TaxCodesSteps()
    {
        _client = new HttpClient();
    }

    [When("I send a GET request to /api/ProjectDataPoints/tax-codes")]
    public async Task WhenISendAGetRequestToApiProjectDataPointsTaxCodes()
    {
        _response = await _client.GetAsync("http://localhost:5000/api/ProjectDataPoints/tax-codes");
        _responseContent = await _response.Content.ReadAsStringAsync();
    }

    [Then("the API response should be (.*)")]
    public void ThenTheApiResponseShouldBe(int statusCode)
    {
        _response.StatusCode.Should().Be((System.Net.HttpStatusCode)statusCode);
    }

    [Then("the response should contain a list of tax codes")]
    public void ThenTheResponseShouldContainAListOfTaxCodes()
    {
        var taxCodes = JsonConvert.DeserializeObject<List<TaxCodeDto>>(_responseContent);
        taxCodes.Should().NotBeNull();
        taxCodes.Should().NotBeEmpty();
    }

    [Then("each tax code should have a (.*)")]
    public void ThenEachTaxCodeShouldHaveAField(string field)
    {
        var taxCodes = JsonConvert.DeserializeObject<List<TaxCodeDto>>(_responseContent);
        foreach (var taxCode in taxCodes)
        {
            taxCode.GetType().GetProperty(field).Should().NotBeNull();
        }
    }

    [Then("each tax code rate should be a valid (.*)")]
    public void ThenEachTaxCodeRateShouldBeAValidRateType(string rateType)
    {
        var taxCodes = JsonConvert.DeserializeObject<List<TaxCodeDto>>(_responseContent);
        foreach (var taxCode in taxCodes)
        {
            decimal.TryParse(taxCode.Rate.ToString(), out _).Should().BeTrue();
        }
    }

    [Then("each tax code active status should be a boolean")]
    public void ThenEachTaxCodeActiveStatusShouldBeABoolean()
    {
        var taxCodes = JsonConvert.DeserializeObject<List<TaxCodeDto>>(_responseContent);
        foreach (var taxCode in taxCodes)
        {
            taxCode.IsActive.Should().BeOfType<bool>();
        }
    }
}