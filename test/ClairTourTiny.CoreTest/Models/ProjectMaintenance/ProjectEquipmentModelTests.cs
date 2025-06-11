using System;
using Xunit;
using ClairTourTiny.Core.Models.ProjectMaintenance;
namespace ClairTourTiny.Tests
{
    public class ProjectEquipmentModelTests
    {
        [Fact]
        public void Entityno_Should_BeSetAndRetrievedCorrectly()
        {
            var model = new ProjectEquipmentModel();
            var expected = "Entity123";
            model.Entityno = expected;
            Assert.Equal(expected, model.Entityno);
        }
        [Fact]
        public void Category_Should_BeSetAndRetrievedCorrectly()
        {
            var model = new ProjectEquipmentModel();
            var expected = "CategoryA";
            model.Category = expected;
            Assert.Equal(expected, model.Category);
        }
        [Fact]
        public void Seqno_Should_BeSetAndRetrievedCorrectly()
        {
            var model = new ProjectEquipmentModel();
            var expected = 1;
            model.Seqno = expected;
            Assert.Equal(expected, model.Seqno);
        }
        [Fact]
        public void Partno_Should_BeSetAndRetrievedCorrectly()
        {
            var model = new ProjectEquipmentModel();
            var expected = "Part123";
            model.Partno = expected;
            Assert.Equal(expected, model.Partno);
        }
        [Fact]
        public void PartDescription_Should_BeSetAndRetrievedCorrectly()
        {
            var model = new ProjectEquipmentModel();
            var expected = "Description of Part";
            model.PartDescription = expected;
            Assert.Equal(expected, model.PartDescription);
        }
        [Fact]
        public void Quantity_Should_BeSetAndRetrievedCorrectly()
        {
            var model = new ProjectEquipmentModel();
            var expected = 10;
            model.Quantity = expected;
            Assert.Equal(expected, model.Quantity);
        }
        [Fact]
        public void DayBottleneck_Should_BeSetAndRetrievedCorrectly()
        {
            var model = new ProjectEquipmentModel();
            int? expected = 5;
            model.DayBottleneck = expected;
            Assert.Equal(expected, model.DayBottleneck);
        }
        [Fact]
        public void WeekBottleneck_Should_BeSetAndRetrievedCorrectly()
        {
            var model = new ProjectEquipmentModel();
            int? expected = 7;
            model.WeekBottleneck = expected;
            Assert.Equal(expected, model.WeekBottleneck);
        }
        [Fact]
        public void Bottleneck_Should_BeSetAndRetrievedCorrectly()
        {
            var model = new ProjectEquipmentModel();
            int? expected = 3;
            model.Bottleneck = expected;
            Assert.Equal(expected, model.Bottleneck);
        }
        [Fact]
        public void QuantityToSubhire_Should_BeSetAndRetrievedCorrectly()
        {
            var model = new ProjectEquipmentModel();
            int? expected = 2;
            model.QuantityToSubhire = expected;
            Assert.Equal(expected, model.QuantityToSubhire);
        }
        [Fact]
        public void StartDate_Should_BeSetAndRetrievedCorrectly()
        {
            var model = new ProjectEquipmentModel();
            var expected = new DateTime(2023, 1, 1);
            model.StartDate = expected;
            Assert.Equal(expected, model.StartDate);
        }
        [Fact]
        public void EndDate_Should_BeSetAndRetrievedCorrectly()
        {
            var model = new ProjectEquipmentModel();
            var expected = new DateTime(2023, 12, 31);
            model.EndDate = expected;
            Assert.Equal(expected, model.EndDate);
        }
        [Fact]
        public void Notes_Should_BeSetAndRetrievedCorrectly()
        {
            var model = new ProjectEquipmentModel();
            var expected = "Some notes";
            model.Notes = expected;
            Assert.Equal(expected, model.Notes);
        }
        [Fact]
        public void NoteInternal_Should_BeSetAndRetrievedCorrectly()
        {
            var model = new ProjectEquipmentModel();
            var expected = "Internal notes";
            model.NoteInternal = expected;
            Assert.Equal(expected, model.NoteInternal);
        }
        [Fact]
        public void UnitPrice_Should_BeSetAndRetrievedCorrectly()
        {
            var model = new ProjectEquipmentModel();
            decimal expected = 99.99m;
            model.UnitPrice = expected;
            Assert.Equal(expected, model.UnitPrice);
        }
        [Fact]
        public void MfgNo_Should_BeSetAndRetrievedCorrectly()
        {
            var model = new ProjectEquipmentModel();
            var expected = "MFG123";
            model.MfgNo = expected;
            Assert.Equal(expected, model.MfgNo);
        }
        [Fact]
        public void CheckedOut_Should_BeSetAndRetrievedCorrectly()
        {
            var model = new ProjectEquipmentModel();
            var expected = 1;
            model.CheckedOut = expected;
            Assert.Equal(expected, model.CheckedOut);
        }
        [Fact]
        public void Markup_Should_BeSetAndRetrievedCorrectly()
        {
            var model = new ProjectEquipmentModel();
            double expected = 0.15;
            model.Markup = expected;
            Assert.Equal(expected, model.Markup);
        }
        [Fact]
        public void PriceLevelValue_Should_BeSetAndRetrievedCorrectly()
        {
            var model = new ProjectEquipmentModel();
            double? expected = 1.25;
            model.PriceLevelValue = expected;
            Assert.Equal(expected, model.PriceLevelValue);
        }
        [Fact]
        public void Totmatcost4_Should_BeSetAndRetrievedCorrectly()
        {
            var model = new ProjectEquipmentModel();
            double expected = 200.50;
            model.Totmatcost4 = expected;
            Assert.Equal(expected, model.Totmatcost4);
        }
        [Fact]
        public void MatrixCd_Should_BeSetAndRetrievedCorrectly()
        {
            var model = new ProjectEquipmentModel();
            var expected = "Matrix123";
            model.MatrixCd = expected;
            Assert.Equal(expected, model.MatrixCd);
        }
    }
}