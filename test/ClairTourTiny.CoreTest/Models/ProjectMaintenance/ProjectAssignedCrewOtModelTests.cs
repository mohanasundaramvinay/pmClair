using NUnit.Framework;
using ClairTourTiny.Core.Models.ProjectMaintenance;
using System;

namespace ClairTourTiny.Tests
{
    [TestFixture]
    public class ProjectAssignedCrewOtModelTests
    {
        [Test]
        public void EmpNo_ShouldBeSetAndRetrievedCorrectly()
        {
            var model = new ProjectAssignedCrewOtModel();
            model.EmpNo = "12345";
            Assert.AreEqual("12345", model.EmpNo);
        }

        [Test]
        public void EntityNo_ShouldBeSetAndRetrievedCorrectly()
        {
            var model = new ProjectAssignedCrewOtModel();
            model.EntityNo = "67890";
            Assert.AreEqual("67890", model.EntityNo);
        }

        [Test]
        public void JobType_ShouldBeSetAndRetrievedCorrectly()
        {
            var model = new ProjectAssignedCrewOtModel();
            model.JobType = "FullTime";
            Assert.AreEqual("FullTime", model.JobType);
        }

        [Test]
        public void FromDate_ShouldBeSetAndRetrievedCorrectly()
        {
            var model = new ProjectAssignedCrewOtModel();
            var date = new DateTime(2023, 10, 1);
            model.FromDate = date;
            Assert.AreEqual(date, model.FromDate);
        }

        [Test]
        public void RateType_ShouldBeSetAndRetrievedCorrectly()
        {
            var model = new ProjectAssignedCrewOtModel();
            model.RateType = "Hourly";
            Assert.AreEqual("Hourly", model.RateType);
        }

        [Test]
        public void Hours_ShouldBeSetAndRetrievedCorrectly()
        {
            var model = new ProjectAssignedCrewOtModel();
            model.Hours = 8.5;
            Assert.AreEqual(8.5, model.Hours);
        }

        [Test]
        public void DefaultValues_ShouldBeInitializedCorrectly()
        {
            var model = new ProjectAssignedCrewOtModel();
            Assert.AreEqual(string.Empty, model.EmpNo);
            Assert.AreEqual(string.Empty, model.EntityNo);
            Assert.AreEqual(string.Empty, model.JobType);
            Assert.AreEqual(string.Empty, model.RateType);
        }
    }
}