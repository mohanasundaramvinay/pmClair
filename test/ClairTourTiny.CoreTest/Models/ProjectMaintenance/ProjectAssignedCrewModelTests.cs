using System;
using System.Collections.Generic;
using NUnit.Framework;
using ClairTourTiny.Core.Models.ProjectMaintenance;

namespace ClairTourTiny.Tests.Models.ProjectMaintenance
{
    [TestFixture]
    public class ProjectAssignedCrewModelTests
    {
        [Test]
        public void TestEntityNoProperty()
        {
            var model = new ProjectAssignedCrewModel();
            model.EntityNo = "12345";
            Assert.AreEqual("12345", model.EntityNo);
        }

        [Test]
        public void TestEmpNoProperty()
        {
            var model = new ProjectAssignedCrewModel();
            model.EmpNo = "E123";
            Assert.AreEqual("E123", model.EmpNo);
        }

        [Test]
        public void TestJobTypeProperty()
        {
            var model = new ProjectAssignedCrewModel();
            model.JobType = "Engineer";
            Assert.AreEqual("Engineer", model.JobType);
        }

        [Test]
        public void TestFromDateProperty()
        {
            var model = new ProjectAssignedCrewModel();
            var date = DateTime.Now;
            model.FromDate = date;
            Assert.AreEqual(date, model.FromDate);
        }

        [Test]
        public void TestToDateProperty()
        {
            var model = new ProjectAssignedCrewModel();
            var date = DateTime.Now;
            model.ToDate = date;
            Assert.AreEqual(date, model.ToDate);
        }

        [Test]
        public void TestEstHoursProperty()
        {
            var model = new ProjectAssignedCrewModel();
            model.EstHours = 40.5;
            Assert.AreEqual(40.5, model.EstHours);
        }

        [Test]
        public void TestEmpLineNoProperty()
        {
            var model = new ProjectAssignedCrewModel();
            model.EmpLineNo = 10;
            Assert.AreEqual(10, model.EmpLineNo);
        }

        [Test]
        public void TestStatusCodeProperty()
        {
            var model = new ProjectAssignedCrewModel();
            model.StatusCode = "Active";
            Assert.AreEqual("Active", model.StatusCode);
        }

        [Test]
        public void TestNullableProperties()
        {
            var model = new ProjectAssignedCrewModel();
            model.RfiEntityNo = null;
            model.RfiSeqNo = null;
            model.PdRfiEntityNo = null;
            model.PdRfiSeqNo = null;
            model.PONumber = null;
            model.PayingPerDiemStatusCode = null;
            model.IsPerDiemBillableStatusCode = null;
            model.Note = null;
            model.PerDiemRate = null;
            model.SubInvoiceNumber = null;
            model.SubInvoiceDate = null;
            model.AssignedCrewOt = null;
            Assert.IsNull(model.RfiEntityNo);
            Assert.IsNull(model.RfiSeqNo);
            Assert.IsNull(model.PdRfiEntityNo);
            Assert.IsNull(model.PdRfiSeqNo);
            Assert.IsNull(model.PONumber);
            Assert.IsNull(model.PayingPerDiemStatusCode);
            Assert.IsNull(model.IsPerDiemBillableStatusCode);
            Assert.IsNull(model.Note);
            Assert.IsNull(model.PerDiemRate);
            Assert.IsNull(model.SubInvoiceNumber);
            Assert.IsNull(model.SubInvoiceDate);
            Assert.IsNull(model.AssignedCrewOt);
        }
    }
}