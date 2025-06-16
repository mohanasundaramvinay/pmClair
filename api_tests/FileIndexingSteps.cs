using Xunit.Gherkin.Quick;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using FluentAssertions;

[FeatureFile("FileIndexing.feature")]
public sealed class FileIndexingSteps : Feature
{
    private readonly HttpClient _client = new HttpClient();
    private HttpResponseMessage _response;
    private string _responseContent;

    [When("I send a POST request to /api/FileSharing/index-file with filePath \"(.*)\", guid \"(.*)\", and subFolderPath \"(.*)\"")]
    public async Task WhenISendAPostRequestToIndexFile(string filePath, string guid, string subFolderPath)
    {
        var requestUri = $"http://localhost:5000/api/FileSharing/index-file?filePath={filePath}&guid={guid}&subFolderPath={subFolderPath}";
        _response = await _client.PostAsync(requestUri, null);
        _responseContent = await _response.Content.ReadAsStringAsync();
    }

    [Then("the API response should be a success message \"(.*)\"")]
    public void ThenTheApiResponseShouldBeASuccessMessage(string expectedMessage)
    {
        _response.IsSuccessStatusCode.Should().BeTrue();
        var responseObject = JsonConvert.DeserializeObject<dynamic>(_responseContent);
        ((string)responseObject.message).Should().Be(expectedMessage);
    }

    [Then("the API response should be an error message \"(.*)\"")]
    public void ThenTheApiResponseShouldBeAnErrorMessage(string expectedError)
    {
        _response.IsSuccessStatusCode.Should().BeFalse();
        var responseObject = JsonConvert.DeserializeObject<dynamic>(_responseContent);
        ((string)responseObject.error).Should().Contain(expectedError);
    }
}