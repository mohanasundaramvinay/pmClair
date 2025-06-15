using Xunit.Gherkin.Quick;
using System.Net.Http;
using System.Threading.Tasks;
using FluentAssertions;
using Newtonsoft.Json;
using System.Collections.Generic;

[FeatureFile("ProjectNotes.feature")]
public sealed class ProjectNotesSteps : Feature
{
    private readonly HttpClient _client = new HttpClient();
    private HttpResponseMessage _response;
    private string _baseUrl = "http://localhost:5000/api/projects/";

    [When("I send a GET request to /api/projects/(.*)/notes")]
    public async Task WhenISendAGetRequestToApiProjectsNotes(string entityNo)
    {
        _response = await _client.GetAsync(_baseUrl + entityNo + "/notes");
    }

    [Then("the API response should be (.*)")]
    public void ThenTheApiResponseShouldBe(int statusCode)
    {
        _response.StatusCode.Should().Be((System.Net.HttpStatusCode)statusCode);
    }

    [Then("the response should contain a list of notes")]
    public async Task ThenTheResponseShouldContainAListOfNotes()
    {
        var content = await _response.Content.ReadAsStringAsync();
        var notes = JsonConvert.DeserializeObject<List<ProjectNoteModel>>(content);
        notes.Should().NotBeNull();
        notes.Should().BeOfType<List<ProjectNoteModel>>();
    }

    [Then("the response should be an empty list")]
    public async Task ThenTheResponseShouldBeAnEmptyList()
    {
        var content = await _response.Content.ReadAsStringAsync();
        var notes = JsonConvert.DeserializeObject<List<ProjectNoteModel>>(content);
        notes.Should().BeEmpty();
    }
}

public class ProjectNoteModel
{
    public int NoteId { get; set; }
    public string Content { get; set; }
    public string Author { get; set; }
    public string Timestamp { get; set; }
    public int ProjectId { get; set; }
}