using Xunit;
using Xunit.Gherkin.Quick;
using System.Net.Http;
using System.Threading.Tasks;
using FluentAssertions;
using Newtonsoft.Json.Linq;

[FeatureFile("UserPermissionsFeature.feature")]
public sealed class UserPermissionsSteps : Feature
{
    private readonly HttpClient _client;
    private HttpResponseMessage _response;
    private JObject _jsonResponse;

    public UserPermissionsSteps()
    {
        _client = new HttpClient();
        _client.BaseAddress = new System.Uri("http://localhost:5000");
    }

    [Given("I have access to the ProjectDataPoints API")]
    public void GivenIHaveAccessToTheProjectDataPointsAPI()
    {
        // Assume access is granted
    }

    [When("I send a GET request to /api/ProjectDataPoints/user-permissions")]
    public async Task WhenISendAGETRequestToApiProjectDataPointsUserPermissions()
    {
        _response = await _client.GetAsync("/api/ProjectDataPoints/user-permissions");
        var jsonString = await _response.Content.ReadAsStringAsync();
        _jsonResponse = JObject.Parse(jsonString);
    }

    [Then("the API response should be: (.*)")]
    public void ThenTheAPIResponseShouldBe(int statusCode)
    {
        _response.StatusCode.Should().Be((System.Net.HttpStatusCode)statusCode);
    }

    [And("the response should contain role: (.*)")]
    public void AndTheResponseShouldContainRole(string role)
    {
        if (role != "null")
        {
            _jsonResponse["role"].ToString().Should().Be(role);
        }
    }

    [And("the response should contain permissions: (.*)")]
    public void AndTheResponseShouldContainPermissions(string permissions)
    {
        if (permissions != "null")
        {
            var expectedPermissions = JArray.Parse(permissions);
            _jsonResponse["permissions"].Should().BeEquivalentTo(expectedPermissions);
        }
    }

    [And("the response should contain access levels: (.*)")]
    public void AndTheResponseShouldContainAccessLevels(string accessLevels)
    {
        if (accessLevels != "null")
        {
            var expectedAccessLevels = JArray.Parse(accessLevels);
            _jsonResponse["accessLevels"].Should().BeEquivalentTo(expectedAccessLevels);
        }
    }

    [And("the response should contain division: (.*)")]
    public void AndTheResponseShouldContainDivision(string division)
    {
        if (division != "null")
        {
            _jsonResponse["division"].ToString().Should().Be(division);
        }
    }
}