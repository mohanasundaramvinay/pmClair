using NUnit.Framework;
using System;
namespace ClairTourTiny.Core.Models.ProjectMaintenance.Save.Tests
{
    [TestFixture]
    public class ProjectEmployeeOvertimeRateTests
    {
        [Test]
        public void UpdateTime_Property_SetAndGet_ShouldReturnCorrectValue()
        {
            var overtimeRate = new ProjectEmployeeOvertimeRate();
            var expectedDate = DateTime.Now;
            overtimeRate.UpdateTime = expectedDate;
            Assert.AreEqual(expectedDate, overtimeRate.UpdateTime);
        }

        [Test]
        public void IsInsert_Property_SetAndGet_ShouldReturnCorrectValue()
        {
            var overtimeRate = new ProjectEmployeeOvertimeRate();
            overtimeRate.IsInsert = true;
            Assert.IsTrue(overtimeRate.IsInsert);
        }

        [Test]
        public void IsUpdate_Property_SetAndGet_ShouldReturnCorrectValue()
        {
            var overtimeRate = new ProjectEmployeeOvertimeRate();
            overtimeRate.IsUpdate = true;
            Assert.IsTrue(overtimeRate.IsUpdate);
        }

        [Test]
        public void IsDelete_Property_SetAndGet_ShouldReturnCorrectValue()
        {
            var overtimeRate = new ProjectEmployeeOvertimeRate();
            overtimeRate.IsDelete = true;
            Assert.IsTrue(overtimeRate.IsDelete);
        }

        [Test]
        public void Empno_Property_SetAndGet_ShouldReturnCorrectValue()
        {
            var overtimeRate = new ProjectEmployeeOvertimeRate();
            var expectedEmpno = "E123";
            overtimeRate.Empno = expectedEmpno;
            Assert.AreEqual(expectedEmpno, overtimeRate.Empno);
        }

        [Test]
        public void Entityno_Property_SetAndGet_ShouldReturnCorrectValue()
        {
            var overtimeRate = new ProjectEmployeeOvertimeRate();
            var expectedEntityno = "ENT456";
            overtimeRate.Entityno = expectedEntityno;
            Assert.AreEqual(expectedEntityno, overtimeRate.Entityno);
        }

        [Test]
        public void Jobtype_Property_SetAndGet_ShouldReturnCorrectValue()
        {
            var overtimeRate = new ProjectEmployeeOvertimeRate();
            var expectedJobtype = "FullTime";
            overtimeRate.Jobtype = expectedJobtype;
            Assert.AreEqual(expectedJobtype, overtimeRate.Jobtype);
        }

        [Test]
        public void Fromdate_Property_SetAndGet_ShouldReturnCorrectValue()
        {
            var overtimeRate = new ProjectEmployeeOvertimeRate();
            var expectedFromdate = new DateTime(2023, 1, 1);
            overtimeRate.Fromdate = expectedFromdate;
            Assert.AreEqual(expectedFromdate, overtimeRate.Fromdate);
        }

        [Test]
        public void RateType_Property_SetAndGet_ShouldReturnCorrectValue()
        {
            var overtimeRate = new ProjectEmployeeOvertimeRate();
            var expectedRateType = "Overtime";
            overtimeRate.RateType = expectedRateType;
            Assert.AreEqual(expectedRateType, overtimeRate.RateType);
        }

        [Test]
        public void Hours_Property_SetAndGet_ShouldReturnCorrectValue()
        {
            var overtimeRate = new ProjectEmployeeOvertimeRate();
            var expectedHours = 8.5;
            overtimeRate.Hours = expectedHours;
            Assert.AreEqual(expectedHours, overtimeRate.Hours);
        }
    }
}