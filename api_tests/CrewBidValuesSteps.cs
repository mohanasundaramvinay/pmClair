using Xunit;
using Xunit.Gherkin.Quick;
using System.Net.Http;
using System.Threading.Tasks;
using FluentAssertions;
using Newtonsoft.Json.Linq;

[FeatureFile("CrewBidValues.feature")]
public sealed class CrewBidValuesSteps : Feature
{
    private readonly HttpClient _client;
    private HttpResponseMessage _response;
    private JArray _jsonResponse;

    public CrewBidValuesSteps()
    {
        _client = new HttpClient();
    }

    [Given("the API is running and accessible")]
    public void GivenTheApiIsRunningAndAccessible()
    {
        // Assume the API is running and accessible
    }

    [When("I send a GET request to /api/ProjectDataPoints/crew-bid-values")]
    public async Task WhenISendAGetRequestToApiProjectDataPointsCrewBidValues()
    {
        _response = await _client.GetAsync("http://localhost:5000/api/ProjectDataPoints/crew-bid-values");
        var content = await _response.Content.ReadAsStringAsync();
        _jsonResponse = JArray.Parse(content);
    }

    [Then("the API response should be (.*)")]
    public void ThenTheApiResponseShouldBe(int statusCode)
    {
        _response.StatusCode.Should().Be((System.Net.HttpStatusCode)statusCode);
    }

    [Then("the response should contain a list of crew bid values")]
    public void ThenTheResponseShouldContainAListOfCrewBidValues()
    {
        _jsonResponse.Should().NotBeNull();
        _jsonResponse.Should().BeOfType<JArray>();
    }

    [Then("each crew bid value should have fields: EmployeeId, JobType, BidRate, EffectiveDate, IsActive")]
    public void ThenEachCrewBidValueShouldHaveFields()
    {
        foreach (var item in _jsonResponse)
        {
            item.Should().ContainKeys("EmployeeId", "JobType", "BidRate", "EffectiveDate", "IsActive");
        }
    }

    [Then("the response should contain an error message")]
    public void ThenTheResponseShouldContainAnErrorMessage()
    {
        var content = _response.Content.ReadAsStringAsync().Result;
        content.Should().Contain("error");
    }

    [Then("the response should be a JSON array")]
    public void ThenTheResponseShouldBeAJsonArray()
    {
        _jsonResponse.Should().BeOfType<JArray>();
    }

    [Then("each item in the array should have the correct data types")]
    public void ThenEachItemInTheArrayShouldHaveTheCorrectDataTypes()
    {
        foreach (var item in _jsonResponse)
        {
            item["EmployeeId"].Type.Should().Be(JTokenType.Integer);
            item["JobType"].Type.Should().Be(JTokenType.String);
            item["BidRate"].Type.Should().Be(JTokenType.Float);
            item["EffectiveDate"].Type.Should().Be(JTokenType.Date);
            item["IsActive"].Type.Should().Be(JTokenType.Boolean);
        }
    }
}