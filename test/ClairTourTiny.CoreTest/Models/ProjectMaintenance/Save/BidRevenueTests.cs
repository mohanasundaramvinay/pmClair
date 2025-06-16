using System;
using NUnit.Framework;
namespace ClairTourTiny.Core.Models.ProjectMaintenance.Save.Tests
{
    [TestFixture]
    public class BidRevenueTests
    {
        [Test]
        public void UpdateTime_Property_SetAndGet_ShouldReturnExpectedValue()
        {
            var bidRevenue = new BidRevenue();
            var expectedDate = DateTime.Now;
            bidRevenue.UpdateTime = expectedDate;
            Assert.AreEqual(expectedDate, bidRevenue.UpdateTime);
        }

        [Test]
        public void IsInsert_Property_SetAndGet_ShouldReturnExpectedValue()
        {
            var bidRevenue = new BidRevenue();
            bidRevenue.IsInsert = true;
            Assert.IsTrue(bidRevenue.IsInsert);
        }

        [Test]
        public void IsUpdate_Property_SetAndGet_ShouldReturnExpectedValue()
        {
            var bidRevenue = new BidRevenue();
            bidRevenue.IsUpdate = true;
            Assert.IsTrue(bidRevenue.IsUpdate);
        }

        [Test]
        public void IsDelete_Property_SetAndGet_ShouldReturnExpectedValue()
        {
            var bidRevenue = new BidRevenue();
            bidRevenue.IsDelete = true;
            Assert.IsTrue(bidRevenue.IsDelete);
        }

        [Test]
        public void Entityno_Property_SetAndGet_ShouldReturnExpectedValue()
        {
            var bidRevenue = new BidRevenue();
            var expectedEntityno = "Entity123";
            bidRevenue.Entityno = expectedEntityno;
            Assert.AreEqual(expectedEntityno, bidRevenue.Entityno);
        }

        [Test]
        public void Seqno_Property_SetAndGet_ShouldReturnExpectedValue()
        {
            var bidRevenue = new BidRevenue();
            var expectedSeqno = 123;
            bidRevenue.Seqno = expectedSeqno;
            Assert.AreEqual(expectedSeqno, bidRevenue.Seqno);
        }

        [Test]
        public void Notes_Property_SetAndGet_ShouldReturnExpectedValue()
        {
            var bidRevenue = new BidRevenue();
            var expectedNotes = "Some notes";
            bidRevenue.Notes = expectedNotes;
            Assert.AreEqual(expectedNotes, bidRevenue.Notes);
        }

        [Test]
        public void Startdate_Property_SetAndGet_ShouldReturnExpectedValue()
        {
            var bidRevenue = new BidRevenue();
            var expectedStartDate = new DateTime(2023, 1, 1);
            bidRevenue.Startdate = expectedStartDate;
            Assert.AreEqual(expectedStartDate, bidRevenue.Startdate);
        }

        [Test]
        public void Enddate_Property_SetAndGet_ShouldReturnExpectedValue()
        {
            var bidRevenue = new BidRevenue();
            var expectedEndDate = new DateTime(2023, 12, 31);
            bidRevenue.Enddate = expectedEndDate;
            Assert.AreEqual(expectedEndDate, bidRevenue.Enddate);
        }

        [Test]
        public void Amount_Property_SetAndGet_ShouldReturnExpectedValue()
        {
            var bidRevenue = new BidRevenue();
            var expectedAmount = 1000.50;
            bidRevenue.Amount = expectedAmount;
            Assert.AreEqual(expectedAmount, bidRevenue.Amount);
        }
    }
}