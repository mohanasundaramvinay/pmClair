using System;
using NUnit.Framework;
using ClairTourTiny.Core.Models.ProjectMaintenance.Save;

namespace ClairTourTiny.Tests
{
    [TestFixture]
    public class ProjectBillingItemTests
    {
        [Test]
        public void TestDefaultValues()
        {
            var item = new ProjectBillingItem();
            Assert.AreEqual(default(DateTime), item.UpdateTime);
            Assert.IsFalse(item.IsInsert);
            Assert.IsFalse(item.IsUpdate);
            Assert.IsFalse(item.IsDelete);
            Assert.AreEqual(null, item.BidEntityno);
            Assert.AreEqual(0, item.Itemno);
            Assert.IsNull(item.EquipmentEntityno);
            Assert.IsNull(item.ExpenseEntityno);
            Assert.IsNull(item.ExpenseSeqno);
            Assert.IsNull(item.Jobtype);
            Assert.IsNull(item.JobEmpno);
            Assert.IsNull(item.CrewEntityno);
            Assert.IsNull(item.CrewEmplineNo);
            Assert.AreEqual(0.0, item.NominalDailyRate);
        }

        [Test]
        public void TestSetAndGetProperties()
        {
            var item = new ProjectBillingItem();
            var now = DateTime.Now;
            item.UpdateTime = now;
            item.IsInsert = true;
            item.IsUpdate = true;
            item.IsDelete = true;
            item.BidEntityno = "BID123";
            item.Itemno = 1;
            item.EquipmentEntityno = "EQ123";
            item.ExpenseEntityno = "EXP123";
            item.ExpenseSeqno = 100;
            item.Jobtype = "JobType1";
            item.JobEmpno = "EMP123";
            item.CrewEntityno = "CREW123";
            item.CrewEmplineNo = 10;
            item.NominalDailyRate = 150.0;

            Assert.AreEqual(now, item.UpdateTime);
            Assert.IsTrue(item.IsInsert);
            Assert.IsTrue(item.IsUpdate);
            Assert.IsTrue(item.IsDelete);
            Assert.AreEqual("BID123", item.BidEntityno);
            Assert.AreEqual(1, item.Itemno);
            Assert.AreEqual("EQ123", item.EquipmentEntityno);
            Assert.AreEqual("EXP123", item.ExpenseEntityno);
            Assert.AreEqual(100, item.ExpenseSeqno);
            Assert.AreEqual("JobType1", item.Jobtype);
            Assert.AreEqual("EMP123", item.JobEmpno);
            Assert.AreEqual("CREW123", item.CrewEntityno);
            Assert.AreEqual(10, item.CrewEmplineNo);
            Assert.AreEqual(150.0, item.NominalDailyRate);
        }

        [Test]
        public void TestNullableProperties()
        {
            var item = new ProjectBillingItem();
            item.EquipmentEntityno = null;
            item.ExpenseEntityno = null;
            item.ExpenseSeqno = null;
            item.Jobtype = null;
            item.JobEmpno = null;
            item.CrewEntityno = null;
            item.CrewEmplineNo = null;

            Assert.IsNull(item.EquipmentEntityno);
            Assert.IsNull(item.ExpenseEntityno);
            Assert.IsNull(item.ExpenseSeqno);
            Assert.IsNull(item.Jobtype);
            Assert.IsNull(item.JobEmpno);
            Assert.IsNull(item.CrewEntityno);
            Assert.IsNull(item.CrewEmplineNo);
        }
    }
}