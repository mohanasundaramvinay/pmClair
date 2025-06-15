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
                new ProjectAssignedCrewModel { StatusCode = "B", EstHours = 3.0 },
                new ProjectAssignedCrewModel { StatusCode = "A", EstHours = 2.0 }
            };
            var projectCrew = new ProjectCrewModel
            {
                AssignedCrew = mockAssignedCrew
            };
            // Act
            var assignedHours = projectCrew.AssignedHours;
            // Assert
            Assert.Equal(7.0, assignedHours);
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
        public void Days_ShouldReturnCorrectDays_WhenFromDateAndToDateAreGiven()
        {
            // Arrange
            var projectCrew = new ProjectCrewModel
            {
                FromDate = new DateTime(2023, 10, 1),
                ToDate = new DateTime(2023, 10, 5),
                CrewSize = 3
            };
            // Act
            var days = projectCrew.Days;
            // Assert
            Assert.Equal(15, days); // 5 days * 3 crew size
        }
        [Fact]
        public void Days_ShouldReturnZero_WhenCrewSizeIsZero()
        {
            // Arrange
            var projectCrew = new ProjectCrewModel
            {
                FromDate = new DateTime(2023, 10, 1),
                ToDate = new DateTime(2023, 10, 5),
                CrewSize = 0
            };
            // Act
            var days = projectCrew.Days;
            // Assert
            Assert.Equal(0, days);
        }
        [Fact]
        public void Days_ShouldReturnCorrectDays_WhenFromDateEqualsToDate()
        {
            // Arrange
            var projectCrew = new ProjectCrewModel
            {
                FromDate = new DateTime(2023, 10, 1),
                ToDate = new DateTime(2023, 10, 1),
                CrewSize = 2
            };
            // Act
            var days = projectCrew.Days;
            // Assert
            Assert.Equal(2, days); // 1 day * 2 crew size
        }
    }
    // Mock class for ProjectAssignedCrewModel
    public class ProjectAssignedCrewModel
    {
        public string StatusCode { get; set; }
        public double EstHours { get; set; }
    }
}