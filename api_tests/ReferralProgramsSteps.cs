using Xunit.Gherkin.Quick;
using System.Net.Http;
using System.Threading.Tasks;
using FluentAssertions;
using Newtonsoft.Json;
using System.Collections.Generic;

[FeatureFile("ReferralProgramsFeature.feature")]
public class ReferralProgramsSteps : Feature
{
    private readonly HttpClient _client;
    private HttpResponseMessage _response;

    public ReferralProgramsSteps()
    {
        _client = new HttpClient();
        _client.BaseAddress = new System.Uri("http://localhost:5000");
    }

    [Given("I have access to the referral programs API")]
    public void GivenIHaveAccessToTheReferralProgramsAPI()
    {
        // Assume access is always available for this test
    }

    [When("I send a GET request to /api/ProjectDataPoints/referral-programs")]
    public async Task WhenISendAGETRequestToApiProjectDataPointsReferralPrograms()
    {
        _response = await _client.GetAsync("/api/ProjectDataPoints/referral-programs");
    }

    [Then("the API response should be a list of referral programs with status code (\d+)")]
    public async Task ThenTheAPIResponseShouldBeAListOfReferralProgramsWithStatusCode(int statusCode)
    {
        _response.StatusCode.Should().Be((System.Net.HttpStatusCode)statusCode);
        var content = await _response.Content.ReadAsStringAsync();
        var referralPrograms = JsonConvert.DeserializeObject<List<ReferralProgramDto>>(content);
        referralPrograms.Should().NotBeNull();
    }

    [Then("the API response should be an error message with status code (\d+)")]
    public void ThenTheAPIResponseShouldBeAnErrorMessageWithStatusCode(int statusCode)
    {
        _response.StatusCode.Should().Be((System.Net.HttpStatusCode)statusCode);
    }

    [Then("the API response should be an empty list with status code (\d+)")]
    public async Task ThenTheAPIResponseShouldBeAnEmptyListWithStatusCode(int statusCode)
    {
        _response.StatusCode.Should().Be((System.Net.HttpStatusCode)statusCode);
        var content = await _response.Content.ReadAsStringAsync();
        var referralPrograms = JsonConvert.DeserializeObject<List<ReferralProgramDto>>(content);
        referralPrograms.Should().BeEmpty();
    }
}