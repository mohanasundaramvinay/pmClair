using System.Text.Json;
using Xunit;
using ClairTourTiny.Core.Models.ProjectMaintenance;
namespace ClairTourTiny.Tests
{
    public class ProjectClientContactModelTests
    {
        [Fact]
        public void TestPropertyAssignments()
        {
            var model = new ProjectClientContactModel();
            model.EntityNo = "123";
            model.IdContactCategory = 1;
            model.ContactNo = "456";
            model.SortOrder = 2;
            model.ContactName = "John Doe";
            Assert.Equal("123", model.EntityNo);
            Assert.Equal(1, model.IdContactCategory);
            Assert.Equal("456", model.ContactNo);
            Assert.Equal(2, model.SortOrder);
            Assert.Equal("John Doe", model.ContactName);
        }
        [Fact]
        public void TestJsonSerialization()
        {
            var model = new ProjectClientContactModel
            {
                EntityNo = "123",
                IdContactCategory = 1,
                ContactNo = "456",
                SortOrder = 2,
                ContactName = "John Doe"
            };
            var json = JsonSerializer.Serialize(model);
            var expectedJson = "{"Category":1,"ContactNo":"456","SortOrder":2,"Name":"John Doe","EntityNo":"123"}";
            Assert.Equal(expectedJson, json);
        }
        [Fact]
        public void TestJsonDeserialization()
        {
            var json = "{"Category":1,"ContactNo":"456","SortOrder":2,"Name":"John Doe","EntityNo":"123"}";
            var model = JsonSerializer.Deserialize<ProjectClientContactModel>(json);
            Assert.NotNull(model);
            Assert.Equal("123", model.EntityNo);
            Assert.Equal(1, model.IdContactCategory);
            Assert.Equal("456", model.ContactNo);
            Assert.Equal(2, model.SortOrder);
            Assert.Equal("John Doe", model.ContactName);
        }
    }
}