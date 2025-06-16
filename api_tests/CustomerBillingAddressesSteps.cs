using Xunit;
using Xunit.Gherkin.Quick;
using System.Net.Http;
using System.Threading.Tasks;
using FluentAssertions;

[FeatureFile("CustomerBillingAddresses.feature")]
public sealed class CustomerBillingAddressesSteps : Feature
{
    private readonly HttpClient _client;
    private HttpResponseMessage _response;

    public CustomerBillingAddressesSteps()
    {
        _client = new HttpClient();
        _client.BaseAddress = new System.Uri("http://localhost:5000");
    }

    [When("I send a GET request to /api/ProjectDataPoints/customers/(.*)/billing-addresses")]
    public async Task WhenISendAGetRequestToApiProjectDataPointsCustomersBillingAddresses(string customerNo)
    {
        _response = await _client.GetAsync($"/api/ProjectDataPoints/customers/{customerNo}/billing-addresses");
    }

    [Then("the API response should be (.*)")]
    public void ThenTheApiResponseShouldBe(int statusCode)
    {
        _response.StatusCode.Should().Be((System.Net.HttpStatusCode)statusCode);
    }

    [And("the response should contain (.*)")]
    public async Task AndTheResponseShouldContain(string expectedResult)
    {
        var content = await _response.Content.ReadAsStringAsync();
        content.Should().Contain(expectedResult);
    }
}