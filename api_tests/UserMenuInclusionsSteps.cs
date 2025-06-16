using Xunit;
using Xunit.Gherkin.Quick;
using System.Net.Http;
using System.Threading.Tasks;
using FluentAssertions;

[FeatureFile("UserMenuInclusions.feature")]
public sealed class UserMenuInclusionsSteps : Feature
{
    private readonly HttpClient _client;
    private HttpResponseMessage _response;

    public UserMenuInclusionsSteps()
    {
        _client = new HttpClient();
        _client.BaseAddress = new System.Uri("http://localhost:5000");
    }

    [Given("I have access to the ProjectDataPoints API")]
    public void GivenIHaveAccessToTheProjectDataPointsAPI()
    {
        // Assume access is granted for testing purposes
    }

    [When("I send a GET request to /api/ProjectDataPoints/user-menu-inclusions")]
    public async Task WhenISendAGETRequestToApiProjectDataPointsUserMenuInclusions()
    {
        _response = await _client.GetAsync("/api/ProjectDataPoints/user-menu-inclusions");
    }

    [Then("the API response should be a list of menu inclusions with status code (.*)")]
    public void ThenTheAPIResponseShouldBeAListOfMenuInclusionsWithStatusCode(int statusCode)
    {
        _response.StatusCode.Should().Be((System.Net.HttpStatusCode)statusCode);
        if (statusCode == 200)
        {
            var content = _response.Content.ReadAsStringAsync().Result;
            content.Should().NotBeNullOrEmpty();
            content.Should().StartWith("[");
            content.Should().EndWith("]");
        }
    }
}