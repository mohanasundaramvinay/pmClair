using Xunit.Gherkin.Quick;
using System.Net.Http;
using System.Threading.Tasks;
using FluentAssertions;
using Newtonsoft.Json;
using System.Collections.Generic;

[FeatureFile("ProjectClientContacts.feature")]
public sealed class ProjectClientContactsSteps : Feature
{
    private readonly HttpClient _client = new HttpClient();
    private HttpResponseMessage _response;
    private string _baseUrl = "http://localhost:5000/api/projects/";

    [Given("I have access to the Project Maintenance API")]
    public void GivenIHaveAccessToTheProjectMaintenanceAPI()
    {
        // Assume the API is running and accessible
    }

    [When("I send a GET request to /api/projects/(.*)/client-contacts")]
    public async Task WhenISendAGETRequestToApiProjectsEntityNoClientContacts(string entityNo)
    {
        _response = await _client.GetAsync(_baseUrl + entityNo + "/client-contacts");
    }

    [Then("the API response should be (.*)")]
    public void ThenTheAPIResponseShouldBe(int statusCode)
    {
        _response.StatusCode.Should().Be((System.Net.HttpStatusCode)statusCode);
    }

    [Then("the response should contain a list of client contacts")]
    public async Task ThenTheResponseShouldContainAListOfClientContacts()
    {
        var content = await _response.Content.ReadAsStringAsync();
        var contacts = JsonConvert.DeserializeObject<List<ProjectClientContactModel>>(content);
        contacts.Should().NotBeNull();
        contacts.Should().NotBeEmpty();
    }

    [Then("the response should be an empty list")]
    public async Task ThenTheResponseShouldBeAnEmptyList()
    {
        var content = await _response.Content.ReadAsStringAsync();
        var contacts = JsonConvert.DeserializeObject<List<ProjectClientContactModel>>(content);
        contacts.Should().BeEmpty();
    }
}