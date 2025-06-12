using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using Xunit;
namespace ClairTourTiny.Core.Models.ProjectMaintenance.Tests
{
    public class ProjectProductionScheduleModelTests
    {
        [Fact]
        public void DefaultValues_ShouldBeCorrect()
        {
            var model = new ProjectProductionScheduleModel();
            Assert.Equal(string.Empty, model.EntityNo);
            Assert.Equal(string.Empty, model.EventType);
            Assert.Equal(default(DateTime), model.StartDate);
            Assert.Null(model.EndDate);
            Assert.Null(model.VenueID);
            Assert.Null(model.DestinationDetail);
            Assert.Null(model.Note);
            Assert.Null(model.LocationName);
            Assert.Equal(0, model.DisplayOrder);
        }
        [Fact]
        public void PropertyAssignment_ShouldBeCorrect()
        {
            var model = new ProjectProductionScheduleModel
            {
                EntityNo = "123",
                EventType = "Conference",
                StartDate = new DateTime(2023, 10, 1),
                EndDate = new DateTime(2023, 10, 5),
                VenueID = 10,
                DestinationDetail = "New York",
                Note = "Important event",
                LocationName = "Central Park",
                DisplayOrder = 1
            };
            Assert.Equal("123", model.EntityNo);
            Assert.Equal("Conference", model.EventType);
            Assert.Equal(new DateTime(2023, 10, 1), model.StartDate);
            Assert.Equal(new DateTime(2023, 10, 5), model.EndDate);
            Assert.Equal(10, model.VenueID);
            Assert.Equal("New York", model.DestinationDetail);
            Assert.Equal("Important event", model.Note);
            Assert.Equal("Central Park", model.LocationName);
            Assert.Equal(1, model.DisplayOrder);
        }
        [Fact]
        public void JsonSerialization_ShouldSerializeCorrectly()
        {
            var model = new ProjectProductionScheduleModel
            {
                EntityNo = "123",
                EventType = "Conference",
                StartDate = new DateTime(2023, 10, 1),
                EndDate = new DateTime(2023, 10, 5),
                VenueID = 10,
                DestinationDetail = "New York",
                Note = "Important event",
                LocationName = "Central Park",
                DisplayOrder = 1
            };
            var json = JsonSerializer.Serialize(model);
            Assert.Contains("\"EntityNo\":\"123\"", json);
            Assert.Contains("\"EventType\":\"Conference\"", json);
            Assert.Contains("\"StartDate\":\"2023-10-01T00:00:00\"", json);
            Assert.Contains("\"EndDate\":\"2023-10-05T00:00:00\"", json);
            Assert.Contains("\"VenueID\":10", json);
            Assert.Contains("\"DestinationDetail\":\"New York\"", json);
            Assert.Contains("\"Note\":\"Important event\"", json);
            Assert.Contains("\"LocationOrVenue\":\"Central Park\"", json);
            Assert.Contains("\"DisplayOrder\":1", json);
        }
        [Fact]
        public void JsonDeserialization_ShouldDeserializeCorrectly()
        {
            var json = "{" +
                        "\"EntityNo\":\"123\"," +
                        "\"EventType\":\"Conference\"," +
                        "\"StartDate\":\"2023-10-01T00:00:00\"," +
                        "\"EndDate\":\"2023-10-05T00:00:00\"," +
                        "\"VenueID\":10," +
                        "\"DestinationDetail\":\"New York\"," +
                        "\"Note\":\"Important event\"," +
                        "\"LocationOrVenue\":\"Central Park\"," +
                        "\"DisplayOrder\":1" +
                        "}";
            var model = JsonSerializer.Deserialize<ProjectProductionScheduleModel>(json);
            Assert.Equal("123", model.EntityNo);
            Assert.Equal("Conference", model.EventType);
            Assert.Equal(new DateTime(2023, 10, 1), model.StartDate);
            Assert.Equal(new DateTime(2023, 10, 5), model.EndDate);
            Assert.Equal(10, model.VenueID);
            Assert.Equal("New York", model.DestinationDetail);
            Assert.Equal("Important event", model.Note);
            Assert.Equal("Central Park", model.LocationName);
            Assert.Equal(1, model.DisplayOrder);
        }
    }
}