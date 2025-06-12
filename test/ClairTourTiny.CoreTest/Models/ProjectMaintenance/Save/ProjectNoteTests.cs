using System;
using NUnit.Framework;
using ClairTourTiny.Core.Models.ProjectMaintenance.Save;

namespace ClairTourTiny.Tests.Models.ProjectMaintenance.Save
{
    [TestFixture]
    public class ProjectNoteTests
    {
        [Test]
        public void DefaultValues_ShouldBeCorrect()
        {
            var projectNote = new ProjectNote();
            Assert.AreEqual(default(DateTime), projectNote.UpdateTime, "UpdateTime should be default DateTime");
            Assert.IsFalse(projectNote.IsInsert, "IsInsert should be false by default");
            Assert.IsFalse(projectNote.IsUpdate, "IsUpdate should be false by default");
            Assert.IsFalse(projectNote.IsDelete, "IsDelete should be false by default");
            Assert.IsNotNull(projectNote.Entityno, "Entityno should not be null by default");
            Assert.IsNotNull(projectNote.Notes, "Notes should not be null by default");
        }

        [Test]
        public void Properties_ShouldBeSettable()
        {
            var projectNote = new ProjectNote();
            var testDateTime = new DateTime(2023, 10, 1);
            projectNote.UpdateTime = testDateTime;
            projectNote.IsInsert = true;
            projectNote.IsUpdate = true;
            projectNote.IsDelete = true;
            projectNote.Entityno = "TestEntity";
            projectNote.Notes = "Test notes";

            Assert.AreEqual(testDateTime, projectNote.UpdateTime, "UpdateTime should be settable");
            Assert.IsTrue(projectNote.IsInsert, "IsInsert should be settable");
            Assert.IsTrue(projectNote.IsUpdate, "IsUpdate should be settable");
            Assert.IsTrue(projectNote.IsDelete, "IsDelete should be settable");
            Assert.AreEqual("TestEntity", projectNote.Entityno, "Entityno should be settable");
            Assert.AreEqual("Test notes", projectNote.Notes, "Notes should be settable");
        }
    }
}