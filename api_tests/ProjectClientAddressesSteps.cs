using Xunit.Gherkin.Quick;
using System.Net.Http;
using System.Threading.Tasks;
using FluentAssertions;
using Newtonsoft.Json;
using System.Collections.Generic;

[FeatureFile("ProjectClientAddresses.feature")]
public sealed class ProjectClientAddressesSteps : Feature
{
    private readonly HttpClient _client = new HttpClient();
    private HttpResponseMessage _response;
    private string _entityNo;

    [Given("I have access to the Project Maintenance API")]
    public void GivenIHaveAccessToTheProjectMaintenanceAPI()
    {
        _client.BaseAddress = new System.Uri("http://localhost:5000/api/");
    }

    [When("I send a GET request to /api/projects/(.*)/client-addresses")]
    public async Task WhenISendAGETRequestToApiProjectsEntityNoClientAddresses(string entityNo)
    {
        _entityNo = entityNo;
        _response = await _client.GetAsync($"projects/{_entityNo}/client-addresses");
    }

    [Then("the API response should be (.*)")]
    public void ThenTheAPIResponseShouldBe(int statusCode)
    {
        _response.StatusCode.Should().Be((System.Net.HttpStatusCode)statusCode);
    }

    [Then("the response should contain a list of client addresses")]
    public async Task ThenTheResponseShouldContainAListOfClientAddresses()
    {
        var content = await _response.Content.ReadAsStringAsync();
        var addresses = JsonConvert.DeserializeObject<List<ProjectClientAddressModel>>(content);
        addresses.Should().NotBeNull();
        addresses.Should().NotBeEmpty();
    }

    [Then("the response should be an empty list")]
    public async Task ThenTheResponseShouldBeAnEmptyList()
    {
        var content = await _response.Content.ReadAsStringAsync();
        var addresses = JsonConvert.DeserializeObject<List<ProjectClientAddressModel>>(content);
        addresses.Should().BeEmpty();
    }
}