using Xunit;
using Xunit.Gherkin.Quick;
using System.Net.Http;
using System.Threading.Tasks;
using FluentAssertions;
using Newtonsoft.Json.Linq;

[FeatureFile("ProjectDataPointsCompanies.feature")]
public sealed class ProjectDataPointsCompaniesSteps : Feature
{
    private readonly HttpClient _client;
    private HttpResponseMessage _response;
    private string _responseContent;

    public ProjectDataPointsCompaniesSteps()
    {
        _client = new HttpClient();
        _client.BaseAddress = new System.Uri("http://localhost:5000");
    }

    [Given("I have access to the Project Data Points API")]
    public void GivenIHaveAccessToTheProjectDataPointsAPI()
    {
        // Assume access is granted
    }

    [When("I send a GET request to /api/ProjectDataPoints/companies")]
    public async Task WhenISendAGETRequestToApiProjectDataPointsCompanies()
    {
        _response = await _client.GetAsync("/api/ProjectDataPoints/companies");
        _responseContent = await _response.Content.ReadAsStringAsync();
    }

    [Then("the API response should be (.*)")]
    public void ThenTheAPIResponseShouldBe(int statusCode)
    {
        _response.StatusCode.Should().Be((System.Net.HttpStatusCode)statusCode);
    }

    [Then("the response should contain a list of companies")]
    public void ThenTheResponseShouldContainAListOfCompanies()
    {
        var jsonArray = JArray.Parse(_responseContent);
        jsonArray.Should().NotBeEmpty();
    }

    [Then("each company should have a CompanyCode, CompanyName, DivisionInformation, ActiveStatus, Address, ContactNumber, Email, EstablishedYear, and NumberOfEmployees")]
    public void ThenEachCompanyShouldHaveRequiredFields()
    {
        var jsonArray = JArray.Parse(_responseContent);
        foreach (var company in jsonArray)
        {
            company.Should().ContainKeys("CompanyCode", "CompanyName", "DivisionInformation", "ActiveStatus", "Address", "ContactNumber", "Email", "EstablishedYear", "NumberOfEmployees");
        }
    }

    [Then("the response should contain an error message")]
    public void ThenTheResponseShouldContainAnErrorMessage()
    {
        _responseContent.Should().Contain("error");
    }
}