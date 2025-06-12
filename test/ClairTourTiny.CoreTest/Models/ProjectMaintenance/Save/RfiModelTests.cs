using System;
using Xunit;
namespace ClairTourTiny.Core.Models.ProjectMaintenance.Save.Tests
{
    public class RfiModelTests
    {
        [Fact]
        public void UpdateTime_Property_SetAndGet()
        {
            var model = new RfiModel();
            var now = DateTime.Now;
            model.UpdateTime = now;
            Assert.Equal(now, model.UpdateTime);
        }
        [Fact]
        public void IsInsert_Property_SetAndGet()
        {
            var model = new RfiModel();
            model.IsInsert = true;
            Assert.True(model.IsInsert);
        }
        [Fact]
        public void IsUpdate_Property_SetAndGet()
        {
            var model = new RfiModel();
            model.IsUpdate = true;
            Assert.True(model.IsUpdate);
        }
        [Fact]
        public void IsDelete_Property_SetAndGet()
        {
            var model = new RfiModel();
            model.IsDelete = true;
            Assert.True(model.IsDelete);
        }
        [Fact]
        public void Entityno_Property_SetAndGet()
        {
            var model = new RfiModel();
            var entityNo = "Entity123";
            model.Entityno = entityNo;
            Assert.Equal(entityNo, model.Entityno);
        }
        [Fact]
        public void Seqno_Property_SetAndGet()
        {
            var model = new RfiModel();
            var seqNo = 123;
            model.Seqno = seqNo;
            Assert.Equal(seqNo, model.Seqno);
        }
        [Fact]
        public void InvEntityno_Property_SetAndGet()
        {
            var model = new RfiModel();
            var invEntityNo = "InvEntity123";
            model.InvEntityno = invEntityNo;
            Assert.Equal(invEntityNo, model.InvEntityno);
        }
        [Fact]
        public void Description_Property_SetAndGet()
        {
            var model = new RfiModel();
            var description = "Test Description";
            model.Description = description;
            Assert.Equal(description, model.Description);
        }
        [Fact]
        public void Startdate_Property_SetAndGet()
        {
            var model = new RfiModel();
            var startDate = DateTime.Now;
            model.Startdate = startDate;
            Assert.Equal(startDate, model.Startdate);
        }
        [Fact]
        public void Enddate_Property_SetAndGet()
        {
            var model = new RfiModel();
            var endDate = DateTime.Now;
            model.Enddate = endDate;
            Assert.Equal(endDate, model.Enddate);
        }
        [Fact]
        public void Rate_Property_SetAndGet()
        {
            var model = new RfiModel();
            var rate = 99.99m;
            model.Rate = rate;
            Assert.Equal(rate, model.Rate);
        }
        [Fact]
        public void Ratetype_Property_SetAndGet()
        {
            var model = new RfiModel();
            var rateType = "Hourly";
            model.Ratetype = rateType;
            Assert.Equal(rateType, model.Ratetype);
        }
        [Fact]
        public void Note_Property_SetAndGet()
        {
            var model = new RfiModel();
            var note = "This is a note.";
            model.Note = note;
            Assert.Equal(note, model.Note);
        }
        [Fact]
        public void AeApproved_Property_SetAndGet()
        {
            var model = new RfiModel();
            var aeApproved = "Yes";
            model.AeApproved = aeApproved;
            Assert.Equal(aeApproved, model.AeApproved);
        }
        [Fact]
        public void AmApproved_Property_SetAndGet()
        {
            var model = new RfiModel();
            var amApproved = "No";
            model.AmApproved = amApproved;
            Assert.Equal(amApproved, model.AmApproved);
        }
        [Fact]
        public void Billschedule_Property_SetAndGet()
        {
            var model = new RfiModel();
            var billSchedule = "Monthly";
            model.Billschedule = billSchedule;
            Assert.Equal(billSchedule, model.Billschedule);
        }
        [Fact]
        public void Acctcd_Property_SetAndGet()
        {
            var model = new RfiModel();
            var acctCd = "ACC123";
            model.Acctcd = acctCd;
            Assert.Equal(acctCd, model.Acctcd);
        }
        [Fact]
        public void Numdays_Property_SetAndGet()
        {
            var model = new RfiModel();
            var numDays = 30;
            model.Numdays = numDays;
            Assert.Equal(numDays, model.Numdays);
        }
        [Fact]
        public void RevenueCompany_Property_SetAndGet()
        {
            var model = new RfiModel();
            var revenueCompany = "CompanyX";
            model.RevenueCompany = revenueCompany;
            Assert.Equal(revenueCompany, model.RevenueCompany);
        }
        [Fact]
        public void Total_Property_SetAndGet()
        {
            var model = new RfiModel();
            var total = 1000.50;
            model.Total = total;
            Assert.Equal(total, model.Total);
        }
        [Fact]
        public void IsManualAdjustment_Property_SetAndGet()
        {
            var model = new RfiModel();
            model.IsManualAdjustment = true;
            Assert.True(model.IsManualAdjustment);
        }
    }
}