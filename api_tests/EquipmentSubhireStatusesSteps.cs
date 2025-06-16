using Xunit;
using Xunit.Gherkin.Quick;
using System.Net.Http;
using System.Threading.Tasks;
using FluentAssertions;
using Newtonsoft.Json.Linq;

[FeatureFile("EquipmentSubhireStatuses.feature")]
public sealed class EquipmentSubhireStatusesSteps : Feature
{
    private readonly HttpClient _client;
    private HttpResponseMessage _response;

    public EquipmentSubhireStatusesSteps()
    {
        _client = new HttpClient();
        _client.BaseAddress = new System.Uri("http://localhost:5000");
    }

    [When("I send a GET request to /api/ProjectDataPoints/equipment-subhire-statuses")]
    public async Task WhenISendAGetRequestToApiProjectDataPointsEquipmentSubhireStatuses()
    {
        _response = await _client.GetAsync("/api/ProjectDataPoints/equipment-subhire-statuses");
    }

    [Then("the API response should be (.*)")]
    public void ThenTheApiResponseShouldBe(int statusCode)
    {
        _response.StatusCode.Should().Be((System.Net.HttpStatusCode)statusCode);
    }

    [Then("the response should contain a list of equipment subhire statuses")]
    public async Task ThenTheResponseShouldContainAListOfEquipmentSubhireStatuses()
    {
        var content = await _response.Content.ReadAsStringAsync();
        var jsonArray = JArray.Parse(content);
        jsonArray.Should().NotBeEmpty();
    }

    [Then("the response should contain fields (.*)")]
    public async Task ThenTheResponseShouldContainFields(string fields)
    {
        var content = await _response.Content.ReadAsStringAsync();
        var jsonArray = JArray.Parse(content);
        var fieldList = fields.Split(',');
        foreach (var item in jsonArray)
        {
            foreach (var field in fieldList)
            {
                item.Should().ContainKey(field.Trim());
            }
        }
    }
}