using System;
using NUnit.Framework;
using ClairTourTiny.Core.Models.ProjectMaintenance.Save;

namespace ClairTourTiny.Tests.Models.ProjectMaintenance.Save
{
    [TestFixture]
    public class ProjectProductionScheduleTests
    {
        [Test]
        public void Test_UpdateTime_Property()
        {
            var schedule = new ProjectProductionSchedule();
            var now = DateTime.Now;
            schedule.UpdateTime = now;
            Assert.AreEqual(now, schedule.UpdateTime);
        }

        [Test]
        public void Test_IsInsert_Property()
        {
            var schedule = new ProjectProductionSchedule();
            schedule.IsInsert = true;
            Assert.IsTrue(schedule.IsInsert);
        }

        [Test]
        public void Test_IsUpdate_Property()
        {
            var schedule = new ProjectProductionSchedule();
            schedule.IsUpdate = true;
            Assert.IsTrue(schedule.IsUpdate);
        }

        [Test]
        public void Test_IsDelete_Property()
        {
            var schedule = new ProjectProductionSchedule();
            schedule.IsDelete = true;
            Assert.IsTrue(schedule.IsDelete);
        }

        [Test]
        public void Test_Entityno_Property()
        {
            var schedule = new ProjectProductionSchedule();
            var entityNo = "Entity123";
            schedule.Entityno = entityNo;
            Assert.AreEqual(entityNo, schedule.Entityno);
        }

        [Test]
        public void Test_EventType_Property()
        {
            var schedule = new ProjectProductionSchedule();
            var eventType = "EventType1";
            schedule.EventType = eventType;
            Assert.AreEqual(eventType, schedule.EventType);
        }

        [Test]
        public void Test_EndDate_Property()
        {
            var schedule = new ProjectProductionSchedule();
            DateTime? endDate = DateTime.Now.AddDays(1);
            schedule.EndDate = endDate;
            Assert.AreEqual(endDate, schedule.EndDate);
        }

        [Test]
        public void Test_VenueId_Property()
        {
            var schedule = new ProjectProductionSchedule();
            int? venueId = 123;
            schedule.VenueId = venueId;
            Assert.AreEqual(venueId, schedule.VenueId);
        }

        [Test]
        public void Test_DestinationDetail_Property()
        {
            var schedule = new ProjectProductionSchedule();
            string? destinationDetail = "Destination A";
            schedule.DestinationDetail = destinationDetail;
            Assert.AreEqual(destinationDetail, schedule.DestinationDetail);
        }

        [Test]
        public void Test_Note_Property()
        {
            var schedule = new ProjectProductionSchedule();
            string? note = "This is a note.";
            schedule.Note = note;
            Assert.AreEqual(note, schedule.Note);
        }

        [Test]
        public void Test_StartDateOld_Property()
        {
            var schedule = new ProjectProductionSchedule();
            var startDateOld = DateTime.Now.AddDays(-1);
            schedule.StartDateOld = startDateOld;
            Assert.AreEqual(startDateOld, schedule.StartDateOld);
        }

        [Test]
        public void Test_StartDateNew_Property()
        {
            var schedule = new ProjectProductionSchedule();
            var startDateNew = DateTime.Now;
            schedule.StartDateNew = startDateNew;
            Assert.AreEqual(startDateNew, schedule.StartDateNew);
        }

        [Test]
        public void Test_StartDate_Property()
        {
            var schedule = new ProjectProductionSchedule();
            DateTime? startDate = DateTime.Now.AddDays(2);
            schedule.StartDate = startDate;
            Assert.AreEqual(startDate, schedule.StartDate);
        }
    }
}