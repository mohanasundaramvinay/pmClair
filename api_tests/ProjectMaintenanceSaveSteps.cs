using Xunit.Gherkin.Quick;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Text;
using Xunit;

[FeatureFile("ProjectMaintenanceSave.feature")]
public sealed class ProjectMaintenanceSaveSteps : Feature
{
    private readonly HttpClient _client = new HttpClient();
    private HttpResponseMessage _response;

    [Given("I have access to the Project Maintenance API")]
    public void GivenIHaveAccessToTheProjectMaintenanceAPI()
    {
        _client.BaseAddress = new System.Uri("http://localhost:5000/api/");
    }

    [When("I send a POST request to /api/projects/(.*)/save with the following project data:")]
    public async Task WhenISendAPOSTRequestToApiProjectsEntityNoSaveWithTheFollowingProjectData(string entityNo, Table table)
    {
        var row = table.Rows[0];
        var projectData = new
        {
            projectId = row["projectId"],
            phases = JsonConvert.DeserializeObject(row["phases"]),
            notes = row["notes"],
            budget = int.Parse(row["budget"]),
            resources = JsonConvert.DeserializeObject(row["resources"])
        };
        var content = new StringContent(JsonConvert.SerializeObject(projectData), Encoding.UTF8, "application/json");
        _response = await _client.PostAsync($"projects/{entityNo}/save", content);
    }

    [Then("the API response should be (.*)")]
    public void ThenTheAPIResponseShouldBe(string expectedStatusCode)
    {
        var expectedStatus = (System.Net.HttpStatusCode)Enum.Parse(typeof(System.Net.HttpStatusCode), expectedStatusCode.Replace(" ", ""));
        Assert.Equal(expectedStatus, _response.StatusCode);
    }
}