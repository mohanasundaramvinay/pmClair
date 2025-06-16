using Xunit;
using Xunit.Gherkin.Quick;
using System.Net.Http;
using System.Threading.Tasks;
using FluentAssertions;
using Newtonsoft.Json.Linq;

[FeatureFile("ContactsByCategory.feature")]
public sealed class ContactsByCategorySteps : Feature
{
    private readonly HttpClient _client;
    private HttpResponseMessage _response;
    private JArray _jsonResponse;

    public ContactsByCategorySteps()
    {
        _client = new HttpClient();
        _client.BaseAddress = new System.Uri("http://localhost:5000");
    }

    [When("I send a GET request to /api/ProjectDataPoints/contacts/by-category/(.*)")]
    public async Task WhenISendAGetRequestToApiProjectDataPointsContactsByCategory(string categoryId)
    {
        var url = $"/api/ProjectDataPoints/contacts/by-category/{categoryId}";
        _response = await _client.GetAsync(url);
        if (_response.IsSuccessStatusCode)
        {
            var jsonString = await _response.Content.ReadAsStringAsync();
            _jsonResponse = JArray.Parse(jsonString);
        }
    }

    [Then("the API response should be (.*)")]
    public void ThenTheApiResponseShouldBe(int statusCode)
    {
        ((int)_response.StatusCode).Should().Be(statusCode);
    }

    [And("the response should contain (.*) contacts")]
    public void AndTheResponseShouldContainContacts(int expectedContacts)
    {
        if (_jsonResponse != null)
        {
            _jsonResponse.Count.Should().Be(expectedContacts);
        }
    }
}