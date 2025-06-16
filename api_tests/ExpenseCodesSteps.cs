using Xunit;
using Xunit.Gherkin.Quick;
using System.Net.Http;
using System.Threading.Tasks;
using FluentAssertions;
using Newtonsoft.Json.Linq;

[FeatureFile("ExpenseCodesFeature.feature")]
public sealed class ExpenseCodesSteps : Feature
{
    private readonly HttpClient _client = new HttpClient();
    private HttpResponseMessage _response;
    private string _responseContent;

    [Given("the API is running and accessible")]
    public void GivenTheApiIsRunningAndAccessible()
    {
        _client.BaseAddress = new System.Uri("http://localhost:5000");
    }

    [When("I send a GET request to /api/ProjectDataPoints/expense-codes")]
    public async Task WhenISendAGetRequestToApiProjectDataPointsExpenseCodes()
    {
        _response = await _client.GetAsync("/api/ProjectDataPoints/expense-codes");
        _responseContent = await _response.Content.ReadAsStringAsync();
    }

    [Then("the API response should be (.*) with a list of expense codes")]
    public void ThenTheApiResponseShouldBeWithAListOfExpenseCodes(int statusCode)
    {
        _response.StatusCode.Should().Be((System.Net.HttpStatusCode)statusCode);
        var jsonArray = JArray.Parse(_responseContent);
        jsonArray.Should().NotBeEmpty();
    }

    [Then("the API response should be (.*) with an error message")]
    public void ThenTheApiResponseShouldBeWithAnErrorMessage(int statusCode)
    {
        _response.StatusCode.Should().Be((System.Net.HttpStatusCode)statusCode);
        _responseContent.Should().Contain("error");
    }

    [Then("the response should contain fields (.*)")]
    public void ThenTheResponseShouldContainFields(string fields)
    {
        var expectedFields = fields.Split(',');
        var jsonArray = JArray.Parse(_responseContent);
        foreach (var item in jsonArray)
        {
            foreach (var field in expectedFields)
            {
                item.ToString().Should().Contain(field.Trim());
            }
        }
    }
}