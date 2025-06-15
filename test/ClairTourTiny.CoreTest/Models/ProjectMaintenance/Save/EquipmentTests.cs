using System;
using NUnit.Framework;
using ClairTourTiny.Core.Models.ProjectMaintenance.Save;

namespace ClairTourTiny.Tests.Models.ProjectMaintenance.Save
{
    [TestFixture]
    public class EquipmentTests
    {
        [Test]
        public void Equipment_UpdateTime_CanBeSetAndRetrieved()
        {
            var equipment = new Equipment();
            var updateTime = DateTime.Now;
            equipment.UpdateTime = updateTime;
            Assert.AreEqual(updateTime, equipment.UpdateTime);
        }

        [Test]
        public void Equipment_IsInsert_CanBeSetAndRetrieved()
        {
            var equipment = new Equipment();
            equipment.IsInsert = true;
            Assert.IsTrue(equipment.IsInsert);
        }

        [Test]
        public void Equipment_IsUpdate_CanBeSetAndRetrieved()
        {
            var equipment = new Equipment();
            equipment.IsUpdate = true;
            Assert.IsTrue(equipment.IsUpdate);
        }

        [Test]
        public void Equipment_IsDelete_CanBeSetAndRetrieved()
        {
            var equipment = new Equipment();
            equipment.IsDelete = true;
            Assert.IsTrue(equipment.IsDelete);
        }

        [Test]
        public void Equipment_Entityno_CanBeSetAndRetrieved()
        {
            var equipment = new Equipment();
            var entityno = "Entity123";
            equipment.Entityno = entityno;
            Assert.AreEqual(entityno, equipment.Entityno);
        }

        [Test]
        public void Equipment_PartnoOld_CanBeSetAndRetrieved()
        {
            var equipment = new Equipment();
            var partnoOld = "PartOld123";
            equipment.PartnoOld = partnoOld;
            Assert.AreEqual(partnoOld, equipment.PartnoOld);
        }

        [Test]
        public void Equipment_PartnoNew_CanBeSetAndRetrieved()
        {
            var equipment = new Equipment();
            var partnoNew = "PartNew123";
            equipment.PartnoNew = partnoNew;
            Assert.AreEqual(partnoNew, equipment.PartnoNew);
        }

        [Test]
        public void Equipment_Seqno_CanBeSetAndRetrieved()
        {
            var equipment = new Equipment();
            int? seqno = 123;
            equipment.Seqno = seqno;
            Assert.AreEqual(seqno, equipment.Seqno);
        }

        [Test]
        public void Equipment_PartDescription_CanBeSetAndRetrieved()
        {
            var equipment = new Equipment();
            var partDescription = "Description";
            equipment.PartDescription = partDescription;
            Assert.AreEqual(partDescription, equipment.PartDescription);
        }

        [Test]
        public void Equipment_StartDate_CanBeSetAndRetrieved()
        {
            var equipment = new Equipment();
            DateTime? startDate = DateTime.Now;
            equipment.StartDate = startDate;
            Assert.AreEqual(startDate, equipment.StartDate);
        }

        [Test]
        public void Equipment_EndDate_CanBeSetAndRetrieved()
        {
            var equipment = new Equipment();
            DateTime? endDate = DateTime.Now;
            equipment.EndDate = endDate;
            Assert.AreEqual(endDate, equipment.EndDate);
        }

        [Test]
        public void Equipment_UnitPrice_CanBeSetAndRetrieved()
        {
            var equipment = new Equipment();
            decimal? unitPrice = 99.99m;
            equipment.UnitPrice = unitPrice;
            Assert.AreEqual(unitPrice, equipment.UnitPrice);
        }

        [Test]
        public void Equipment_Quantity_CanBeSetAndRetrieved()
        {
            var equipment = new Equipment();
            double? quantity = 10.5;
            equipment.Quantity = quantity;
            Assert.AreEqual(quantity, equipment.Quantity);
        }

        [Test]
        public void Equipment_MfgNo_CanBeSetAndRetrieved()
        {
            var equipment = new Equipment();
            var mfgNo = "MFG123";
            equipment.MfgNo = mfgNo;
            Assert.AreEqual(mfgNo, equipment.MfgNo);
        }

        [Test]
        public void Equipment_Notes_CanBeSetAndRetrieved()
        {
            var equipment = new Equipment();
            var notes = "Some notes";
            equipment.Notes = notes;
            Assert.AreEqual(notes, equipment.Notes);
        }

        [Test]
        public void Equipment_Pieces_CanBeSetAndRetrieved()
        {
            var equipment = new Equipment();
            double? pieces = 5.0;
            equipment.Pieces = pieces;
            Assert.AreEqual(pieces, equipment.Pieces);
        }

        [Test]
        public void Equipment_Markup_CanBeSetAndRetrieved()
        {
            var equipment = new Equipment();
            double? markup = 1.2;
            equipment.Markup = markup;
            Assert.AreEqual(markup, equipment.Markup);
        }

        [Test]
        public void Equipment_QuantityToSubhire_CanBeSetAndRetrieved()
        {
            var equipment = new Equipment();
            double? quantityToSubhire = 3.5;
            equipment.QuantityToSubhire = quantityToSubhire;
            Assert.AreEqual(quantityToSubhire, equipment.QuantityToSubhire);
        }

        [Test]
        public void Equipment_NoteInternal_CanBeSetAndRetrieved()
        {
            var equipment = new Equipment();
            var noteInternal = "Internal note";
            equipment.NoteInternal = noteInternal;
            Assert.AreEqual(noteInternal, equipment.NoteInternal);
        }

        [Test]
        public void Equipment_PriceLevelValue_CanBeSetAndRetrieved()
        {
            var equipment = new Equipment();
            double? priceLevelValue = 2.5;
            equipment.PriceLevelValue = priceLevelValue;
            Assert.AreEqual(priceLevelValue, equipment.PriceLevelValue);
        }

        [Test]
        public void Equipment_Matrixcd_CanBeSetAndRetrieved()
        {
            var equipment = new Equipment();
            var matrixcd = "Matrix123";
            equipment.Matrixcd = matrixcd;
            Assert.AreEqual(matrixcd, equipment.Matrixcd);
        }
    }
}