using System;
using NUnit.Framework;
using ClairTourTiny.Core.Models.ProjectMaintenance.Save;

namespace ClairTourTiny.Tests.Models.ProjectMaintenance.Save
{
    [TestFixture]
    public class ProjectNoteTests
    {
        [Test]
        public void UpdateTime_CanBeSetAndRetrieved()
        {
            var projectNote = new ProjectNote();
            var testTime = new DateTime(2023, 10, 1);
            projectNote.UpdateTime = testTime;
            Assert.AreEqual(testTime, projectNote.UpdateTime);
        }

        [Test]
        public void IsInsert_DefaultValueIsFalse()
        {
            var projectNote = new ProjectNote();
            Assert.IsFalse(projectNote.IsInsert);
        }

        [Test]
        public void IsInsert_CanBeSetToTrue()
        {
            var projectNote = new ProjectNote();
            projectNote.IsInsert = true;
            Assert.IsTrue(projectNote.IsInsert);
        }

        [Test]
        public void IsUpdate_DefaultValueIsFalse()
        {
            var projectNote = new ProjectNote();
            Assert.IsFalse(projectNote.IsUpdate);
        }

        [Test]
        public void IsUpdate_CanBeSetToTrue()
        {
            var projectNote = new ProjectNote();
            projectNote.IsUpdate = true;
            Assert.IsTrue(projectNote.IsUpdate);
        }

        [Test]
        public void IsDelete_DefaultValueIsFalse()
        {
            var projectNote = new ProjectNote();
            Assert.IsFalse(projectNote.IsDelete);
        }

        [Test]
        public void IsDelete_CanBeSetToTrue()
        {
            var projectNote = new ProjectNote();
            projectNote.IsDelete = true;
            Assert.IsTrue(projectNote.IsDelete);
        }

        [Test]
        public void Entityno_CanBeSetAndRetrieved()
        {
            var projectNote = new ProjectNote();
            var testEntityno = "Entity123";
            projectNote.Entityno = testEntityno;
            Assert.AreEqual(testEntityno, projectNote.Entityno);
        }

        [Test]
        public void Notes_CanBeSetAndRetrieved()
        {
            var projectNote = new ProjectNote();
            var testNotes = "This is a test note.";
            projectNote.Notes = testNotes;
            Assert.AreEqual(testNotes, projectNote.Notes);
        }
    }
}