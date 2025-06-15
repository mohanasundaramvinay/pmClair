using Xunit;
using Xunit.Gherkin.Quick;
using System.Net.Http;
using System.Threading.Tasks;
using FluentAssertions;

[FeatureFile("ContactCategories.feature")]
public sealed class ContactCategoriesSteps : Feature
{
    private readonly HttpClient _client;
    private HttpResponseMessage _response;

    public ContactCategoriesSteps()
    {
        _client = new HttpClient();
        _client.BaseAddress = new System.Uri("http://localhost:5000");
    }

    [When("I send a GET request to /api/ProjectDataPoints/contact-categories")]
    public async Task WhenISendAGetRequestToApiProjectDataPointsContactCategories()
    {
        _response = await _client.GetAsync("/api/ProjectDataPoints/contact-categories");
    }

    [Then("the API response should be (.*)")]
    public void ThenTheApiResponseShouldBe(int statusCode)
    {
        _response.StatusCode.Should().Be((System.Net.HttpStatusCode)statusCode);
    }

    [Then("the response should contain a list of contact categories")]
    public async Task ThenTheResponseShouldContainAListOfContactCategories()
    {
        var content = await _response.Content.ReadAsStringAsync();
        content.Should().NotBeNullOrEmpty();
        content.Should().Contain("CategoryId");
        content.Should().Contain("CategoryName");
    }
}