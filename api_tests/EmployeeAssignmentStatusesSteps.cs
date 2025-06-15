using Xunit;
using Xunit.Gherkin.Quick;
using System.Net.Http;
using System.Threading.Tasks;
using FluentAssertions;
using Newtonsoft.Json;
using System.Collections.Generic;

[FeatureFile("EmployeeAssignmentStatuses.feature")]
public sealed class EmployeeAssignmentStatusesSteps : Feature
{
    private readonly HttpClient _client;
    private HttpResponseMessage _response;
    private string _responseContent;

    public EmployeeAssignmentStatusesSteps()
    {
        _client = new HttpClient();
        _client.BaseAddress = new System.Uri("http://localhost:5000");
    }

    [Given("I have access to the ProjectDataPoints API")]
    public void GivenIHaveAccessToTheProjectDataPointsAPI()
    {
        // Assume access is granted
    }

    [When("I send a GET request to /api/ProjectDataPoints/employee-assignment-statuses")]
    public async Task WhenISendAGETRequestToApiProjectDataPointsEmployeeAssignmentStatuses()
    {
        _response = await _client.GetAsync("/api/ProjectDataPoints/employee-assignment-statuses");
        _responseContent = await _response.Content.ReadAsStringAsync();
    }

    [Then("the API response should be (.*)")]
    public void ThenTheAPIResponseShouldBe(int statusCode)
    {
        _response.StatusCode.Should().Be((System.Net.HttpStatusCode)statusCode);
    }

    [And("the response should contain a list of employee assignment statuses")]
    public void AndTheResponseShouldContainAListOfEmployeeAssignmentStatuses()
    {
        var statuses = JsonConvert.DeserializeObject<List<EmployeeAssignmentStatusCodeDto>>(_responseContent);
        statuses.Should().NotBeNull();
        statuses.Should().NotBeEmpty();
    }
}

public class EmployeeAssignmentStatusCodeDto
{
    public string StatusCode { get; set; }
    public string Description { get; set; }
    public string ColorCode { get; set; }
    public int SortOrder { get; set; }
    public bool IsActive { get; set; }
    public string CreatedDate { get; set; }
    public string ModifiedDate { get; set; }
    public string Category { get; set; }
    public bool IsDefault { get; set; }
}