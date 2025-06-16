using Xunit.Gherkin.Quick;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Collections.Generic;
using Xunit;

[FeatureFile("RetrieveRecentProjects.feature")]
public class RetrieveRecentProjectsSteps : Feature
{
    private readonly HttpClient _client = new HttpClient();
    private HttpResponseMessage _response;
    private List<Project> _projects;

    [Given("I have access to the Project API")]
    public void GivenIHaveAccessToTheProjectAPI()
    {
        _client.BaseAddress = new System.Uri("http://localhost:5000");
    }

    [When("I send a GET request to /api/Project/recent with numberOfProjects=(.*)")]
    public async Task WhenISendAGETRequestToApiProjectRecentWithNumberOfProjects(int numberOfProjects)
    {
        var url = $"/api/Project/recent?numberOfProjects={numberOfProjects}";
        _response = await _client.GetAsync(url);
        var content = await _response.Content.ReadAsStringAsync();
        _projects = JsonConvert.DeserializeObject<List<Project>>(content);
    }

    [Then("the API response should be a list of (.*) projects")]
    public void ThenTheAPIResponseShouldBeAListOfProjects(int expectedCount)
    {
        Assert.Equal(expectedCount, _projects.Count);
    }

    [Then("the response status code should be (.*)")]
    public void ThenTheResponseStatusCodeShouldBe(int statusCode)
    {
        Assert.Equal(statusCode, (int)_response.StatusCode);
    }
}

public class Project
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string StartDate { get; set; }
    public string EndDate { get; set; }
    public string Status { get; set; }
    public List<string> TeamMembers { get; set; }
}