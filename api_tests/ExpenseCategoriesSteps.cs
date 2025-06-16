using Xunit;
using Xunit.Gherkin.Quick;
using System.Net.Http;
using System.Threading.Tasks;
using FluentAssertions;

[FeatureFile("ExpenseCategories.feature")]
public sealed class ExpenseCategoriesSteps : Feature
{
    private readonly HttpClient _client;
    private HttpResponseMessage _response;

    public ExpenseCategoriesSteps()
    {
        _client = new HttpClient();
        _client.BaseAddress = new System.Uri("http://localhost:5000");
    }

    [Given("I have access to the ProjectDataPoints API")]
    public void GivenIHaveAccessToTheProjectDataPointsAPI()
    {
        // Assume access is always available for this test
    }

    [When("I send a GET request to /api/ProjectDataPoints/expense-categories")]
    public async Task WhenISendAGETRequestToApiProjectDataPointsExpenseCategories()
    {
        _response = await _client.GetAsync("/api/ProjectDataPoints/expense-categories");
    }

    [Then("the API response should be (.*) and contain a list of expense categories")]
    public async Task ThenTheAPIResponseShouldBeAndContainAListOfExpenseCategories(int statusCode)
    {
        _response.StatusCode.Should().Be((System.Net.HttpStatusCode)statusCode);
        var content = await _response.Content.ReadAsStringAsync();
        content.Should().Contain("CategoryCode");
    }

    [Then("the API response should be (.*) and contain an error message")]
    public async Task ThenTheAPIResponseShouldBeAndContainAnErrorMessage(int statusCode)
    {
        _response.StatusCode.Should().Be((System.Net.HttpStatusCode)statusCode);
        var content = await _response.Content.ReadAsStringAsync();
        content.Should().Contain("error");
    }
}