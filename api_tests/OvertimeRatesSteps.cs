using Xunit;
using Xunit.Gherkin.Quick;
using System.Net.Http;
using System.Threading.Tasks;
using FluentAssertions;
using Newtonsoft.Json;
using System.Collections.Generic;

[FeatureFile("OvertimeRates.feature")]
public sealed class OvertimeRatesSteps : Feature
{
    private readonly HttpClient _client;
    private HttpResponseMessage _response;
    private string _responseContent;

    public OvertimeRatesSteps()
    {
        _client = new HttpClient();
        _client.BaseAddress = new System.Uri("http://localhost:5000");
    }

    [When("I send a GET request to /api/ProjectDataPoints/overtime-rates")]
    public async Task WhenISendAGetRequestToApiProjectDataPointsOvertimeRates()
    {
        _response = await _client.GetAsync("/api/ProjectDataPoints/overtime-rates");
        _responseContent = await _response.Content.ReadAsStringAsync();
    }

    [Then("the API response should be (.*)")]
    public void ThenTheApiResponseShouldBe(int statusCode)
    {
        _response.StatusCode.Should().Be((System.Net.HttpStatusCode)statusCode);
    }

    [Then("the response should contain a list of overtime rates")]
    public void ThenTheResponseShouldContainAListOfOvertimeRates()
    {
        var overtimeRates = JsonConvert.DeserializeObject<List<OvertimeRateDto>>(_responseContent);
        overtimeRates.Should().NotBeNull();
        overtimeRates.Should().NotBeEmpty();
    }

    [Then("the response should contain an error message")]
    public void ThenTheResponseShouldContainAnErrorMessage()
    {
        _responseContent.Should().Contain("error");
    }

    [Then("each overtime rate should have a RateType, Description, Multiplier, and ActiveStatus")]
    public void ThenEachOvertimeRateShouldHaveARateTypeDescriptionMultiplierAndActiveStatus()
    {
        var overtimeRates = JsonConvert.DeserializeObject<List<OvertimeRateDto>>(_responseContent);
        foreach (var rate in overtimeRates)
        {
            rate.RateType.Should().NotBeNullOrEmpty();
            rate.Description.Should().NotBeNullOrEmpty();
            rate.Multiplier.Should().BeGreaterThan(0);
            rate.ActiveStatus.Should().BeOfType<bool>();
        }
    }
}

public class OvertimeRateDto
{
    public string RateType { get; set; }
    public string Description { get; set; }
    public double Multiplier { get; set; }
    public bool ActiveStatus { get; set; }
}