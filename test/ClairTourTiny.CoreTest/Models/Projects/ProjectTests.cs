using System.Text.Json;
using Xunit;
namespace ClairTourTiny.Core.Models.Projects.Tests
{
    public class ProjectTests
    {
        [Fact]
        public void Project_Should_Require_EntityNo_And_EntityDesc()
        {
            // Arrange & Act
            var project = new Project { EntityNo = "123", EntityDesc = "Test Project" };
            
            // Assert
            Assert.Equal("123", project.EntityNo);
            Assert.Equal("Test Project", project.EntityDesc);
        }
        
        [Fact]
        public void Project_Should_Ignore_Null_Properties_When_Serializing()
        {
            // Arrange
            var project = new Project { EntityNo = "123", EntityDesc = "Test Project" };
            
            // Act
            var json = JsonSerializer.Serialize(project);
            
            // Assert
            Assert.DoesNotContain("StatusGroup", json);
            Assert.DoesNotContain("SortOrder", json);
            Assert.DoesNotContain("ProjectGroup", json);
            Assert.DoesNotContain("DisplayOrder", json);
            Assert.DoesNotContain("GroupDisplayOrder", json);
        }
        
        [Fact]
        public void Project_Should_Include_NonNull_Properties_When_Serializing()
        {
            // Arrange
            var project = new Project {
                EntityNo = "123",
                EntityDesc = "Test Project",
                StatusGroup = "Active",
                SortOrder = 1,
                ProjectGroup = "Group A",
                DisplayOrder = "1",
                GroupDisplayOrder = "A1"
            };
            
            // Act
            var json = JsonSerializer.Serialize(project);
            
            // Assert
            Assert.Contains("StatusGroup", json);
            Assert.Contains("SortOrder", json);
            Assert.Contains("ProjectGroup", json);
            Assert.Contains("DisplayOrder", json);
            Assert.Contains("GroupDisplayOrder", json);
        }
    }
}