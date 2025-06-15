using System;
using NUnit.Framework;
using ClairTourTiny.Core.Models.ProjectMaintenance;

namespace ClairTourTiny.Tests.Models.ProjectMaintenance
{
    [TestFixture]
    public class ProjectAssignedCrewOtModelTests
    {
        [Test]
        public void Test_EmpNo_Property()
        {
            var model = new ProjectAssignedCrewOtModel();
            var testValue = "12345";
            model.EmpNo = testValue;
            Assert.AreEqual(testValue, model.EmpNo);
        }

        [Test]
        public void Test_EntityNo_Property()
        {
            var model = new ProjectAssignedCrewOtModel();
            var testValue = "ENT001";
            model.EntityNo = testValue;
            Assert.AreEqual(testValue, model.EntityNo);
        }

        [Test]
        public void Test_JobType_Property()
        {
            var model = new ProjectAssignedCrewOtModel();
            var testValue = "FullTime";
            model.JobType = testValue;
            Assert.AreEqual(testValue, model.JobType);
        }

        [Test]
        public void Test_FromDate_Property()
        {
            var model = new ProjectAssignedCrewOtModel();
            var testValue = new DateTime(2023, 10, 1);
            model.FromDate = testValue;
            Assert.AreEqual(testValue, model.FromDate);
        }

        [Test]
        public void Test_RateType_Property()
        {
            var model = new ProjectAssignedCrewOtModel();
            var testValue = "Hourly";
            model.RateType = testValue;
            Assert.AreEqual(testValue, model.RateType);
        }

        [Test]
        public void Test_Hours_Property()
        {
            var model = new ProjectAssignedCrewOtModel();
            var testValue = 8.5;
            model.Hours = testValue;
            Assert.AreEqual(testValue, model.Hours);
        }
    }
}