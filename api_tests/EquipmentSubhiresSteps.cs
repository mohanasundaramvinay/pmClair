using Xunit;
using Xunit.Gherkin.Quick;
using System.Net.Http;
using System.Threading.Tasks;
using FluentAssertions;

[FeatureFile("EquipmentSubhires.feature")]
public sealed class EquipmentSubhiresSteps : Feature
{
    private readonly HttpClient _client;
    private HttpResponseMessage _response;

    public EquipmentSubhiresSteps()
    {
        _client = new HttpClient { BaseAddress = new System.Uri("http://localhost:5000") };
    }

    [When("I send a GET request to /api/projects/(.*)/equipment/subhires")]
    public async Task WhenISendAGetRequestToApiProjectsEntityNoEquipmentSubhires(string entityNo)
    {
        _response = await _client.GetAsync($"/api/projects/{entityNo}/equipment/subhires");
    }

    [Then("the API response should be (.*)")]
    public void ThenTheApiResponseShouldBe(string expectedStatusCode)
    {
        _response.StatusCode.ToString().Should().Be(expectedStatusCode);
    }

    [And("the response should contain a list of equipment subhires")]
    public async Task AndTheResponseShouldContainAListOfEquipmentSubhires()
    {
        var content = await _response.Content.ReadAsStringAsync();
        content.Should().StartWith("[");
        content.Should().EndWith("]");
    }
}