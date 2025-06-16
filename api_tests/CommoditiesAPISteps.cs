using Xunit;
using Xunit.Gherkin.Quick;
using System.Net.Http;
using System.Threading.Tasks;
using FluentAssertions;
using Newtonsoft.Json;
using System.Collections.Generic;

[FeatureFile("CommoditiesAPI.feature")]
public sealed class CommoditiesAPISteps : Feature
{
    private readonly HttpClient _client;
    private HttpResponseMessage _response;
    private string _responseContent;

    public CommoditiesAPISteps()
    {
        _client = new HttpClient();
        _client.BaseAddress = new System.Uri("http://localhost:5000");
    }

    [When("I send a GET request to /api/ProjectDataPoints/commodities")]
    public async Task WhenISendAGetRequestToApiProjectDataPointsCommodities()
    {
        _response = await _client.GetAsync("/api/ProjectDataPoints/commodities");
        _responseContent = await _response.Content.ReadAsStringAsync();
    }

    [Then("the API response should be (.*) and contain a list of commodities")]
    public void ThenTheApiResponseShouldBeAndContainAListOfCommodities(int statusCode)
    {
        _response.StatusCode.Should().Be((System.Net.HttpStatusCode)statusCode);
        var commodities = JsonConvert.DeserializeObject<List<Commodity>>(_responseContent);
        commodities.Should().NotBeNull();
        commodities.Should().NotBeEmpty();
    }

    [Then("the API response should be (.*) with an error message")]
    public void ThenTheApiResponseShouldBeWithAnErrorMessage(int statusCode)
    {
        _response.StatusCode.Should().Be((System.Net.HttpStatusCode)statusCode);
        _responseContent.Should().Contain("error");
    }

    [Then("each commodity should have a CommodityCode, Description, Category, and IsActive")]
    public void ThenEachCommodityShouldHaveACommodityCodeDescriptionCategoryAndIsActive()
    {
        var commodities = JsonConvert.DeserializeObject<List<Commodity>>(_responseContent);
        foreach (var commodity in commodities)
        {
            commodity.CommodityCode.Should().NotBeNullOrEmpty();
            commodity.Description.Should().NotBeNullOrEmpty();
            commodity.Category.Should().NotBeNullOrEmpty();
            commodity.IsActive.Should().BeOfType<bool>();
        }
    }
}

public class Commodity
{
    public string CommodityCode { get; set; }
    public string Description { get; set; }
    public string Category { get; set; }
    public bool IsActive { get; set; }
}