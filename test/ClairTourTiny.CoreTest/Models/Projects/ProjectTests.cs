using System;
using System.Text.Json;
using Xunit;
using ClairTourTiny.Core.Models.Projects;

namespace ClairTourTiny.Tests.Models.Projects
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
            var project = new Project
            {
                EntityNo = "123",
                EntityDesc = "Test Project",
                StatusGroup = null,
                SortOrder = null,
                ProjectGroup = null,
                DisplayOrder = null,
                GroupDisplayOrder = null
            };

            // Act
            var json = JsonSerializer.Serialize(project);

            // Assert
            Assert.Contains("EntityNo", json);
            Assert.Contains("EntityDesc", json);
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
            var project = new Project
            {
                EntityNo = "123",
                EntityDesc = "Test Project",
                StatusGroup = "Active",
                SortOrder = 1,
                ProjectGroup = "Group1",
                DisplayOrder = "1",
                GroupDisplayOrder = "A"
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