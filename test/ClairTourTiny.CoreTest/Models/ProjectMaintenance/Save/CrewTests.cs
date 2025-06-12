using NUnit.Framework;
using System;
namespace ClairTourTiny.Core.Models.ProjectMaintenance.Save.Tests
{
    [TestFixture]
    public class CrewTests
    {
        [Test]
        public void Test_Crew_Properties()
        {
            // Arrange
            var crew = new Crew();
            var updateTime = DateTime.Now;
            var entityNo = "Entity123";
            var seqNo = 1;
            var jobTypeOld = "OldJob";
            var jobTypeNew = "NewJob";
            var jobDesc = "Job Description";
            var fromDate = new DateTime(2023, 1, 1);
            var toDate = new DateTime(2023, 12, 31);
            var crewSize = 10;
            var estHours = 100.5;
            var estRate = 50.75;
            var estTotal = 5075.25m;
            var emplineNo = 12345;
            
            // Act
            crew.UpdateTime = updateTime;
            crew.IsInsert = true;
            crew.IsUpdate = false;
            crew.IsDelete = false;
            crew.Entityno = entityNo;
            crew.Seqno = seqNo;
            crew.JobtypeOld = jobTypeOld;
            crew.JobtypeNew = jobTypeNew;
            crew.Jobdesc = jobDesc;
            crew.Fromdate = fromDate;
            crew.Todate = toDate;
            crew.CrewSize = crewSize;
            crew.EstHours = estHours;
            crew.EstRate = estRate;
            crew.EstTotal = estTotal;
            crew.EmplineNo = emplineNo;
            
            // Assert
            Assert.AreEqual(updateTime, crew.UpdateTime);
            Assert.IsTrue(crew.IsInsert);
            Assert.IsFalse(crew.IsUpdate);
            Assert.IsFalse(crew.IsDelete);
            Assert.AreEqual(entityNo, crew.Entityno);
            Assert.AreEqual(seqNo, crew.Seqno);
            Assert.AreEqual(jobTypeOld, crew.JobtypeOld);
            Assert.AreEqual(jobTypeNew, crew.JobtypeNew);
            Assert.AreEqual(jobDesc, crew.Jobdesc);
            Assert.AreEqual(fromDate, crew.Fromdate);
            Assert.AreEqual(toDate, crew.Todate);
            Assert.AreEqual(crewSize, crew.CrewSize);
            Assert.AreEqual(estHours, crew.EstHours);
            Assert.AreEqual(estRate, crew.EstRate);
            Assert.AreEqual(estTotal, crew.EstTotal);
            Assert.AreEqual(emplineNo, crew.EmplineNo);
        }
    }
}