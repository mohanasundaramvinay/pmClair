using Xunit;
using Xunit.Gherkin.Quick;
using System.Net.Http;
using System.Threading.Tasks;
using FluentAssertions;
using Newtonsoft.Json.Linq;

[FeatureFile("PerDiemBillableStatusTypes.feature")]
public sealed class PerDiemBillableStatusTypesSteps : Feature
{
    private readonly HttpClient _client;
    private HttpResponseMessage _response;
    private JArray _jsonResponse;

    public PerDiemBillableStatusTypesSteps()
    {
        _client = new HttpClient();
        _client.BaseAddress = new System.Uri("http://localhost:5000");
    }

    [Given("the API is running and accessible")]
    public void GivenTheApiIsRunningAndAccessible()
    {
        // Assume the API is running
    }

    [Given("the server is experiencing issues")]
    public void GivenTheServerIsExperiencingIssues()
    {
        // Simulate server issues if possible
    }

    [When("I send a GET request to /api/ProjectDataPoints/per-diem-billable-status-types")]
    public async Task WhenISendAGetRequestToApiProjectDataPointsPerDiemBillableStatusTypes()
    {
        _response = await _client.GetAsync("/api/ProjectDataPoints/per-diem-billable-status-types");
        var content = await _response.Content.ReadAsStringAsync();
        _jsonResponse = JArray.Parse(content);
    }

    [Then("the API response should be (.*)")]
    public void ThenTheApiResponseShouldBe(int statusCode)
    {
        _response.StatusCode.Should().Be((System.Net.HttpStatusCode)statusCode);
    }

    [Then("the response should contain a list of per diem billable status types")]
    public void ThenTheResponseShouldContainAListOfPerDiemBillableStatusTypes()
    {
        _jsonResponse.Should().NotBeNull();
        _jsonResponse.Should().BeOfType<JArray>();
    }

    [Then("the response should contain fields (.*)")]
    public void ThenTheResponseShouldContainFields(string fields)
    {
        var fieldList = fields.Split(',');
        foreach (var item in _jsonResponse)
        {
            foreach (var field in fieldList)
            {
                item.Should().ContainKey(field.Trim());
            }
        }
    }
}