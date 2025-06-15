using Xunit.Gherkin.Quick;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Collections.Generic;
using Xunit;

[FeatureFile("PartsSearchAPI.feature")]
public sealed class PartsSearchAPISteps : Feature
{
    private readonly HttpClient _client = new HttpClient();
    private HttpResponseMessage _response;
    private List<dynamic> _responseData;

    [Given("the API is running")]
    public void GivenTheAPIIsRunning()
    {
        _client.BaseAddress = new System.Uri("http://localhost:5000");
    }

    [When("I send a POST request to /api/ProjectDataPoints/parts/search with the following data:")]
    public async Task WhenISendAPostRequestToApiProjectDataPointsPartsSearchWithTheFollowingData(Table table)
    {
        var row = table.Rows[0];
        var requestData = new
        {
            searchText = row["searchText"],
            category = row["category"],
            subCategory = row["subCategory"],
            hideUnusedParts = bool.Parse(row["hideUnusedParts"]),
            onlyMyWarehouses = bool.Parse(row["onlyMyWarehouses"]),
            myPartsOnly = bool.Parse(row["myPartsOnly"]),
            searchForBarcode = bool.Parse(row["searchForBarcode"])
        };
        var content = new StringContent(JsonConvert.SerializeObject(requestData), System.Text.Encoding.UTF8, "application/json");
        _response = await _client.PostAsync("/api/ProjectDataPoints/parts/search", content);
        var responseString = await _response.Content.ReadAsStringAsync();
        _responseData = JsonConvert.DeserializeObject<List<dynamic>>(responseString);
    }

    [Then("the API response should be {int}")]
    public void ThenTheAPIResponseShouldBe(int statusCode)
    {
        Assert.Equal(statusCode, (int)_response.StatusCode);
    }

    [And("the response should contain {int} parts")]
    public void AndTheResponseShouldContainParts(int expectedPartsCount)
    {
        Assert.Equal(expectedPartsCount, _responseData.Count);
    }
}