using Xunit;
using Xunit.Gherkin.Quick;
using System.Net.Http;
using System.Threading.Tasks;
using FluentAssertions;
using Newtonsoft.Json;
using System.Collections.Generic;

[FeatureFile("ProjectBillingItems.feature")]
public sealed class ProjectBillingItemsSteps : Feature
{
    private readonly HttpClient _client = new HttpClient();
    private HttpResponseMessage _response;
    private string _entityNo;

    [Given("I have access to the Project Maintenance API")]
    public void GivenIHaveAccessToTheProjectMaintenanceAPI()
    {
        _client.BaseAddress = new System.Uri("http://localhost:5000/api/");
    }

    [When("I send a GET request to /api/projects/<entityNo>/billing-items")]
    public async Task WhenISendAGETRequestToApiProjectsEntityNoBillingItems(string entityNo)
    {
        _entityNo = entityNo;
        _response = await _client.GetAsync($"projects/{_entityNo}/billing-items");
    }

    [Then("the API response should be <StatusCode>")]
    public void ThenTheAPIResponseShouldBe(int statusCode)
    {
        _response.StatusCode.Should().Be((System.Net.HttpStatusCode)statusCode);
    }

    [Then("the response should contain a list of billing items")]
    public async Task ThenTheResponseShouldContainAListOfBillingItems()
    {
        var content = await _response.Content.ReadAsStringAsync();
        var billingItems = JsonConvert.DeserializeObject<List<ProjectBillingItemModel>>(content);
        billingItems.Should().NotBeNull();
        billingItems.Should().BeOfType<List<ProjectBillingItemModel>>();
    }

    [Then("the response should be an empty list")]
    public async Task ThenTheResponseShouldBeAnEmptyList()
    {
        var content = await _response.Content.ReadAsStringAsync();
        var billingItems = JsonConvert.DeserializeObject<List<ProjectBillingItemModel>>(content);
        billingItems.Should().BeEmpty();
    }
}