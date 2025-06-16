using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Xunit.Gherkin.Quick;
using Newtonsoft.Json;

[FeatureFile("FileSharingFeature.feature")]
public sealed class FileSharingSteps : Feature
{
    private readonly HttpClient _client;
    private HttpResponseMessage _response;

    public FileSharingSteps()
    {
        _client = new HttpClient();
        _client.BaseAddress = new System.Uri("http://localhost:5000");
    }

    [When("I send a POST request to /api/FileSharing/share-all with the following share request details:")]
    public async Task WhenISendAPostRequestToApiFileSharingShareAllWithTheFollowingShareRequestDetails(Table table)
    {
        var requests = new List<dynamic>();
        foreach (var row in table.Rows)
        {
            requests.Add(new
            {
                Email = row["Email"],
                EntityNo = row["EntityNo"],
                CloudFolderTemplate = row["CloudFolderTemplate"],
                AttachmentCategory = row["AttachmentCategory"],
                UserFolderPath = row["UserFolderPath"],
                Note = row["Note"]
            });
        }
        var content = new StringContent(JsonConvert.SerializeObject(requests), Encoding.UTF8, "application/json");
        _response = await _client.PostAsync("/api/FileSharing/share-all", content);
    }

    [Then("the API response should be: (.*)")]
    public void ThenTheApiResponseShouldBe(int statusCode)
    {
        Assert.Equal(statusCode, (int)_response.StatusCode);
    }
}