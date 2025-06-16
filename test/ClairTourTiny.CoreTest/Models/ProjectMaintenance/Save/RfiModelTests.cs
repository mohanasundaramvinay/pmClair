using NUnit.Framework;
using System;
namespace ClairTourTiny.Core.Models.ProjectMaintenance.Save.Tests
{
    [TestFixture]
    public class RfiModelTests
    {
        [Test]
        public void UpdateTime_Property_SetAndGet_ShouldReturnExpectedValue()
        {
            var model = new RfiModel();
            var expected = DateTime.Now;
            model.UpdateTime = expected;
            Assert.AreEqual(expected, model.UpdateTime);
        }

        [Test]
        public void IsInsert_Property_SetAndGet_ShouldReturnExpectedValue()
        {
            var model = new RfiModel();
            var expected = true;
            model.IsInsert = expected;
            Assert.AreEqual(expected, model.IsInsert);
        }

        [Test]
        public void IsUpdate_Property_SetAndGet_ShouldReturnExpectedValue()
        {
            var model = new RfiModel();
            var expected = true;
            model.IsUpdate = expected;
            Assert.AreEqual(expected, model.IsUpdate);
        }

        [Test]
        public void IsDelete_Property_SetAndGet_ShouldReturnExpectedValue()
        {
            var model = new RfiModel();
            var expected = true;
            model.IsDelete = expected;
            Assert.AreEqual(expected, model.IsDelete);
        }

        [Test]
        public void Entityno_Property_SetAndGet_ShouldReturnExpectedValue()
        {
            var model = new RfiModel();
            var expected = "Entity123";
            model.Entityno = expected;
            Assert.AreEqual(expected, model.Entityno);
        }

        [Test]
        public void Seqno_Property_SetAndGet_ShouldReturnExpectedValue()
        {
            var model = new RfiModel();
            var expected = 123;
            model.Seqno = expected;
            Assert.AreEqual(expected, model.Seqno);
        }

        [Test]
        public void InvEntityno_Property_SetAndGet_ShouldReturnExpectedValue()
        {
            var model = new RfiModel();
            var expected = "InvEntity123";
            model.InvEntityno = expected;
            Assert.AreEqual(expected, model.InvEntityno);
        }

        [Test]
        public void Description_Property_SetAndGet_ShouldReturnExpectedValue()
        {
            var model = new RfiModel();
            var expected = "Description";
            model.Description = expected;
            Assert.AreEqual(expected, model.Description);
        }

        [Test]
        public void Startdate_Property_SetAndGet_ShouldReturnExpectedValue()
        {
            var model = new RfiModel();
            var expected = DateTime.Now;
            model.Startdate = expected;
            Assert.AreEqual(expected, model.Startdate);
        }

        [Test]
        public void Enddate_Property_SetAndGet_ShouldReturnExpectedValue()
        {
            var model = new RfiModel();
            var expected = DateTime.Now;
            model.Enddate = expected;
            Assert.AreEqual(expected, model.Enddate);
        }

        [Test]
        public void Rate_Property_SetAndGet_ShouldReturnExpectedValue()
        {
            var model = new RfiModel();
            var expected = 123.45m;
            model.Rate = expected;
            Assert.AreEqual(expected, model.Rate);
        }

        [Test]
        public void Ratetype_Property_SetAndGet_ShouldReturnExpectedValue()
        {
            var model = new RfiModel();
            var expected = "RateType";
            model.Ratetype = expected;
            Assert.AreEqual(expected, model.Ratetype);
        }

        [Test]
        public void Note_Property_SetAndGet_ShouldReturnExpectedValue()
        {
            var model = new RfiModel();
            var expected = "Note";
            model.Note = expected;
            Assert.AreEqual(expected, model.Note);
        }

        [Test]
        public void AeApproved_Property_SetAndGet_ShouldReturnExpectedValue()
        {
            var model = new RfiModel();
            var expected = "Approved";
            model.AeApproved = expected;
            Assert.AreEqual(expected, model.AeApproved);
        }

        [Test]
        public void AmApproved_Property_SetAndGet_ShouldReturnExpectedValue()
        {
            var model = new RfiModel();
            var expected = "Approved";
            model.AmApproved = expected;
            Assert.AreEqual(expected, model.AmApproved);
        }

        [Test]
        public void Billschedule_Property_SetAndGet_ShouldReturnExpectedValue()
        {
            var model = new RfiModel();
            var expected = "Schedule";
            model.Billschedule = expected;
            Assert.AreEqual(expected, model.Billschedule);
        }

        [Test]
        public void Acctcd_Property_SetAndGet_ShouldReturnExpectedValue()
        {
            var model = new RfiModel();
            var expected = "AcctCode";
            model.Acctcd = expected;
            Assert.AreEqual(expected, model.Acctcd);
        }

        [Test]
        public void Numdays_Property_SetAndGet_ShouldReturnExpectedValue()
        {
            var model = new RfiModel();
            var expected = 10;
            model.Numdays = expected;
            Assert.AreEqual(expected, model.Numdays);
        }

        [Test]
        public void RevenueCompany_Property_SetAndGet_ShouldReturnExpectedValue()
        {
            var model = new RfiModel();
            var expected = "Company";
            model.RevenueCompany = expected;
            Assert.AreEqual(expected, model.RevenueCompany);
        }

        [Test]
        public void Total_Property_SetAndGet_ShouldReturnExpectedValue()
        {
            var model = new RfiModel();
            var expected = 1234.56;
            model.Total = expected;
            Assert.AreEqual(expected, model.Total);
        }

        [Test]
        public void IsManualAdjustment_Property_SetAndGet_ShouldReturnExpectedValue()
        {
            var model = new RfiModel();
            var expected = true;
            model.IsManualAdjustment = expected;
            Assert.AreEqual(expected, model.IsManualAdjustment);
        }
    }
}