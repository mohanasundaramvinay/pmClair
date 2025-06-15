using Xunit.Gherkin.Quick;
using System.Net.Http;
using System.Threading.Tasks;
using FluentAssertions;
using Newtonsoft.Json;
using System.Collections.Generic;

[FeatureFile("ProjectFavorites.feature")]
public sealed class ProjectFavoritesSteps : Feature
{
    private readonly HttpClient _client = new HttpClient();
    private HttpResponseMessage _response;
    private string _baseUrl = "http://localhost:5000/api/Project/favorites";

    [Given("I have access to the Project API")]
    public void GivenIHaveAccessToTheProjectAPI()
    {
        // Assume the API is running and accessible
    }

    [When("I send a GET request to /api/Project/favorites")]
    public async Task WhenISendAGETRequestToApiProjectFavorites()
    {
        _response = await _client.GetAsync(_baseUrl);
    }

    [Then("the API response should be a list of favorite projects")]
    public async Task ThenTheAPIResponseShouldBeAListOfFavoriteProjects()
    {
        var content = await _response.Content.ReadAsStringAsync();
        var projects = JsonConvert.DeserializeObject<List<Project>>(content);
        projects.Should().NotBeNull();
    }

    [Then("the response status code should be 200")]
    public void ThenTheResponseStatusCodeShouldBe200()
    {
        _response.StatusCode.Should().Be(System.Net.HttpStatusCode.OK);
    }

    [Then("the API response should be an error message")]
    public async Task ThenTheAPIResponseShouldBeAnErrorMessage()
    {
        var content = await _response.Content.ReadAsStringAsync();
        content.Should().Contain("error");
    }

    [Then("the response status code should be 500")]
    public void ThenTheResponseStatusCodeShouldBe500()
    {
        _response.StatusCode.Should().Be(System.Net.HttpStatusCode.InternalServerError);
    }

    [Then("the API response should contain projects with fields: (.*)")]
    public async Task ThenTheAPIResponseShouldContainProjectsWithFields(string fields)
    {
        var content = await _response.Content.ReadAsStringAsync();
        var projects = JsonConvert.DeserializeObject<List<Project>>(content);
        var fieldList = fields.Split(',');
        foreach (var project in projects)
        {
            foreach (var field in fieldList)
            {
                project.GetType().GetProperty(field.Trim()).Should().NotBeNull();
            }
        }
    }

    [Then("the API response should be an empty list")]
    public async Task ThenTheAPIResponseShouldBeAnEmptyList()
    {
        var content = await _response.Content.ReadAsStringAsync();
        var projects = JsonConvert.DeserializeObject<List<Project>>(content);
        projects.Should().BeEmpty();
    }
}

public class Project
{
    public string Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string StartDate { get; set; }
    public string EndDate { get; set; }
    public string Status { get; set; }
    public string Owner { get; set; }
}