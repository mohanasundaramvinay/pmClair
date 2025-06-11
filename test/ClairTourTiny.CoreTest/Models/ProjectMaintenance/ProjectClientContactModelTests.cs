using System.Text.Json.Serialization;
using Xunit;
namespace ClairTourTiny.Core.Models.ProjectMaintenance.Tests
{
    public class ProjectClientContactModelTests
    {
        [Fact]
        public void DefaultValues_ShouldBeCorrect()
        {
            var model = new ProjectClientContactModel();
            Assert.Equal(string.Empty, model.EntityNo);
            Assert.Equal(0, model.IdContactCategory);
            Assert.Equal(string.Empty, model.ContactNo);
            Assert.Equal(0, model.SortOrder);
            Assert.Null(model.ContactName);
        }
        [Fact]
        public void SetAndGetValues_ShouldBeCorrect()
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
        public void JsonPropertyNameAttributes_ShouldBeCorrect()
        {
            var idContactCategoryProperty = typeof(ProjectClientContactModel).GetProperty("IdContactCategory");
            var contactNameProperty = typeof(ProjectClientContactModel).GetProperty("ContactName");
            var idContactCategoryAttribute = (JsonPropertyNameAttribute)Attribute.GetCustomAttribute(idContactCategoryProperty, typeof(JsonPropertyNameAttribute));
            var contactNameAttribute = (JsonPropertyNameAttribute)Attribute.GetCustomAttribute(contactNameProperty, typeof(JsonPropertyNameAttribute));
            Assert.Equal("Category", idContactCategoryAttribute.Name);
            Assert.Equal("Name", contactNameAttribute.Name);
        }
    }
}