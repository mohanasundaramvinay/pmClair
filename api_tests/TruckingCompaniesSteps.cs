using Xunit.Gherkin.Quick;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using Xunit;

[FeatureFile("TruckingCompaniesFeature.feature")]
public class TruckingCompaniesSteps : Feature
{
    private readonly HttpClient _client;
    private HttpResponseMessage _response;
    private JArray _responseData;

    public TruckingCompaniesSteps()
    {
        _client = new HttpClient();
        _client.BaseAddress = new System.Uri("http://localhost:5000");
    }

    [Given("I have access to the Trucking Companies API")]
    public void GivenIHaveAccessToTheTruckingCompaniesAPI()
    {
        // Assume access is granted
    }

    [When("I send a GET request to /api/ProjectDataPoints/trucking-companies")]
    public async Task WhenISendAGETRequestToApiProjectDataPointsTruckingCompanies()
    {
        _response = await _client.GetAsync("/api/ProjectDataPoints/trucking-companies");
        var responseString = await _response.Content.ReadAsStringAsync();
        _responseData = JArray.Parse(responseString);
    }

    [Then("the API response should be a list of trucking companies with status code (.*)")]
    public void ThenTheAPIResponseShouldBeAListOfTruckingCompaniesWithStatusCode(int statusCode)
    {
        Assert.Equal(statusCode, (int)_response.StatusCode);
        Assert.NotNull(_responseData);
    }

    [Then("the API response should be an error message with status code (.*)")]
    public void ThenTheAPIResponseShouldBeAnErrorMessageWithStatusCode(int statusCode)
    {
        Assert.Equal(statusCode, (int)_response.StatusCode);
    }

    [Then("each trucking company should have fields: (.*)")]
    public void ThenEachTruckingCompanyShouldHaveFields(string fields)
    {
        var expectedFields = fields.Split(',');
        foreach (var company in _responseData)
        {
            foreach (var field in expectedFields)
            {
                Assert.True(company[field.Trim()] != null, $"Field {field} is missing");
            }
        }
    }
}