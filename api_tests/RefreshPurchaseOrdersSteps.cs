using Xunit.Gherkin.Quick;
using System.Net.Http;
using System.Threading.Tasks;
using FluentAssertions;
using Newtonsoft.Json.Linq;

[FeatureFile("RefreshPurchaseOrders.feature")]
public sealed class RefreshPurchaseOrdersSteps : Feature
{
    private readonly HttpClient _client = new HttpClient();
    private HttpResponseMessage _response;
    private string _entityNo;

    [Given("I have access to the Purchase Order API")]
    public void GivenIHaveAccessToThePurchaseOrderAPI()
    {
        _client.BaseAddress = new System.Uri("http://localhost:5000");
    }

    [When("I send a GET request to /api/PurchaseOrder/refresh/(.*)")]
    public async Task WhenISendAGETRequestToApiPurchaseOrderRefresh(string entityNo)
    {
        _entityNo = entityNo;
        _response = await _client.GetAsync($"/api/PurchaseOrder/refresh/{_entityNo}");
    }

    [Then("the API response should be (\d+)")]
    public void ThenTheAPIResponseShouldBe(int statusCode)
    {
        _response.StatusCode.Should().Be((System.Net.HttpStatusCode)statusCode);
    }

    [Then("the response should include a success message with the count of purchase orders")]
    public async Task ThenTheResponseShouldIncludeASuccessMessageWithTheCountOfPurchaseOrders()
    {
        var content = await _response.Content.ReadAsStringAsync();
        var json = JObject.Parse(content);
        json["Success"].Value<bool>().Should().BeTrue();
        json["Message"].Value<string>().Should().Contain("Successfully refreshed");
    }

    [Then("the response should include a data array of purchase orders")]
    public async Task ThenTheResponseShouldIncludeADataArrayOfPurchaseOrders()
    {
        var content = await _response.Content.ReadAsStringAsync();
        var json = JObject.Parse(content);
        json["Data"].Should().BeOfType<JArray>();
    }

    [Then("the response should include a refresh timestamp")]
    public async Task ThenTheResponseShouldIncludeARefreshTimestamp()
    {
        var content = await _response.Content.ReadAsStringAsync();
        var json = JObject.Parse(content);
        json["RefreshTime"].Should().NotBeNull();
    }
}