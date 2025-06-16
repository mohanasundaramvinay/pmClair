using System;
using NUnit.Framework;
using ClairTourTiny.Core.Models.ProjectMaintenance.Save;

namespace ClairTourTiny.Tests.Models.ProjectMaintenance.Save
{
    [TestFixture]
    public class AssignedCrewTests
    {
        [Test]
        public void TestAssignedCrewProperties()
        {
            var assignedCrew = new AssignedCrew();

            // Test setting and getting DateTime properties
            var updateTime = DateTime.Now;
            assignedCrew.UpdateTime = updateTime;
            Assert.AreEqual(updateTime, assignedCrew.UpdateTime);

            var fromdateOld = new DateTime(2023, 1, 1);
            assignedCrew.FromdateOld = fromdateOld;
            Assert.AreEqual(fromdateOld, assignedCrew.FromdateOld);

            var fromdateNew = new DateTime(2023, 2, 1);
            assignedCrew.FromdateNew = fromdateNew;
            Assert.AreEqual(fromdateNew, assignedCrew.FromdateNew);

            var todate = new DateTime(2023, 3, 1);
            assignedCrew.Todate = todate;
            Assert.AreEqual(todate, assignedCrew.Todate);

            // Test setting and getting boolean properties
            assignedCrew.IsInsert = true;
            Assert.IsTrue(assignedCrew.IsInsert);

            assignedCrew.IsUpdate = false;
            Assert.IsFalse(assignedCrew.IsUpdate);

            assignedCrew.IsDelete = true;
            Assert.IsTrue(assignedCrew.IsDelete);

            // Test setting and getting string properties
            var entityno = "Entity123";
            assignedCrew.Entityno = entityno;
            Assert.AreEqual(entityno, assignedCrew.Entityno);

            var jobtype = "JobTypeA";
            assignedCrew.Jobtype = jobtype;
            Assert.AreEqual(jobtype, assignedCrew.Jobtype);

            var empnoOld = "EmpOld123";
            assignedCrew.EmpnoOld = empnoOld;
            Assert.AreEqual(empnoOld, assignedCrew.EmpnoOld);

            var empnoNew = "EmpNew123";
            assignedCrew.EmpnoNew = empnoNew;
            Assert.AreEqual(empnoNew, assignedCrew.EmpnoNew);

            // Test setting and getting double properties
            var estHours = 40.5;
            assignedCrew.EstHours = estHours;
            Assert.AreEqual(estHours, assignedCrew.EstHours);

            // Test setting and getting int properties
            var emplineNo = 123;
            assignedCrew.EmplineNo = emplineNo;
            Assert.AreEqual(emplineNo, assignedCrew.EmplineNo);

            // Test nullable properties
            assignedCrew.StatusCode = null;
            Assert.IsNull(assignedCrew.StatusCode);
            assignedCrew.StatusCode = "Active";
            Assert.AreEqual("Active", assignedCrew.StatusCode);

            assignedCrew.RfiEntityno = null;
            Assert.IsNull(assignedCrew.RfiEntityno);
            assignedCrew.RfiEntityno = "RFI123";
            Assert.AreEqual("RFI123", assignedCrew.RfiEntityno);

            assignedCrew.RfiSeqno = null;
            Assert.IsNull(assignedCrew.RfiSeqno);
            assignedCrew.RfiSeqno = 456;
            Assert.AreEqual(456, assignedCrew.RfiSeqno);

            assignedCrew.PdRfiEntityno = null;
            Assert.IsNull(assignedCrew.PdRfiEntityno);
            assignedCrew.PdRfiEntityno = "PdRFI123";
            Assert.AreEqual("PdRFI123", assignedCrew.PdRfiEntityno);

            assignedCrew.PdRfiSeqno = null;
            Assert.IsNull(assignedCrew.PdRfiSeqno);
            assignedCrew.PdRfiSeqno = 789;
            Assert.AreEqual(789, assignedCrew.PdRfiSeqno);

            assignedCrew.Ponumber = null;
            Assert.IsNull(assignedCrew.Ponumber);
            assignedCrew.Ponumber = 101112;
            Assert.AreEqual(101112, assignedCrew.Ponumber);

            assignedCrew.PayingPerDiemStatusCode = null;
            Assert.IsNull(assignedCrew.PayingPerDiemStatusCode);
            assignedCrew.PayingPerDiemStatusCode = "Yes";
            Assert.AreEqual("Yes", assignedCrew.PayingPerDiemStatusCode);

            assignedCrew.IsPerDiemBillableStatusCode = null;
            Assert.IsNull(assignedCrew.IsPerDiemBillableStatusCode);
            assignedCrew.IsPerDiemBillableStatusCode = "No";
            Assert.AreEqual("No", assignedCrew.IsPerDiemBillableStatusCode);

            assignedCrew.Note = null;
            Assert.IsNull(assignedCrew.Note);
            assignedCrew.Note = "This is a note.";
            Assert.AreEqual("This is a note.", assignedCrew.Note);

            assignedCrew.PerDiemRate = null;
            Assert.IsNull(assignedCrew.PerDiemRate);
            assignedCrew.PerDiemRate = 150.75;
            Assert.AreEqual(150.75, assignedCrew.PerDiemRate);

            assignedCrew.SubInvoiceNumber = null;
            Assert.IsNull(assignedCrew.SubInvoiceNumber);
            assignedCrew.SubInvoiceNumber = "INV123";
            Assert.AreEqual("INV123", assignedCrew.SubInvoiceNumber);

            assignedCrew.SubInvoiceDate = null;
            Assert.IsNull(assignedCrew.SubInvoiceDate);
            var subInvoiceDate = new DateTime(2023, 4, 1);
            assignedCrew.SubInvoiceDate = subInvoiceDate;
            Assert.AreEqual(subInvoiceDate, assignedCrew.SubInvoiceDate);
        }
    }
}