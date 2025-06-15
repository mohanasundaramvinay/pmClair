using Xunit;
using Xunit.Gherkin.Quick;
using System.Net.Http;
using System.Threading.Tasks;
using FluentAssertions;
using Newtonsoft.Json.Linq;

[FeatureFile("CloudStorageInfo.feature")]
public sealed class CloudStorageInfoSteps : Feature
{
    private readonly HttpClient _client;
    private HttpResponseMessage _response;
    private JObject _jsonResponse;

    public CloudStorageInfoSteps()
    {
        _client = new HttpClient();
        _client.BaseAddress = new System.Uri("http://localhost:5000");
    }

    [Given("the File Explorer API is running")]
    public void GivenTheFileExplorerApiIsRunning()
    {
        // Assume the API is running for the purpose of this test
    }

    [When("I send a GET request to /api/FileExplorer/cloudStorageInfo")]
    public async Task WhenISendAGetRequestToApiFileExplorerCloudStorageInfo()
    {
        _response = await _client.GetAsync("/api/FileExplorer/cloudStorageInfo");
        var content = await _response.Content.ReadAsStringAsync();
        _jsonResponse = JObject.Parse(content);
    }

    [Then("the API response should have status code (\d+)")]
    public void ThenTheApiResponseShouldHaveStatusCode(int statusCode)
    {
        _response.StatusCode.Should().Be((System.Net.HttpStatusCode)statusCode);
    }

    [Then("the response should contain the provider name (.*)")]
    public void ThenTheResponseShouldContainTheProviderName(string providerName)
    {
        _jsonResponse["providerName"].ToString().Should().Be(providerName);
    }

    [Then("the response should indicate authentication status as (.*)")]
    public void ThenTheResponseShouldIndicateAuthenticationStatusAs(bool isAuthenticated)
    {
        _jsonResponse["isAuthenticated"].ToObject<bool>().Should().Be(isAuthenticated);
    }

    [Then("the response should show available space as (\d+)")]
    public void ThenTheResponseShouldShowAvailableSpaceAs(long availableSpace)
    {
        _jsonResponse["availableSpace"].ToObject<long>().Should().Be(availableSpace);
    }

    [Then("the response should show used space as (\d+)")]
    public void ThenTheResponseShouldShowUsedSpaceAs(long usedSpace)
    {
        _jsonResponse["usedSpace"].ToObject<long>().Should().Be(usedSpace);
    }

    [Then("the response metadata should have creation date (.*)")]
    public void ThenTheResponseMetadataShouldHaveCreationDate(string creationDate)
    {
        _jsonResponse["metadata"]["creationDate"].ToString().Should().Be(creationDate);
    }

    [Then("the response metadata should have last modified date (.*)")]
    public void ThenTheResponseMetadataShouldHaveLastModifiedDate(string lastModifiedDate)
    {
        _jsonResponse["metadata"]["lastModifiedDate"].ToString().Should().Be(lastModifiedDate);
    }
}