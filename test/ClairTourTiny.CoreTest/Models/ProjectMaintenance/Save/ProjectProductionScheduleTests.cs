using System;
using Xunit;
namespace ClairTourTiny.Core.Models.ProjectMaintenance.Save.Tests
{
    public class ProjectProductionScheduleTests
    {
        [Fact]
        public void TestDefaultValues()
        {
            var schedule = new ProjectProductionSchedule();
            Assert.NotNull(schedule.Entityno);
            Assert.NotNull(schedule.EventType);
            Assert.Equal(default(DateTime), schedule.UpdateTime);
            Assert.False(schedule.IsInsert);
            Assert.False(schedule.IsUpdate);
            Assert.False(schedule.IsDelete);
            Assert.Null(schedule.EndDate);
            Assert.Null(schedule.VenueId);
            Assert.Null(schedule.DestinationDetail);
            Assert.Null(schedule.Note);
            Assert.Equal(default(DateTime), schedule.StartDateOld);
            Assert.Equal(default(DateTime), schedule.StartDateNew);
            Assert.Null(schedule.StartDate);
        }
        [Fact]
        public void TestPropertyAssignments()
        {
            var schedule = new ProjectProductionSchedule();
            var now = DateTime.Now;
            schedule.UpdateTime = now;
            schedule.IsInsert = true;
            schedule.IsUpdate = true;
            schedule.IsDelete = true;
            schedule.Entityno = "12345";
            schedule.EventType = "EventType1";
            schedule.EndDate = now.AddDays(1);
            schedule.VenueId = 10;
            schedule.DestinationDetail = "Destination";
            schedule.Note = "Note";
            schedule.StartDateOld = now.AddDays(-1);
            schedule.StartDateNew = now;
            schedule.StartDate = now.AddDays(2);
            Assert.Equal(now, schedule.UpdateTime);
            Assert.True(schedule.IsInsert);
            Assert.True(schedule.IsUpdate);
            Assert.True(schedule.IsDelete);
            Assert.Equal("12345", schedule.Entityno);
            Assert.Equal("EventType1", schedule.EventType);
            Assert.Equal(now.AddDays(1), schedule.EndDate);
            Assert.Equal(10, schedule.VenueId);
            Assert.Equal("Destination", schedule.DestinationDetail);
            Assert.Equal("Note", schedule.Note);
            Assert.Equal(now.AddDays(-1), schedule.StartDateOld);
            Assert.Equal(now, schedule.StartDateNew);
            Assert.Equal(now.AddDays(2), schedule.StartDate);
        }
    }
}