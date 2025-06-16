using System;
using NUnit.Framework;
using ClairTourTiny.Core.Models.ProjectMaintenance.Save;

namespace ClairTourTiny.Tests.Models.ProjectMaintenance.Save
{
    [TestFixture]
    public class ProjectEmployeeOvertimeRateTests
    {
        [Test]
        public void UpdateTime_ShouldBeSetAndRetrievedCorrectly()
        {
            var overtimeRate = new ProjectEmployeeOvertimeRate();
            var updateTime = DateTime.Now;
            overtimeRate.UpdateTime = updateTime;
            Assert.AreEqual(updateTime, overtimeRate.UpdateTime);
        }

        [Test]
        public void IsInsert_ShouldBeSetAndRetrievedCorrectly()
        {
            var overtimeRate = new ProjectEmployeeOvertimeRate();
            overtimeRate.IsInsert = true;
            Assert.IsTrue(overtimeRate.IsInsert);
        }

        [Test]
        public void IsUpdate_ShouldBeSetAndRetrievedCorrectly()
        {
            var overtimeRate = new ProjectEmployeeOvertimeRate();
            overtimeRate.IsUpdate = true;
            Assert.IsTrue(overtimeRate.IsUpdate);
        }

        [Test]
        public void IsDelete_ShouldBeSetAndRetrievedCorrectly()
        {
            var overtimeRate = new ProjectEmployeeOvertimeRate();
            overtimeRate.IsDelete = true;
            Assert.IsTrue(overtimeRate.IsDelete);
        }

        [Test]
        public void Empno_ShouldBeSetAndRetrievedCorrectly()
        {
            var overtimeRate = new ProjectEmployeeOvertimeRate();
            var empno = "E123";
            overtimeRate.Empno = empno;
            Assert.AreEqual(empno, overtimeRate.Empno);
        }

        [Test]
        public void Entityno_ShouldBeSetAndRetrievedCorrectly()
        {
            var overtimeRate = new ProjectEmployeeOvertimeRate();
            var entityno = "ENT456";
            overtimeRate.Entityno = entityno;
            Assert.AreEqual(entityno, overtimeRate.Entityno);
        }

        [Test]
        public void Jobtype_ShouldBeSetAndRetrievedCorrectly()
        {
            var overtimeRate = new ProjectEmployeeOvertimeRate();
            var jobtype = "FullTime";
            overtimeRate.Jobtype = jobtype;
            Assert.AreEqual(jobtype, overtimeRate.Jobtype);
        }

        [Test]
        public void Fromdate_ShouldBeSetAndRetrievedCorrectly()
        {
            var overtimeRate = new ProjectEmployeeOvertimeRate();
            var fromdate = new DateTime(2023, 1, 1);
            overtimeRate.Fromdate = fromdate;
            Assert.AreEqual(fromdate, overtimeRate.Fromdate);
        }

        [Test]
        public void RateType_ShouldBeSetAndRetrievedCorrectly()
        {
            var overtimeRate = new ProjectEmployeeOvertimeRate();
            var rateType = "Overtime";
            overtimeRate.RateType = rateType;
            Assert.AreEqual(rateType, overtimeRate.RateType);
        }

        [Test]
        public void Hours_ShouldBeSetAndRetrievedCorrectly()
        {
            var overtimeRate = new ProjectEmployeeOvertimeRate();
            var hours = 8.5;
            overtimeRate.Hours = hours;
            Assert.AreEqual(hours, overtimeRate.Hours);
        }
    }
}