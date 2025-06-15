using Xunit;
using Xunit.Gherkin.Quick;
using System.Net.Http;
using System.Threading.Tasks;
using FluentAssertions;
using Newtonsoft.Json;
using System.Collections.Generic;

[FeatureFile("ProjectDataPointsJobTypes.feature")]
public sealed class ProjectDataPointsJobTypesSteps : Feature
{
    private readonly HttpClient _client;
    private HttpResponseMessage _response;
    private string _responseContent;

    public ProjectDataPointsJobTypesSteps()
    {
        _client = new HttpClient();
        _client.BaseAddress = new System.Uri("http://localhost:5000");
    }

    [When("I send a GET request to /api/ProjectDataPoints/job-types")]
    public async Task WhenISendAGetRequestToApiProjectDataPointsJobTypes()
    {
        _response = await _client.GetAsync("/api/ProjectDataPoints/job-types");
        _responseContent = await _response.Content.ReadAsStringAsync();
    }

    [Then("the API response should be (.*)")]
    public void ThenTheApiResponseShouldBe(int statusCode)
    {
        _response.StatusCode.Should().Be((System.Net.HttpStatusCode)statusCode);
    }

    [And("the response should contain a list of job types")]
    public void AndTheResponseShouldContainAListOfJobTypes()
    {
        if (_response.IsSuccessStatusCode)
        {
            var jobTypes = JsonConvert.DeserializeObject<List<JobType>>(_responseContent);
            jobTypes.Should().NotBeNull();
            jobTypes.Should().AllBeOfType<JobType>();
        }
    }
}

public class JobType
{
    public string JobTypeCode { get; set; }
    public string Description { get; set; }
    public DivisionInformation DivisionInformation { get; set; }
    public bool ActiveStatus { get; set; }
    public RateInformation RateInformation { get; set; }
    public string CreatedDate { get; set; }
    public string ModifiedDate { get; set; }
}

public class DivisionInformation
{
    public string DivisionName { get; set; }
    public string DivisionID { get; set; }
}

public class RateInformation
{
    public double RateAmount { get; set; }
    public string Currency { get; set; }
}