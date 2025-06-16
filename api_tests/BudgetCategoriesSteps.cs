using Xunit;
using Xunit.Gherkin.Quick;
using System.Net.Http;
using System.Threading.Tasks;
using FluentAssertions;
using Newtonsoft.Json.Linq;

[FeatureFile("BudgetCategories.feature")]
public sealed class BudgetCategoriesSteps : Feature
{
    private readonly HttpClient _client;
    private HttpResponseMessage _response;

    public BudgetCategoriesSteps()
    {
        _client = new HttpClient();
        _client.BaseAddress = new System.Uri("http://localhost:5000");
    }

    [Given("I have access to the ProjectDataPoints API")]
    public void GivenIHaveAccessToTheProjectDataPointsAPI()
    {
        // Assume access is always available for this test
    }

    [When("I send a GET request to /api/ProjectDataPoints/budget-categories")]
    public async Task WhenISendAGETRequestToApiProjectDataPointsBudgetCategories()
    {
        _response = await _client.GetAsync("/api/ProjectDataPoints/budget-categories");
    }

    [Then("the API response should be (.*)")]
    public void ThenTheAPIResponseShouldBe(int statusCode)
    {
        _response.StatusCode.Should().Be((System.Net.HttpStatusCode)statusCode);
    }

    [And("the response should contain a list of budget categories")]
    public async Task AndTheResponseShouldContainAListOfBudgetCategories()
    {
        var content = await _response.Content.ReadAsStringAsync();
        var jsonArray = JArray.Parse(content);
        jsonArray.Should().NotBeEmpty();
    }

    [And("the response should contain an error message")]
    public async Task AndTheResponseShouldContainAnErrorMessage()
    {
        var content = await _response.Content.ReadAsStringAsync();
        content.Should().Contain("error");
    }

    [And("the response should match the expected JSON schema")]
    public async Task AndTheResponseShouldMatchTheExpectedJSONSchema()
    {
        var content = await _response.Content.ReadAsStringAsync();
        var jsonArray = JArray.Parse(content);
        foreach (var item in jsonArray)
        {
            item.Should().ContainKey("CategoryCode");
            item.Should().ContainKey("Description");
            item.Should().ContainKey("ParentCategory");
            item.Should().ContainKey("ActiveStatus");
        }
    }
}