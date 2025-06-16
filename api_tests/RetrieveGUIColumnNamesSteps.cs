using Xunit.Gherkin.Quick;
using System.Net.Http;
using System.Threading.Tasks;
using FluentAssertions;
using Newtonsoft.Json;
using System.Collections.Generic;

[FeatureFile("RetrieveGUIColumnNames.feature")]
public sealed class RetrieveGUIColumnNamesSteps : Feature
{
    private readonly HttpClient _client;
    private HttpResponseMessage _response;
    private string _scenarioDescription;

    public RetrieveGUIColumnNamesSteps()
    {
        _client = new HttpClient();
    }

    [Given("the API is running")]
    public void GivenTheApiIsRunning()
    {
        // Assume the API is running
    }

    [Given("the server is configured to simulate an error")]
    public void GivenTheServerIsConfiguredToSimulateAnError()
    {
        // Configuration to simulate server error
    }

    [Given("the database is empty")]
    public void GivenTheDatabaseIsEmpty()
    {
        // Configuration to ensure database is empty
    }

    [Given("the database contains a large number of GUI column names")]
    public void GivenTheDatabaseContainsALargeNumberOfGUIColumnNames()
    {
        // Configuration to populate database with large dataset
    }

    [Given("the server is configured to respond slowly")]
    public void GivenTheServerIsConfiguredToRespondSlowly()
    {
        // Configuration to simulate slow server response
    }

    [When("I send a GET request to /api/ProjectDataPoints/gui-column-names")]
    public async Task WhenISendAGetRequestToApiProjectDataPointsGuiColumnNames()
    {
        _response = await _client.GetAsync("http://localhost:5000/api/ProjectDataPoints/gui-column-names");
    }

    [When("I send a GET request to /api/ProjectDataPoints/invalid-endpoint")]
    public async Task WhenISendAGetRequestToApiProjectDataPointsInvalidEndpoint()
    {
        _response = await _client.GetAsync("http://localhost:5000/api/ProjectDataPoints/invalid-endpoint");
    }

    [Then("the API response should be 200")]
    public void ThenTheApiResponseShouldBe200()
    {
        _response.StatusCode.Should().Be(200);
    }

    [Then("the API response should be 404")]
    public void ThenTheApiResponseShouldBe404()
    {
        _response.StatusCode.Should().Be(404);
    }

    [Then("the API response should be 500")]
    public void ThenTheApiResponseShouldBe500()
    {
        _response.StatusCode.Should().Be(500);
    }

    [Then("the response should contain a list of GUI column names")]
    public async Task ThenTheResponseShouldContainAListOfGUIColumnNames()
    {
        var content = await _response.Content.ReadAsStringAsync();
        var guiColumnNames = JsonConvert.DeserializeObject<List<GUIColumnName>>(content);
        guiColumnNames.Should().NotBeNull();
        guiColumnNames.Should().NotBeEmpty();
    }

    [Then("the response should be an empty list")]
    public async Task ThenTheResponseShouldBeAnEmptyList()
    {
        var content = await _response.Content.ReadAsStringAsync();
        var guiColumnNames = JsonConvert.DeserializeObject<List<GUIColumnName>>(content);
        guiColumnNames.Should().BeEmpty();
    }

    [Then("the response should contain a large list of GUI column names")]
    public async Task ThenTheResponseShouldContainALargeListOfGUIColumnNames()
    {
        var content = await _response.Content.ReadAsStringAsync();
        var guiColumnNames = JsonConvert.DeserializeObject<List<GUIColumnName>>(content);
        guiColumnNames.Count.Should().BeGreaterThan(1000); // Assuming large dataset is > 1000
    }

    [Then("the response time should be greater than expected")]
    public void ThenTheResponseTimeShouldBeGreaterThanExpected()
    {
        // Check response time
    }
}