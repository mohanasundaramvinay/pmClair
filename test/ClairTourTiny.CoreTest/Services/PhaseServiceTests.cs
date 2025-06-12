using ClairTourTiny.Core.Services;
using ClairTourTiny.Core.Interfaces;
using Moq;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;
using Microsoft.EntityFrameworkCore;
namespace ClairTourTiny.Tests
{
    public class PhaseServiceTests
    {
        private readonly Mock<ClairTourTinyContext> _mockContext;
        private readonly Mock<DbSet<ProjectDefaultSuffix>> _mockDbSet;
        private readonly PhaseService _phaseService;
        public PhaseServiceTests()
        {
            _mockContext = new Mock<ClairTourTinyContext>();
            _mockDbSet = new Mock<DbSet<ProjectDefaultSuffix>>();
            _mockContext.Setup(c => c.ProjectDefaultSuffixes).Returns(_mockDbSet.Object);
            _phaseService = new PhaseService(_mockContext.Object);
        }
        [Fact]
        public async Task GetSuffixes_ReturnsCorrectSuffixes()
        {
            // Arrange
            var suffixes = new List<ProjectDefaultSuffix>
            {
                new ProjectDefaultSuffix { Suffix = "_test1" },
                new ProjectDefaultSuffix { Suffix = "_test2" }
            }.AsQueryable();
            _mockDbSet.As<IQueryable<ProjectDefaultSuffix>>().Setup(m => m.Provider).Returns(suffixes.Provider);
            _mockDbSet.As<IQueryable<ProjectDefaultSuffix>>().Setup(m => m.Expression).Returns(suffixes.Expression);
            _mockDbSet.As<IQueryable<ProjectDefaultSuffix>>().Setup(m => m.ElementType).Returns(suffixes.ElementType);
            _mockDbSet.As<IQueryable<ProjectDefaultSuffix>>().Setup(m => m.GetEnumerator()).Returns(suffixes.GetEnumerator());
            // Act
            var result = await _phaseService.GetSuffixes();
            // Assert
            Assert.Equal(2, result.Count);
            Assert.Contains("_test1", result);
            Assert.Contains("_test2", result);
        }
        [Fact]
        public async Task GetSuffixes_ReturnsEmptyList_WhenNoSuffixes()
        {
            // Arrange
            var suffixes = new List<ProjectDefaultSuffix>().AsQueryable();
            _mockDbSet.As<IQueryable<ProjectDefaultSuffix>>().Setup(m => m.Provider).Returns(suffixes.Provider);
            _mockDbSet.As<IQueryable<ProjectDefaultSuffix>>().Setup(m => m.Expression).Returns(suffixes.Expression);
            _mockDbSet.As<IQueryable<ProjectDefaultSuffix>>().Setup(m => m.ElementType).Returns(suffixes.ElementType);
            _mockDbSet.As<IQueryable<ProjectDefaultSuffix>>().Setup(m => m.GetEnumerator()).Returns(suffixes.GetEnumerator());
            // Act
            var result = await _phaseService.GetSuffixes();
            // Assert
            Assert.Empty(result);
        }
    }
}