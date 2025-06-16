using Xunit.Gherkin.Quick;
using System.Net.Http;
using System.Threading.Tasks;
using FluentAssertions;
using Newtonsoft.Json;
using System.Collections.Generic;

[FeatureFile("ProjectBidExpenses.feature")]
public sealed class ProjectBidExpensesSteps : Feature
{
    private readonly HttpClient _client = new HttpClient();
    private HttpResponseMessage _response;
    private string _entityNo;

    [Given("I have access to the Project Maintenance API")]
    public void GivenIHaveAccessToTheProjectMaintenanceAPI()
    {
        _client.BaseAddress = new System.Uri("http://localhost:5000");
    }

    [When("I send a GET request to /api/projects/(.*)/bid-expenses")]
    public async Task WhenISendAGETRequestToApiProjectsEntityNoBidExpenses(string entityNo)
    {
        _entityNo = entityNo;
        _response = await _client.GetAsync($"/api/projects/{_entityNo}/bid-expenses");
    }

    [Then("the API response should be (.*)")]
    public void ThenTheAPIResponseShouldBe(int statusCode)
    {
        _response.StatusCode.Should().Be((System.Net.HttpStatusCode)statusCode);
    }

    [Then("the response should contain a list of bid expenses")]
    public async Task ThenTheResponseShouldContainAListOfBidExpenses()
    {
        var content = await _response.Content.ReadAsStringAsync();
        var expenses = JsonConvert.DeserializeObject<List<ProjectBidExpenseModel>>(content);
        expenses.Should().NotBeNull();
        expenses.Should().BeOfType<List<ProjectBidExpenseModel>>();
    }

    [Then("the response should be an empty list")]
    public async Task ThenTheResponseShouldBeAnEmptyList()
    {
        var content = await _response.Content.ReadAsStringAsync();
        var expenses = JsonConvert.DeserializeObject<List<ProjectBidExpenseModel>>(content);
        expenses.Should().BeEmpty();
    }
}