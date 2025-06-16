using Xunit.Gherkin.Quick;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Collections.Generic;
using Xunit;

[FeatureFile("CalculatePartBottlenecks.feature")]
public sealed class CalculatePartBottlenecksSteps : Feature
{
    private readonly HttpClient _client;
    private HttpResponseMessage _response;
    private string _requestBody;

    public CalculatePartBottlenecksSteps()
    {
        _client = new HttpClient();
        _client.BaseAddress = new System.Uri("http://localhost:5000");
    }

    [Given("the following part numbers: (.*)")]
    public void GivenTheFollowingPartNumbers(string partNumbers)
    {
        var parts = JsonConvert.DeserializeObject<List<string>>(partNumbers);
        _requestBody = JsonConvert.SerializeObject(new { partNumbers = parts, fromDate = "2024-01-01T00:00:00" });
    }

    [Given("a null request")]
    public void GivenANullRequest()
    {
        _requestBody = null;
    }

    [When("I send a POST request to /api/ProjectDataPoints/parts/calculate-bottlenecks with the part numbers and from date (.*)")]
    public async Task WhenISendAPostRequest(string fromDate)
    {
        if (_requestBody != null)
        {
            var request = JsonConvert.DeserializeObject<Dictionary<string, object>>(_requestBody);
            request["fromDate"] = fromDate;
            _requestBody = JsonConvert.SerializeObject(request);
        }
        _response = await _client.PostAsync("/api/ProjectDataPoints/parts/calculate-bottlenecks", new StringContent(_requestBody, System.Text.Encoding.UTF8, "application/json"));
    }

    [Then("the API response should be (.*)")]
    public void ThenTheApiResponseShouldBe(int statusCode)
    {
        Assert.Equal(statusCode, (int)_response.StatusCode);
    }

    [Then("the response should contain bottleneck calculations for each part")]
    public async Task ThenTheResponseShouldContainBottleneckCalculationsForEachPart()
    {
        var content = await _response.Content.ReadAsStringAsync();
        var result = JsonConvert.DeserializeObject<List<PartBottleneckDto>>(content);
        Assert.NotNull(result);
        Assert.NotEmpty(result);
    }

    [Then("the response should contain an error message (.*)")]
    public async Task ThenTheResponseShouldContainAnErrorMessage(string errorMessage)
    {
        var content = await _response.Content.ReadAsStringAsync();
        Assert.Contains(errorMessage, content);
    }
}