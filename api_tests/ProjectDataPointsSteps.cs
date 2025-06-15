using Xunit.Gherkin.Quick;
using System.Net.Http;
using System.Threading.Tasks;
using FluentAssertions;
using Newtonsoft.Json.Linq;

[FeatureFile("ProjectDataPoints.feature")]
public sealed class ProjectDataPointsSteps : Feature
{
    private readonly HttpClient _client = new HttpClient();
    private HttpResponseMessage _response;
    private string _baseUrl = "http://localhost:5000/api/ProjectDataPoints";

    [Given("I have access to the Project Data Points API")]
    public void GivenIHaveAccessToTheProjectDataPointsAPI()
    {
        // Assume the API is running and accessible
    }

    [When("I send a GET request to /api/ProjectDataPoints/all-data")]
    public async Task WhenISendAGETRequestToAllData()
    {
        _response = await _client.GetAsync(_baseUrl + "/all-data");
    }

    [When("I send a GET request to /api/ProjectDataPoints/all-data?projectNumber=<ProjectNumber>")]
    public async Task WhenISendAGETRequestToAllDataWithProjectNumber(string projectNumber)
    {
        _response = await _client.GetAsync(_baseUrl + $"/all-data?projectNumber={projectNumber}");
    }

    [Then("the API response should have status code <StatusCode>")]
    public void ThenTheAPIResponseShouldHaveStatusCode(int statusCode)
    {
        _response.StatusCode.Should().Be((System.Net.HttpStatusCode)statusCode);
    }

    [Then("the response should contain a list of companies")]
    public async Task ThenTheResponseShouldContainAListOfCompanies()
    {
        var content = await _response.Content.ReadAsStringAsync();
        var json = JToken.Parse(content);
        json["Companies"].Should().NotBeNull();
    }

    [Then("the response should contain a list of project statuses")]
    public async Task ThenTheResponseShouldContainAListOfProjectStatuses()
    {
        var content = await _response.Content.ReadAsStringAsync();
        var json = JToken.Parse(content);
        json["ProjectStatuses"].Should().NotBeNull();
    }

    [Then("the response should contain a list of warehouses")]
    public async Task ThenTheResponseShouldContainAListOfWarehouses()
    {
        var content = await _response.Content.ReadAsStringAsync();
        var json = JToken.Parse(content);
        json["Warehouses"].Should().NotBeNull();
    }

    [Then("the response should contain a list of rate types")]
    public async Task ThenTheResponseShouldContainAListOfRateTypes()
    {
        var content = await _response.Content.ReadAsStringAsync();
        var json = JToken.Parse(content);
        json["RateTypes"].Should().NotBeNull();
    }

    [Then("the response should contain a list of contact categories")]
    public async Task ThenTheResponseShouldContainAListOfContactCategories()
    {
        var content = await _response.Content.ReadAsStringAsync();
        var json = JToken.Parse(content);
        json["ContactCategories"].Should().NotBeNull();
    }
}