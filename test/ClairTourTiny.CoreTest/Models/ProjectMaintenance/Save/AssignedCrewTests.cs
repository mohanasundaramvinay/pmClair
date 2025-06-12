using System;
using NUnit.Framework;
namespace ClairTourTiny.Core.Models.ProjectMaintenance.Save.Tests
{
    [TestFixture]
    public class AssignedCrewTests
    {
        [Test]
        public void AssignedCrew_DefaultValues_ShouldBeSetCorrectly()
        {
            var assignedCrew = new AssignedCrew();
            Assert.AreEqual(default(DateTime), assignedCrew.UpdateTime);
            Assert.IsFalse(assignedCrew.IsInsert);
            Assert.IsFalse(assignedCrew.IsUpdate);
            Assert.IsFalse(assignedCrew.IsDelete);
            Assert.IsNotNull(assignedCrew.Entityno);
            Assert.IsNotNull(assignedCrew.Jobtype);
            Assert.IsNotNull(assignedCrew.EmpnoOld);
            Assert.IsNotNull(assignedCrew.EmpnoNew);
            Assert.AreEqual(default(DateTime), assignedCrew.FromdateOld);
            Assert.AreEqual(default(DateTime), assignedCrew.FromdateNew);
            Assert.AreEqual(default(DateTime), assignedCrew.Todate);
            Assert.AreEqual(0.0, assignedCrew.EstHours);
            Assert.AreEqual(0, assignedCrew.EmplineNo);
            Assert.IsNull(assignedCrew.StatusCode);
            Assert.IsNull(assignedCrew.RfiEntityno);
            Assert.IsNull(assignedCrew.RfiSeqno);
            Assert.IsNull(assignedCrew.PdRfiEntityno);
            Assert.IsNull(assignedCrew.PdRfiSeqno);
            Assert.IsNull(assignedCrew.Ponumber);
            Assert.IsNull(assignedCrew.PayingPerDiemStatusCode);
            Assert.IsNull(assignedCrew.IsPerDiemBillableStatusCode);
            Assert.IsNull(assignedCrew.Note);
            Assert.IsNull(assignedCrew.PerDiemRate);
            Assert.IsNull(assignedCrew.SubInvoiceNumber);
            Assert.IsNull(assignedCrew.SubInvoiceDate);
        }
        [Test]
        public void AssignedCrew_SetAndGetProperties_ShouldWorkCorrectly()
        {
            var assignedCrew = new AssignedCrew();
            var now = DateTime.Now;
            assignedCrew.UpdateTime = now;
            assignedCrew.IsInsert = true;
            assignedCrew.IsUpdate = true;
            assignedCrew.IsDelete = true;
            assignedCrew.Entityno = "Entity123";
            assignedCrew.Jobtype = "JobTypeA";
            assignedCrew.EmpnoOld = "EmpOld123";
            assignedCrew.EmpnoNew = "EmpNew123";
            assignedCrew.FromdateOld = now.AddDays(-1);
            assignedCrew.FromdateNew = now;
            assignedCrew.Todate = now.AddDays(1);
            assignedCrew.EstHours = 8.5;
            assignedCrew.EmplineNo = 42;
            assignedCrew.StatusCode = "Active";
            assignedCrew.RfiEntityno = "Rfi123";
            assignedCrew.RfiSeqno = 1;
            assignedCrew.PdRfiEntityno = "PdRfi123";
            assignedCrew.PdRfiSeqno = 2;
            assignedCrew.Ponumber = 123456;
            assignedCrew.PayingPerDiemStatusCode = "Yes";
            assignedCrew.IsPerDiemBillableStatusCode = "No";
            assignedCrew.Note = "Test note";
            assignedCrew.PerDiemRate = 150.75;
            assignedCrew.SubInvoiceNumber = "SubInv123";
            assignedCrew.SubInvoiceDate = now;
            Assert.AreEqual(now, assignedCrew.UpdateTime);
            Assert.IsTrue(assignedCrew.IsInsert);
            Assert.IsTrue(assignedCrew.IsUpdate);
            Assert.IsTrue(assignedCrew.IsDelete);
            Assert.AreEqual("Entity123", assignedCrew.Entityno);
            Assert.AreEqual("JobTypeA", assignedCrew.Jobtype);
            Assert.AreEqual("EmpOld123", assignedCrew.EmpnoOld);
            Assert.AreEqual("EmpNew123", assignedCrew.EmpnoNew);
            Assert.AreEqual(now.AddDays(-1), assignedCrew.FromdateOld);
            Assert.AreEqual(now, assignedCrew.FromdateNew);
            Assert.AreEqual(now.AddDays(1), assignedCrew.Todate);
            Assert.AreEqual(8.5, assignedCrew.EstHours);
            Assert.AreEqual(42, assignedCrew.EmplineNo);
            Assert.AreEqual("Active", assignedCrew.StatusCode);
            Assert.AreEqual("Rfi123", assignedCrew.RfiEntityno);
            Assert.AreEqual(1, assignedCrew.RfiSeqno);
            Assert.AreEqual("PdRfi123", assignedCrew.PdRfiEntityno);
            Assert.AreEqual(2, assignedCrew.PdRfiSeqno);
            Assert.AreEqual(123456, assignedCrew.Ponumber);
            Assert.AreEqual("Yes", assignedCrew.PayingPerDiemStatusCode);
            Assert.AreEqual("No", assignedCrew.IsPerDiemBillableStatusCode);
            Assert.AreEqual("Test note", assignedCrew.Note);
            Assert.AreEqual(150.75, assignedCrew.PerDiemRate);
            Assert.AreEqual("SubInv123", assignedCrew.SubInvoiceNumber);
            Assert.AreEqual(now, assignedCrew.SubInvoiceDate);
        }
    }
}