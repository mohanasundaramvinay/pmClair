using Xunit;
using Xunit.Gherkin.Quick;
using System.Net.Http;
using System.Threading.Tasks;
using FluentAssertions;
using Newtonsoft.Json;
using System.Collections.Generic;

[FeatureFile("ProductionScheduleEventTypes.feature")]
public class ProductionScheduleEventTypesSteps : Feature
{
    private readonly HttpClient _client;
    private HttpResponseMessage _response;

    public ProductionScheduleEventTypesSteps()
    {
        _client = new HttpClient();
        _client.BaseAddress = new System.Uri("http://localhost:5000");
    }

    [When("I send a GET request to /api/ProjectDataPoints/production-schedule-event-types/all")]
    public async Task WhenISendAGetRequest()
    {
        _response = await _client.GetAsync("/api/ProjectDataPoints/production-schedule-event-types/all");
    }

    [Then("the API response should be (.*)")]
    public void ThenTheApiResponseShouldBe(int statusCode)
    {
        _response.StatusCode.Should().Be((System.Net.HttpStatusCode)statusCode);
    }

    [And("the response should contain a list of production schedule event types")]
    public async Task AndTheResponseShouldContainAList()
    {
        var content = await _response.Content.ReadAsStringAsync();
        var eventTypes = JsonConvert.DeserializeObject<List<ProductionScheduleEventType>>(content);
        eventTypes.Should().NotBeNull();
        eventTypes.Should().NotBeEmpty();
    }

    [And("each event type should have the fields: EventTypeCode, Description, ColorCode, SortOrder, IsActive")]
    public async Task AndEachEventTypeShouldHaveTheFields()
    {
        var content = await _response.Content.ReadAsStringAsync();
        var eventTypes = JsonConvert.DeserializeObject<List<ProductionScheduleEventType>>(content);
        foreach (var eventType in eventTypes)
        {
            eventType.EventTypeCode.Should().NotBeNullOrEmpty();
            eventType.Description.Should().NotBeNullOrEmpty();
            eventType.ColorCode.Should().NotBeNullOrEmpty();
            eventType.SortOrder.Should().BeGreaterThan(0);
            eventType.IsActive.Should().BeOfType<bool>();
        }
    }
}

public class ProductionScheduleEventType
{
    public string EventTypeCode { get; set; }
    public string Description { get; set; }
    public string ColorCode { get; set; }
    public int SortOrder { get; set; }
    public bool IsActive { get; set; }
}