using Xunit;
using Xunit.Gherkin.Quick;
using System.Net.Http;
using System.Threading.Tasks;
using FluentAssertions;
using Newtonsoft.Json;
using System.Collections.Generic;

[FeatureFile("RetrieveProposalTypes.feature")]
public sealed class RetrieveProposalTypesSteps : Feature
{
    private readonly HttpClient _client;
    private HttpResponseMessage _response;
    private string _responseContent;

    public RetrieveProposalTypesSteps()
    {
        _client = new HttpClient();
        _client.BaseAddress = new System.Uri("http://localhost:5000");
    }

    [Given("I have access to the ProjectDataPoints API")]
    public void GivenIHaveAccessToTheProjectDataPointsAPI()
    {
        // Assume access is granted
    }

    [When("I send a GET request to /api/ProjectDataPoints/proposal-types")]
    public async Task WhenISendAGETRequestToApiProjectDataPointsProposalTypes()
    {
        _response = await _client.GetAsync("/api/ProjectDataPoints/proposal-types");
        _responseContent = await _response.Content.ReadAsStringAsync();
    }

    [Then("the API response should be (.*)")]
    public void ThenTheAPIResponseShouldBe(int statusCode)
    {
        _response.StatusCode.Should().Be((System.Net.HttpStatusCode)statusCode);
    }

    [Then("the response should contain a list of proposal types")]
    public void ThenTheResponseShouldContainAListOfProposalTypes()
    {
        var proposalTypes = JsonConvert.DeserializeObject<List<PropertyTypeDTO>>(_responseContent);
        proposalTypes.Should().NotBeNull();
        proposalTypes.Should().BeOfType<List<PropertyTypeDTO>>();
    }

    [Then("the response should match the expected structure")]
    public void ThenTheResponseShouldMatchTheExpectedStructure()
    {
        var proposalTypes = JsonConvert.DeserializeObject<List<PropertyTypeDTO>>(_responseContent);
        foreach (var type in proposalTypes)
        {
            type.Should().NotBeNull();
            type.TypeCode.Should().NotBeNullOrEmpty();
            type.Description.Should().NotBeNullOrEmpty();
            type.Category.Should().NotBeNullOrEmpty();
            type.ActiveStatus.Should().BeOfType<bool>();
        }
    }
}

public class PropertyTypeDTO
{
    public string TypeCode { get; set; }
    public string Description { get; set; }
    public string Category { get; set; }
    public bool ActiveStatus { get; set; }
}