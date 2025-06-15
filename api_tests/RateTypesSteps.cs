using Xunit;
using Xunit.Gherkin.Quick;
using System.Net.Http;
using System.Threading.Tasks;
using FluentAssertions;
using Newtonsoft.Json;
using System.Collections.Generic;

[FeatureFile("RateTypesFeature.feature")]
public sealed class RateTypesSteps : Feature
{
    private readonly HttpClient _client;
    private HttpResponseMessage _response;
    private string _responseContent;

    public RateTypesSteps()
    {
        _client = new HttpClient();
        _client.BaseAddress = new System.Uri("http://localhost:5000");
    }

    [When("I send a GET request to /api/ProjectDataPoints/rate-types")]
    public async Task WhenISendAGetRequestToApiProjectDataPointsRateTypes()
    {
        _response = await _client.GetAsync("/api/ProjectDataPoints/rate-types");
        _responseContent = await _response.Content.ReadAsStringAsync();
    }

    [Then("the API response should be (.*)")]
    public void ThenTheApiResponseShouldBe(int statusCode)
    {
        _response.StatusCode.Should().Be((System.Net.HttpStatusCode)statusCode);
    }

    [Then("the response should contain a list of rate types")]
    public void ThenTheResponseShouldContainAListOfRateTypes()
    {
        var rateTypes = JsonConvert.DeserializeObject<List<RateType>>(_responseContent);
        rateTypes.Should().NotBeNull();
        rateTypes.Should().NotBeEmpty();
    }

    [Then("each rate type should have the fields: RateTypeCode, Description, SortOrder, DaysPerUnit, IsDaily, IsWeekly, IsMonthly")]
    public void ThenEachRateTypeShouldHaveTheFields()
    {
        var rateTypes = JsonConvert.DeserializeObject<List<RateType>>(_responseContent);
        foreach (var rateType in rateTypes)
        {
            rateType.RateTypeCode.Should().NotBeNullOrEmpty();
            rateType.Description.Should().NotBeNullOrEmpty();
            rateType.SortOrder.Should().BeGreaterThan(0);
            rateType.DaysPerUnit.Should().BeGreaterThan(0);
            rateType.IsDaily.Should().BeOfType<bool>();
            rateType.IsWeekly.Should().BeOfType<bool>();
            rateType.IsMonthly.Should().BeOfType<bool>();
        }
    }

    [Then("the response should contain an error message")]
    public void ThenTheResponseShouldContainAnErrorMessage()
    {
        _responseContent.Should().Contain("error");
    }

    public class RateType
    {
        public string RateTypeCode { get; set; }
        public string Description { get; set; }
        public int SortOrder { get; set; }
        public double DaysPerUnit { get; set; }
        public bool IsDaily { get; set; }
        public bool IsWeekly { get; set; }
        public bool IsMonthly { get; set; }
    }
}