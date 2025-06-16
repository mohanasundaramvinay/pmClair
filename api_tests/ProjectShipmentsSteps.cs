using Xunit.Gherkin.Quick;
using System.Net.Http;
using System.Threading.Tasks;
using FluentAssertions;
using Newtonsoft.Json;
using System.Collections.Generic;

[FeatureFile("ProjectShipments.feature")]
public sealed class ProjectShipmentsSteps : Feature
{
    private readonly HttpClient _client = new HttpClient();
    private HttpResponseMessage _response;
    private string _baseUrl = "http://localhost:5000/api/projects/";

    [Given("I have access to the Project Maintenance API")]
    public void GivenIHaveAccessToTheProjectMaintenanceAPI()
    {
        // Assume the API is running and accessible
    }

    [When("I send a GET request to /api/projects/(.*)/shipments")]
    public async Task WhenISendAGETRequestToApiProjectsShipments(string entityNo)
    {
        _response = await _client.GetAsync(_baseUrl + entityNo + "/shipments");
    }

    [Then("the API response should be a list of shipments with status code (\d+)")]
    public async Task ThenTheAPIResponseShouldBeAListOfShipmentsWithStatusCode(int statusCode)
    {
        _response.StatusCode.Should().Be((System.Net.HttpStatusCode)statusCode);
        var content = await _response.Content.ReadAsStringAsync();
        var shipments = JsonConvert.DeserializeObject<List<object>>(content);
        shipments.Should().NotBeNull();
    }

    [Then("the API response should be an error with status code (\d+)")]
    public void ThenTheAPIResponseShouldBeAnErrorWithStatusCode(int statusCode)
    {
        _response.StatusCode.Should().Be((System.Net.HttpStatusCode)statusCode);
    }

    [Then("the API response should be an empty list with status code (\d+)")]
    public async Task ThenTheAPIResponseShouldBeAnEmptyListWithStatusCode(int statusCode)
    {
        _response.StatusCode.Should().Be((System.Net.HttpStatusCode)statusCode);
        var content = await _response.Content.ReadAsStringAsync();
        var shipments = JsonConvert.DeserializeObject<List<object>>(content);
        shipments.Should().BeEmpty();
    }
}