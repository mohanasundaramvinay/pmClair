using Xunit.Gherkin.Quick;
using System.Net.Http;
using System.Threading.Tasks;
using FluentAssertions;
using Newtonsoft.Json;
using System.Collections.Generic;

[FeatureFile("PurchaseOrderFeature.feature")]
public sealed class PurchaseOrderSteps : Feature
{
    private readonly HttpClient _client = new HttpClient();
    private HttpResponseMessage _response;
    private string _entityNo;

    [Given("I have access to the Purchase Order API")]
    public void GivenIHaveAccessToThePurchaseOrderAPI()
    {
        _client.BaseAddress = new System.Uri("http://localhost:5000");
    }

    [When("I send a GET request to /api/PurchaseOrder/project/(.*)")]
    public async Task WhenISendAGETRequestToApiPurchaseOrderProject(string entityNo)
    {
        _entityNo = entityNo;
        _response = await _client.GetAsync($"/api/PurchaseOrder/project/{_entityNo}");
    }

    [Then("the API response should be (\d+)")]
    public void ThenTheAPIResponseShouldBe(int statusCode)
    {
        _response.StatusCode.Should().Be((System.Net.HttpStatusCode)statusCode);
    }

    [Then("the response should contain a list of purchase orders")]
    public async Task ThenTheResponseShouldContainAListOfPurchaseOrders()
    {
        var content = await _response.Content.ReadAsStringAsync();
        var purchaseOrders = JsonConvert.DeserializeObject<List<PurchaseOrderDto>>(content);
        purchaseOrders.Should().NotBeNull();
        purchaseOrders.Should().AllBeOfType<PurchaseOrderDto>();
    }
}

public class PurchaseOrderDto
{
    public int IdPurchaseOrder { get; set; }
    public int PONumber { get; set; }
    public string PODescription { get; set; }
    public string Currency { get; set; }
    public decimal TotalAmount { get; set; }
}