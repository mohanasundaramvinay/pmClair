using Xunit.Gherkin.Quick;
using System.Net.Http;
using System.Threading.Tasks;
using FluentAssertions;

[FeatureFile("FileSharingRemoveAll.feature")]
public sealed class FileSharingRemoveAllSteps : Feature
{
    private readonly HttpClient _client;
    private HttpResponseMessage _response;

    public FileSharingRemoveAllSteps()
    {
        _client = new HttpClient();
        _client.BaseAddress = new System.Uri("http://localhost:5000");
    }

    [When("I send a POST request to /api/FileSharing/remove-all with entityNo \"(.*)\" and template \"(.*)\"")]
    public async Task WhenISendAPostRequestToRemoveAll(string entityNo, string template)
    {
        var requestUri = $"/api/FileSharing/remove-all?entityNo={entityNo}&template={template}";
        _response = await _client.PostAsync(requestUri, null);
    }

    [Then("the API response should be: \"(.*)\"")]
    public void ThenTheApiResponseShouldBe(string expectedStatusCode)
    {
        var expectedStatus = (System.Net.HttpStatusCode)int.Parse(expectedStatusCode);
        _response.StatusCode.Should().Be(expectedStatus);
    }
}