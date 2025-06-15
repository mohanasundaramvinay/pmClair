using Xunit.Gherkin.Quick;
using System.Net.Http;
using System.Threading.Tasks;
using FluentAssertions;

[FeatureFile("UserCompanyInfo.feature")]
public class UserCompanyInfoSteps : Feature
{
    private readonly HttpClient _client;
    private HttpResponseMessage _response;

    public UserCompanyInfoSteps()
    {
        _client = new HttpClient();
        _client.BaseAddress = new System.Uri("http://localhost:5000");
    }

    [Given("I have access to the ProjectDataPoints API")]
    public void GivenIHaveAccessToTheProjectDataPointsAPI()
    {
        // Assume authentication is handled globally or via middleware
    }

    [Given("I have an invalid authentication token")]
    public void GivenIHaveAnInvalidAuthenticationToken()
    {
        _client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", "invalid_token");
    }

    [Given("the server is down")]
    public void GivenTheServerIsDown()
    {
        // Simulate server down by pointing to an incorrect address
        _client.BaseAddress = new System.Uri("http://localhost:9999");
    }

    [When("I send a GET request to /api/ProjectDataPoints/user-company-info")]
    public async Task WhenISendAGETRequestToApiProjectDataPointsUserCompanyInfo()
    {
        _response = await _client.GetAsync("/api/ProjectDataPoints/user-company-info");
    }

    [Then("the API response should be: (.*)")]
    public void ThenTheAPIResponseShouldBe(int statusCode)
    {
        _response.StatusCode.Should().Be((System.Net.HttpStatusCode)statusCode);
    }

    [Then("the response should contain company information")]
    public async Task ThenTheResponseShouldContainCompanyInformation()
    {
        var content = await _response.Content.ReadAsStringAsync();
        content.Should().Contain("companyCode");
        content.Should().Contain("companyName");
    }
}