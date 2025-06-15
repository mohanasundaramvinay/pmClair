using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClairTourTiny.Core.Services;
using ClairTourTiny.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Moq;
using Xunit;
namespace ClairTourTiny.Tests
{
    public class PhaseServiceTests
    {
        [Fact]
        public async Task GetSuffixes_ReturnsCorrectSuffixes()
        {
            // Arrange
            var mockContext = new Mock<ClairTourTinyContext>();
            var mockSuffixes = new List<ProjectDefaultSuffix>
            {
                new ProjectDefaultSuffix { Suffix = "_test1" },
                new ProjectDefaultSuffix { Suffix = "_test2" }
            }.AsQueryable();
            var mockDbSet = new Mock<DbSet<ProjectDefaultSuffix>>();
            mockDbSet.As<IQueryable<ProjectDefaultSuffix>>().Setup(m => m.Provider).Returns(mockSuffixes.Provider);
            mockDbSet.As<IQueryable<ProjectDefaultSuffix>>().Setup(m => m.Expression).Returns(mockSuffixes.Expression);
            mockDbSet.As<IQueryable<ProjectDefaultSuffix>>().Setup(m => m.ElementType).Returns(mockSuffixes.ElementType);
            mockDbSet.As<IQueryable<ProjectDefaultSuffix>>().Setup(m => m.GetEnumerator()).Returns(mockSuffixes.GetEnumerator());
            mockContext.Setup(c => c.ProjectDefaultSuffixes).Returns(mockDbSet.Object);
            var service = new PhaseService(mockContext.Object);
            // Act
            var result = await service.GetSuffixes();
            // Assert
            Assert.Equal(2, result.Count);
            Assert.Contains("_test1", result);
            Assert.Contains("_test2", result);
        }
        [Fact]
        public async Task GetSuffixes_ReturnsEmptyList_WhenNoSuffixes()
        {
            // Arrange
            var mockContext = new Mock<ClairTourTinyContext>();
            var mockSuffixes = new List<ProjectDefaultSuffix>().AsQueryable();
            var mockDbSet = new Mock<DbSet<ProjectDefaultSuffix>>();
            mockDbSet.As<IQueryable<ProjectDefaultSuffix>>().Setup(m => m.Provider).Returns(mockSuffixes.Provider);
            mockDbSet.As<IQueryable<ProjectDefaultSuffix>>().Setup(m => m.Expression).Returns(mockSuffixes.Expression);
            mockDbSet.As<IQueryable<ProjectDefaultSuffix>>().Setup(m => m.ElementType).Returns(mockSuffixes.ElementType);
            mockDbSet.As<IQueryable<ProjectDefaultSuffix>>().Setup(m => m.GetEnumerator()).Returns(mockSuffixes.GetEnumerator());
            mockContext.Setup(c => c.ProjectDefaultSuffixes).Returns(mockDbSet.Object);
            var service = new PhaseService(mockContext.Object);
            // Act
            var result = await service.GetSuffixes();
            // Assert
            Assert.Empty(result);
        }
    }
}