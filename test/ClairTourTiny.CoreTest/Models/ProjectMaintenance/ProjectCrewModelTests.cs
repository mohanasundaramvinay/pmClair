using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;
using Moq;
namespace ClairTourTiny.Core.Models.ProjectMaintenance.Tests
{
    public class ProjectCrewModelTests
    {
        [Fact]
        public void AssignedHours_ShouldReturnSumOfEstHours_WhenStatusCodeIsA()
        {
            // Arrange
            var mockAssignedCrew = new List<ProjectAssignedCrewModel>
            {
                new ProjectAssignedCrewModel { StatusCode = "A", EstHours = 5.0 },
                new ProjectAssignedCrewModel { StatusCode = "A", EstHours = 3.0 },
                new ProjectAssignedCrewModel { StatusCode = "B", EstHours = 2.0 }
            };
            var projectCrew = new ProjectCrewModel
            {
                AssignedCrew = mockAssignedCrew
            };
            // Act
            var assignedHours = projectCrew.AssignedHours;
            // Assert
            Assert.Equal(8.0, assignedHours);
        }
        [Fact]
        public void AssignedHours_ShouldReturnZero_WhenNoAssignedCrew()
        {
            // Arrange
            var projectCrew = new ProjectCrewModel();
            // Act
            var assignedHours = projectCrew.AssignedHours;
            // Assert
            Assert.Equal(0, assignedHours);
        }
        [Fact]
        public void Days_ShouldReturnCorrectNumberOfDays_WhenDatesAreDifferent()
        {
            // Arrange
            var projectCrew = new ProjectCrewModel
            {
                FromDate = new DateTime(2023, 10, 1),
                ToDate = new DateTime(2023, 10, 5),
                CrewSize = 2
            };
            // Act
            var days = projectCrew.Days;
            // Assert
            Assert.Equal(10, days);
        }
        [Fact]
        public void Days_ShouldReturnZero_WhenFromDateEqualsToDateAndCrewSizeIsZero()
        {
            // Arrange
            var projectCrew = new ProjectCrewModel
            {
                FromDate = new DateTime(2023, 10, 1),
                ToDate = new DateTime(2023, 10, 1),
                CrewSize = 0
            };
            // Act
            var days = projectCrew.Days;
            // Assert
            Assert.Equal(0, days);
        }
        [Fact]
        public void DefaultValues_ShouldBeSetCorrectly()
        {
            // Arrange & Act
            var projectCrew = new ProjectCrewModel();
            // Assert
            Assert.Equal(string.Empty, projectCrew.EntityNo);
            Assert.Equal(string.Empty, projectCrew.JobType);
            Assert.Equal(string.Empty, projectCrew.JobDesc);
            Assert.Empty(projectCrew.AssignedCrew);
        }
    }
    // Mock class for ProjectAssignedCrewModel
    public class ProjectAssignedCrewModel
    {
        public string StatusCode { get; set; }
        public double EstHours { get; set; }
    }
}