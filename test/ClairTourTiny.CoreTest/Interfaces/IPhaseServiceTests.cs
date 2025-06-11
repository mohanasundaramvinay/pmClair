using System.Collections.Generic;
using System.Threading.Tasks;
using Moq;
using Xunit;
namespace ClairTourTiny.Core.Tests
{
    public class PhaseServiceTests
    {
        [Fact]
        public async Task GetSuffixes_ShouldReturnListOfStrings()
        {
            // Arrange
            var mockPhaseService = new Mock<IPhaseService>();
            var expectedSuffixes = new List<string> { "suffix1", "suffix2", "suffix3" };
            mockPhaseService.Setup(service => service.GetSuffixes()).ReturnsAsync(expectedSuffixes);
            
            // Act
            var result = await mockPhaseService.Object.GetSuffixes();
            
            // Assert
            Assert.Equal(expectedSuffixes, result);
        }
    }
}