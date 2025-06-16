using Xunit.Gherkin.Quick;
using System.Net.Http;
using System.Threading.Tasks;
using FluentAssertions;
using Newtonsoft.Json.Linq;

[FeatureFile("PhaseSuffixes.feature")]
public class PhaseSuffixesSteps : Feature
{
    private readonly HttpClient _client = new HttpClient();
    private HttpResponseMessage _response;
    private JArray _jsonResponse;

    [Given("I have access to the Phase API")]
    public void GivenIHaveAccessToThePhaseAPI()
    {
        _client.BaseAddress = new Uri("http://localhost:5000");
    }

    [When("I send a GET request to /api/Phase/suffixes")]
    public async Task WhenISendAGETRequestToApiPhaseSuffixes()
    {
        _response = await _client.GetAsync("/api/Phase/suffixes");
        var content = await _response.Content.ReadAsStringAsync();
        _jsonResponse = JArray.Parse(content);
    }

    [Then("the API response should be 200")]
    public void ThenTheAPIResponseShouldBe200()
    {
        _response.StatusCode.Should().Be(System.Net.HttpStatusCode.OK);
    }

    [Then("the API response should be 500")]
    public void ThenTheAPIResponseShouldBe500()
    {
        _response.StatusCode.Should().Be(System.Net.HttpStatusCode.InternalServerError);
    }

    [Then("the response should contain a list of projects")]
    public void ThenTheResponseShouldContainAListOfProjects()
    {
        _jsonResponse.Should().NotBeNull();
        _jsonResponse.Should().BeOfType<JArray>();
    }

    [Then("the response should contain an error message")]
    public void ThenTheResponseShouldContainAnErrorMessage()
    {
        var errorMessage = _jsonResponse["error"].ToString();
        errorMessage.Should().NotBeNullOrEmpty();
    }

    [Then("the response should contain projects with fields: (.*)")]
    public void ThenTheResponseShouldContainProjectsWithFields(string fields)
    {
        var fieldList = fields.Split(',');
        foreach (var project in _jsonResponse)
        {
            foreach (var field in fieldList)
            {
                project[field.Trim()].Should().NotBeNull();
            }
        }
    }

    [Then("the response should be an empty list")]
    public void ThenTheResponseShouldBeAnEmptyList()
    {
        _jsonResponse.Should().BeEmpty();
    }
}