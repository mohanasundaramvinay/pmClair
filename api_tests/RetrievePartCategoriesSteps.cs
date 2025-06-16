using Xunit;
using Xunit.Gherkin.Quick;
using System.Net.Http;
using System.Threading.Tasks;
using FluentAssertions;
using Newtonsoft.Json.Linq;

[FeatureFile("RetrievePartCategories.feature")]
public sealed class RetrievePartCategoriesSteps : Feature
{
    private readonly HttpClient _client;
    private HttpResponseMessage _response;

    public RetrievePartCategoriesSteps()
    {
        _client = new HttpClient();
        _client.BaseAddress = new System.Uri("http://localhost:5000");
    }

    [When("I send a GET request to /api/ProjectDataPoints/parts/categories")]
    public async Task WhenISendAGetRequestToApiProjectDataPointsPartsCategories()
    {
        _response = await _client.GetAsync("/api/ProjectDataPoints/parts/categories");
    }

    [Then("the API response should be (.*)")]
    public void ThenTheApiResponseShouldBe(int statusCode)
    {
        _response.StatusCode.Should().Be((System.Net.HttpStatusCode)statusCode);
    }

    [And("the response should contain the following categories:")]
    public async Task AndTheResponseShouldContainTheFollowingCategories(Table table)
    {
        var content = await _response.Content.ReadAsStringAsync();
        var jsonArray = JArray.Parse(content);

        foreach (var row in table.Rows)
        {
            var code = row["code"];
            var description = row["description"];

            jsonArray.Should().Contain(j => j["code"].ToString() == code && j["description"].ToString() == description);
        }
    }
}