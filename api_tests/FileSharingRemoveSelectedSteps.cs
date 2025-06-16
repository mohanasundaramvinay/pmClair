using Xunit;
using Xunit.Gherkin.Quick;
using System.Net.Http;
using System.Threading.Tasks;
using FluentAssertions;

[FeatureFile("FileSharingRemoveSelected.feature")]
public sealed class FileSharingRemoveSelectedSteps : Feature
{
    private readonly HttpClient _client;
    private HttpResponseMessage _response;

    public FileSharingRemoveSelectedSteps()
    {
        _client = new HttpClient();
        _client.BaseAddress = new System.Uri("http://localhost:5000");
    }

    [Given("I have access to the File Sharing API")]
    public void GivenIHaveAccessToTheFileSharingAPI()
    {
        // Assume access is granted
    }

    [When("I send a POST request to /api/FileSharing/remove-selected with email \"(.*)\", entityNo \"(.*)\", and template \"(.*)\"")]
    public async Task WhenISendAPostRequestToRemoveSelected(string email, string entityNo, string template)
    {
        var requestUri = $"/api/FileSharing/remove-selected?email={email}&entityNo={entityNo}&template={template}";
        _response = await _client.PostAsync(requestUri, null);
    }

    [Then("the API response should be: \"(.*)\"")]
    public void ThenTheApiResponseShouldBe(string expectedStatusCode)
    {
        var expectedStatus = (System.Net.HttpStatusCode)int.Parse(expectedStatusCode);
        _response.StatusCode.Should().Be(expectedStatus);
    }
}