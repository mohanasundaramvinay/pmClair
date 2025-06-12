using Xunit;

namespace ClairTourTiny.Core.Models.ProjectMaintenance.Tests
{
    public class ProjectNoteModelTests
    {
        [Fact]
        public void EntityNo_ShouldBeInitializedAsEmptyString()
        {
            // Arrange
            var projectNote = new ProjectNoteModel();

            // Act
            var entityNo = projectNote.EntityNo;

            // Assert
            Assert.Equal(string.Empty, entityNo);
        }

        [Fact]
        public void Notes_ShouldBeNullByDefault()
        {
            // Arrange
            var projectNote = new ProjectNoteModel();

            // Act
            var notes = projectNote.Notes;

            // Assert
            Assert.Null(notes);
        }

        [Fact]
        public void CanSetAndGetEntityNo()
        {
            // Arrange
            var projectNote = new ProjectNoteModel();
            var testEntityNo = "12345";

            // Act
            projectNote.EntityNo = testEntityNo;

            // Assert
            Assert.Equal(testEntityNo, projectNote.EntityNo);
        }

        [Fact]
        public void CanSetAndGetNotes()
        {
            // Arrange
            var projectNote = new ProjectNoteModel();
            var testNotes = "This is a test note.";

            // Act
            projectNote.Notes = testNotes;

            // Assert
            Assert.Equal(testNotes, projectNote.Notes);
        }

        [Fact]
        public void CanSetNotesToNull()
        {
            // Arrange
            var projectNote = new ProjectNoteModel();

            // Act
            projectNote.Notes = null;

            // Assert
            Assert.Null(projectNote.Notes);
        }
    }
}