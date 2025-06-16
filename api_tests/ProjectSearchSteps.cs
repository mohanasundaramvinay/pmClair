using Xunit.Gherkin.Quick;
using System.Net.Http;
using System.Threading.Tasks;
using FluentAssertions;
using Newtonsoft.Json;
using System.Collections.Generic;

[FeatureFile("ProjectSearch.feature")]
public class ProjectSearchSteps : Feature
{
    private readonly HttpClient _client = new HttpClient();
    private HttpResponseMessage _response;
    private string _baseUrl = "http://localhost:5000/api/Project/search/";

    [Given("I have access to the Project API")]
    public void GivenIHaveAccessToTheProjectAPI()
    {
        // Assume the API is running and accessible
    }

    [When("I send a GET request to /api/Project/search/(.*)")]
    public async Task WhenISendAGETRequestToApiProjectSearch(string searchTerm)
    {
        _response = await _client.GetAsync(_baseUrl + searchTerm);
    }

    [Then("the API response should contain a list of projects")]
    public async Task ThenTheAPIResponseShouldContainAListOfProjects()
    {
        var content = await _response.Content.ReadAsStringAsync();
        var projects = JsonConvert.DeserializeObject<List<Project>>(content);
        projects.Should().NotBeNull();
        projects.Should().NotBeEmpty();
    }

    [Then("the API response should be an empty list")]
    public async Task ThenTheAPIResponseShouldBeAnEmptyList()
    {
        var content = await _response.Content.ReadAsStringAsync();
        var projects = JsonConvert.DeserializeObject<List<Project>>(content);
        projects.Should().BeEmpty();
    }

    [Then("the API response should contain an error message")]
    public async Task ThenTheAPIResponseShouldContainAnErrorMessage()
    {
        var content = await _response.Content.ReadAsStringAsync();
        content.Should().Contain("error");
    }

    [Then("the response status code should be (\d+)")]
    public void ThenTheResponseStatusCodeShouldBe(int statusCode)
    {
        ((int)_response.StatusCode).Should().Be(statusCode);
    }
}