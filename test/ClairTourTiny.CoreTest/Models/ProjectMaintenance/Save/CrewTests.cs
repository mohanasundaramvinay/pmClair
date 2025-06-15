using NUnit.Framework;
using System;
using ClairTourTiny.Core.Models.ProjectMaintenance.Save;

namespace ClairTourTiny.Tests
{
    [TestFixture]
    public class CrewTests
    {
        [Test]
        public void TestUpdateTimeProperty()
        {
            var crew = new Crew();
            var now = DateTime.Now;
            crew.UpdateTime = now;
            Assert.AreEqual(now, crew.UpdateTime);
        }

        [Test]
        public void TestIsInsertProperty()
        {
            var crew = new Crew();
            crew.IsInsert = true;
            Assert.IsTrue(crew.IsInsert);
        }

        [Test]
        public void TestIsUpdateProperty()
        {
            var crew = new Crew();
            crew.IsUpdate = true;
            Assert.IsTrue(crew.IsUpdate);
        }

        [Test]
        public void TestIsDeleteProperty()
        {
            var crew = new Crew();
            crew.IsDelete = true;
            Assert.IsTrue(crew.IsDelete);
        }

        [Test]
        public void TestEntitynoProperty()
        {
            var crew = new Crew();
            var entityNo = "Entity123";
            crew.Entityno = entityNo;
            Assert.AreEqual(entityNo, crew.Entityno);
        }

        [Test]
        public void TestSeqnoProperty()
        {
            var crew = new Crew();
            var seqNo = 123;
            crew.Seqno = seqNo;
            Assert.AreEqual(seqNo, crew.Seqno);
        }

        [Test]
        public void TestJobtypeOldProperty()
        {
            var crew = new Crew();
            var jobTypeOld = "OldJob";
            crew.JobtypeOld = jobTypeOld;
            Assert.AreEqual(jobTypeOld, crew.JobtypeOld);
        }

        [Test]
        public void TestJobtypeNewProperty()
        {
            var crew = new Crew();
            var jobTypeNew = "NewJob";
            crew.JobtypeNew = jobTypeNew;
            Assert.AreEqual(jobTypeNew, crew.JobtypeNew);
        }

        [Test]
        public void TestJobdescProperty()
        {
            var crew = new Crew();
            var jobDesc = "Job Description";
            crew.Jobdesc = jobDesc;
            Assert.AreEqual(jobDesc, crew.Jobdesc);
        }

        [Test]
        public void TestFromdateProperty()
        {
            var crew = new Crew();
            var fromDate = DateTime.Now;
            crew.Fromdate = fromDate;
            Assert.AreEqual(fromDate, crew.Fromdate);
        }

        [Test]
        public void TestTodateProperty()
        {
            var crew = new Crew();
            var toDate = DateTime.Now.AddDays(1);
            crew.Todate = toDate;
            Assert.AreEqual(toDate, crew.Todate);
        }

        [Test]
        public void TestCrewSizeProperty()
        {
            var crew = new Crew();
            var crewSize = 10;
            crew.CrewSize = crewSize;
            Assert.AreEqual(crewSize, crew.CrewSize);
        }

        [Test]
        public void TestEstHoursProperty()
        {
            var crew = new Crew();
            var estHours = 40.5;
            crew.EstHours = estHours;
            Assert.AreEqual(estHours, crew.EstHours);
        }

        [Test]
        public void TestEstRateProperty()
        {
            var crew = new Crew();
            var estRate = 25.75;
            crew.EstRate = estRate;
            Assert.AreEqual(estRate, crew.EstRate);
        }

        [Test]
        public void TestEstTotalProperty()
        {
            var crew = new Crew();
            var estTotal = 1000.50m;
            crew.EstTotal = estTotal;
            Assert.AreEqual(estTotal, crew.EstTotal);
        }

        [Test]
        public void TestEmplineNoProperty()
        {
            var crew = new Crew();
            var emplineNo = 456;
            crew.EmplineNo = emplineNo;
            Assert.AreEqual(emplineNo, crew.EmplineNo);
        }
    }
}