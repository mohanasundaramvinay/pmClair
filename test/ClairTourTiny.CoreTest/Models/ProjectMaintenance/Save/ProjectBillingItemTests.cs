using System;
using NUnit.Framework;
namespace ClairTourTiny.Core.Models.ProjectMaintenance.Save.Tests
{
    [TestFixture]
    public class ProjectBillingItemTests
    {
        [Test]
        public void TestDefaultValues()
        {
            var item = new ProjectBillingItem();
            Assert.AreEqual(null, item.BidEntityno);
            Assert.AreEqual(0, item.NominalDailyRate);
        }
        [Test]
        public void TestSetAndGetProperties()
        {
            var item = new ProjectBillingItem();
            var now = DateTime.Now;
            item.UpdateTime = now;
            Assert.AreEqual(now, item.UpdateTime);
            item.IsInsert = true;
            Assert.IsTrue(item.IsInsert);
            item.IsUpdate = true;
            Assert.IsTrue(item.IsUpdate);
            item.IsDelete = true;
            Assert.IsTrue(item.IsDelete);
            item.BidEntityno = "BID123";
            Assert.AreEqual("BID123", item.BidEntityno);
            item.Itemno = 5;
            Assert.AreEqual(5, item.Itemno);
            item.EquipmentEntityno = "EQ123";
            Assert.AreEqual("EQ123", item.EquipmentEntityno);
            item.ExpenseEntityno = "EXP123";
            Assert.AreEqual("EXP123", item.ExpenseEntityno);
            item.ExpenseSeqno = 10;
            Assert.AreEqual(10, item.ExpenseSeqno);
            item.Jobtype = "TypeA";
            Assert.AreEqual("TypeA", item.Jobtype);
            item.JobEmpno = "EMP123";
            Assert.AreEqual("EMP123", item.JobEmpno);
            item.CrewEntityno = "CREW123";
            Assert.AreEqual("CREW123", item.CrewEntityno);
            item.CrewEmplineNo = 20;
            Assert.AreEqual(20, item.CrewEmplineNo);
            item.NominalDailyRate = 100.50;
            Assert.AreEqual(100.50, item.NominalDailyRate);
        }
        [Test]
        public void TestNullableProperties()
        {
            var item = new ProjectBillingItem();
            item.EquipmentEntityno = null;
            Assert.IsNull(item.EquipmentEntityno);
            item.ExpenseEntityno = null;
            Assert.IsNull(item.ExpenseEntityno);
            item.Jobtype = null;
            Assert.IsNull(item.Jobtype);
            item.JobEmpno = null;
            Assert.IsNull(item.JobEmpno);
            item.CrewEntityno = null;
            Assert.IsNull(item.CrewEntityno);
            item.ExpenseSeqno = null;
            Assert.IsNull(item.ExpenseSeqno);
            item.CrewEmplineNo = null;
            Assert.IsNull(item.CrewEmplineNo);
        }
    }
}