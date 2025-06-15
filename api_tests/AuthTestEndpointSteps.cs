using Xunit.Gherkin.Quick;
using System.Net.Http;
using System.Threading.Tasks;
using FluentAssertions;

[FeatureFile("AuthTestEndpoint.feature")]
public sealed class AuthTestEndpointSteps : Feature
{
    private readonly HttpClient _client;
    private HttpResponseMessage _response;

    public AuthTestEndpointSteps()
    {
        _client = new HttpClient();
    }

    [Given("I have a valid JWT token")]
    public void GivenIHaveAValidJwtToken()
    {
        // Assume token is set in a secure way
    }

    [Given("the database is down")]
    public void GivenTheDatabaseIsDown()
    {
        // Simulate database down scenario
    }

    [When("I send a GET request to /api/auth/test with token \"(.*)\"")]
    public async Task WhenISendAGetRequestToApiAuthTestWithToken(string token)
    {
        var request = new HttpRequestMessage(HttpMethod.Get, "http://localhost/api/auth/test");
        if (token != "no_token")
        {
            request.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
        }
        _response = await _client.SendAsync(request);
    }

    [Then("the API response should be \"(.*)\" with message \"(.*)\"")]
    public async Task ThenTheApiResponseShouldBeWithMessage(string statusCode, string message)
    {
        _response.StatusCode.Should().Be((System.Net.HttpStatusCode)int.Parse(statusCode));
        var content = await _response.Content.ReadAsStringAsync();
        content.Should().Contain(message);
    }
}