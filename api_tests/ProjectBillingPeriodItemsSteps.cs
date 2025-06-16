using Xunit.Gherkin.Quick;
using System.Net.Http;
using System.Threading.Tasks;
using FluentAssertions;
using Newtonsoft.Json;
using System.Collections.Generic;

[FeatureFile("ProjectBillingPeriodItems.feature")]
public class ProjectBillingPeriodItemsSteps : Feature
{
    private readonly HttpClient _client = new HttpClient();
    private HttpResponseMessage _response;
    private string _baseUrl = "http://localhost:5000/api/projects/";

    [Given("I have access to the Project Maintenance API")]
    public void GivenIHaveAccessToTheProjectMaintenanceAPI()
    {
        // Assume the API is running and accessible
    }

    [When("I send a GET request to /api/projects/(.*)/billing-period-items")]
    public async Task WhenISendAGETRequestToApiProjectsEntityNoBillingPeriodItems(string entityNo)
    {
        _response = await _client.GetAsync(_baseUrl + entityNo + "/billing-period-items");
    }

    [Then("the API response should be (.*)")]
    public void ThenTheAPIResponseShouldBe(int statusCode)
    {
        _response.StatusCode.Should().Be((System.Net.HttpStatusCode)statusCode);
    }

    [Then("the response should contain a list of billing period items")]
    public async Task ThenTheResponseShouldContainAListOfBillingPeriodItems()
    {
        var content = await _response.Content.ReadAsStringAsync();
        var items = JsonConvert.DeserializeObject<List<ProjectBillingPeriodItemModel>>(content);
        items.Should().NotBeNull();
        items.Should().BeOfType<List<ProjectBillingPeriodItemModel>>();
    }

    [Then("the response should be an empty list")]
    public async Task ThenTheResponseShouldBeAnEmptyList()
    {
        var content = await _response.Content.ReadAsStringAsync();
        var items = JsonConvert.DeserializeObject<List<ProjectBillingPeriodItemModel>>(content);
        items.Should().BeEmpty();
    }
}