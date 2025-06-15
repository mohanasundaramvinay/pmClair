using Xunit.Gherkin.Quick;
using System.Net.Http;
using System.Threading.Tasks;
using FluentAssertions;

[FeatureFile("DefaultProjectSettings.feature")]
public sealed class DefaultProjectSettingsSteps : Feature
{
    private readonly HttpClient _client;
    private HttpResponseMessage _response;

    public DefaultProjectSettingsSteps()
    {
        _client = new HttpClient();
        _client.BaseAddress = new System.Uri("http://localhost:5000");
    }

    [When("I send a GET request to /api/ProjectDataPoints/default-project-settings with username \"(.*)\"")]
    public async Task WhenISendAGetRequestWithUsername(string username)
    {
        var url = string.IsNullOrEmpty(username) ? "/api/ProjectDataPoints/default-project-settings" : $"/api/ProjectDataPoints/default-project-settings?username={username}";
        _response = await _client.GetAsync(url);
    }

    [When("I send a GET request to /api/ProjectDataPoints/default-project-settings")]
    public async Task WhenISendAGetRequestWithoutUsername()
    {
        _response = await _client.GetAsync("/api/ProjectDataPoints/default-project-settings");
    }

    [Then("the API response should be (\d+) with the default project settings")]
    public async Task ThenTheApiResponseShouldBeWithTheDefaultProjectSettings(int statusCode)
    {
        _response.StatusCode.Should().Be((System.Net.HttpStatusCode)statusCode);
        var content = await _response.Content.ReadAsStringAsync();
        content.Should().Contain("defaultWarehouse");
    }

    [Then("the API response should be (\d+) with an error message")]
    public async Task ThenTheApiResponseShouldBeWithAnErrorMessage(int statusCode)
    {
        _response.StatusCode.Should().Be((System.Net.HttpStatusCode)statusCode);
        var content = await _response.Content.ReadAsStringAsync();
        content.Should().Contain("error");
    }
}