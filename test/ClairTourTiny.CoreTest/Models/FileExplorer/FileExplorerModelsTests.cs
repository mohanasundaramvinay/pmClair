using NUnit.Framework;
using ClairTourTiny.Core.Models.FileExplorer;
namespace ClairTourTiny.Tests
{
    [TestFixture]
    public class DropboxInviteeDetailsTests
    {
        [Test]
        public void NameProperty_ShouldSetAndGetCorrectly()
        {
            // Arrange
            var invitee = new DropboxInviteeDetails();
            var expectedName = "John Doe";
            
            // Act
            invitee.Name = expectedName;
            var actualName = invitee.Name;
            
            // Assert
            Assert.AreEqual(expectedName, actualName);
        }
        
        [Test]
        public void EmailProperty_ShouldSetAndGetCorrectly()
        {
            // Arrange
            var invitee = new DropboxInviteeDetails();
            var expectedEmail = "john.doe@example.com";
            
            // Act
            invitee.Email = expectedEmail;
            var actualEmail = invitee.Email;
            
            // Assert
            Assert.AreEqual(expectedEmail, actualEmail);
        }
        
        [Test]
        public void AccessLevelIdProperty_ShouldSetAndGetCorrectly()
        {
            // Arrange
            var invitee = new DropboxInviteeDetails();
            var expectedAccessLevelId = 1;
            
            // Act
            invitee.AccessLevelId = expectedAccessLevelId;
            var actualAccessLevelId = invitee.AccessLevelId;
            
            // Assert
            Assert.AreEqual(expectedAccessLevelId, actualAccessLevelId);
        }
        
        [Test]
        public void AccessLevelDescriptionProperty_ShouldSetAndGetCorrectly()
        {
            // Arrange
            var invitee = new DropboxInviteeDetails();
            var expectedDescription = "Read-Only Access";
            
            // Act
            invitee.AccessLevelDescription = expectedDescription;
            var actualDescription = invitee.AccessLevelDescription;
            
            // Assert
            Assert.AreEqual(expectedDescription, actualDescription);
        }
    }
}