using Xunit.Gherkin.Quick;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;
using FluentAssertions;
using Newtonsoft.Json.Linq;

[FeatureFile("BillingAccountsFeature.feature")]
public sealed class BillingAccountsSteps : Feature
{
    private readonly HttpClient _client;
    private HttpResponseMessage _response;
    private JArray _responseContent;

    public BillingAccountsSteps()
    {
        _client = new HttpClient();
        _client.BaseAddress = new System.Uri("http://localhost:5000");
    }

    [Given("I have access to the ProjectDataPoints API")]
    public void GivenIHaveAccessToTheProjectDataPointsAPI()
    {
        // Assume access is granted
    }

    [When("I send a GET request to /api/ProjectDataPoints/billing-accounts")]
    public async Task WhenISendAGETRequestToApiProjectDataPointsBillingAccounts()
    {
        _response = await _client.GetAsync("/api/ProjectDataPoints/billing-accounts");
        var content = await _response.Content.ReadAsStringAsync();
        _responseContent = JArray.Parse(content);
    }

    [Then("the API response should be 200")]
    public void ThenTheAPIResponseShouldBe200()
    {
        _response.StatusCode.Should().Be(System.Net.HttpStatusCode.OK);
    }

    [Then("the API response should be 500")]
    public void ThenTheAPIResponseShouldBe500()
    {
        _response.StatusCode.Should().Be(System.Net.HttpStatusCode.InternalServerError);
    }

    [Then("the response should contain a list of billing accounts")]
    public void ThenTheResponseShouldContainAListOfBillingAccounts()
    {
        _responseContent.Should().NotBeNull();
        _responseContent.Should().BeOfType<JArray>();
    }

    [Then("the response should contain an error message")]
    public void ThenTheResponseShouldContainAnErrorMessage()
    {
        var errorMessage = _responseContent.Value<string>("error");
        errorMessage.Should().NotBeNullOrEmpty();
    }

    [Then("the response should contain a billing account with AccountNumber \"(.*)\"")]
    public void ThenTheResponseShouldContainABillingAccountWithAccountNumber(string accountNumber)
    {
        _responseContent.Should().Contain(x => x.Value<string>("AccountNumber") == accountNumber);
    }

    [Then("the response should contain a billing account with AccountName \"(.*)\"")]
    public void ThenTheResponseShouldContainABillingAccountWithAccountName(string accountName)
    {
        _responseContent.Should().Contain(x => x.Value<string>("AccountName") == accountName);
    }

    [Then("the response should contain a billing account with CompanyName \"(.*)\"")]
    public void ThenTheResponseShouldContainABillingAccountWithCompanyName(string companyName)
    {
        _responseContent.Should().Contain(x => x.Value<string>("CompanyName") == companyName);
    }

    [Then("the response should contain a billing account with IsActive \"(.*)\"")]
    public void ThenTheResponseShouldContainABillingAccountWithIsActive(string isActive)
    {
        _responseContent.Should().Contain(x => x.Value<bool>("IsActive").ToString() == isActive);
    }
}