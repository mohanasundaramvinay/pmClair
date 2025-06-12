using NUnit.Framework;
using System;
namespace ClairTourTiny.Core.Models.ProjectMaintenance.Save.Tests
{
    [TestFixture]
    public class EquipmentTests
    {
        [Test]
        public void Equipment_DefaultValues_ShouldBeSetCorrectly()
        {
            var equipment = new Equipment();
            Assert.AreEqual(default(DateTime), equipment.UpdateTime);
            Assert.IsFalse(equipment.IsInsert);
            Assert.IsFalse(equipment.IsUpdate);
            Assert.IsFalse(equipment.IsDelete);
            Assert.IsNull(equipment.Entityno);
            Assert.IsNull(equipment.PartnoOld);
            Assert.IsNull(equipment.PartnoNew);
            Assert.IsNull(equipment.Seqno);
            Assert.IsNull(equipment.PartDescription);
            Assert.IsNull(equipment.StartDate);
            Assert.IsNull(equipment.EndDate);
            Assert.IsNull(equipment.UnitPrice);
            Assert.IsNull(equipment.Quantity);
            Assert.IsNull(equipment.MfgNo);
            Assert.IsNull(equipment.Notes);
            Assert.IsNull(equipment.Pieces);
            Assert.IsNull(equipment.Markup);
            Assert.IsNull(equipment.QuantityToSubhire);
            Assert.IsNotNull(equipment.NoteInternal);
            Assert.IsNull(equipment.PriceLevelValue);
            Assert.IsNull(equipment.Matrixcd);
        }
        [Test]
        public void Equipment_SetAndGetProperties_ShouldWorkCorrectly()
        {
            var equipment = new Equipment();
            var now = DateTime.Now;
            equipment.UpdateTime = now;
            equipment.IsInsert = true;
            equipment.IsUpdate = true;
            equipment.IsDelete = true;
            equipment.Entityno = "Entity123";
            equipment.PartnoOld = "PartOld";
            equipment.PartnoNew = "PartNew";
            equipment.Seqno = 1;
            equipment.PartDescription = "Description";
            equipment.StartDate = now;
            equipment.EndDate = now.AddDays(1);
            equipment.UnitPrice = 100.50m;
            equipment.Quantity = 10.0;
            equipment.MfgNo = "Mfg123";
            equipment.Notes = "Some notes";
            equipment.Pieces = 5.0;
            equipment.Markup = 1.5;
            equipment.QuantityToSubhire = 2.0;
            equipment.NoteInternal = "Internal note";
            equipment.PriceLevelValue = 3.5;
            equipment.Matrixcd = "Matrix123";
            Assert.AreEqual(now, equipment.UpdateTime);
            Assert.IsTrue(equipment.IsInsert);
            Assert.IsTrue(equipment.IsUpdate);
            Assert.IsTrue(equipment.IsDelete);
            Assert.AreEqual("Entity123", equipment.Entityno);
            Assert.AreEqual("PartOld", equipment.PartnoOld);
            Assert.AreEqual("PartNew", equipment.PartnoNew);
            Assert.AreEqual(1, equipment.Seqno);
            Assert.AreEqual("Description", equipment.PartDescription);
            Assert.AreEqual(now, equipment.StartDate);
            Assert.AreEqual(now.AddDays(1), equipment.EndDate);
            Assert.AreEqual(100.50m, equipment.UnitPrice);
            Assert.AreEqual(10.0, equipment.Quantity);
            Assert.AreEqual("Mfg123", equipment.MfgNo);
            Assert.AreEqual("Some notes", equipment.Notes);
            Assert.AreEqual(5.0, equipment.Pieces);
            Assert.AreEqual(1.5, equipment.Markup);
            Assert.AreEqual(2.0, equipment.QuantityToSubhire);
            Assert.AreEqual("Internal note", equipment.NoteInternal);
            Assert.AreEqual(3.5, equipment.PriceLevelValue);
            Assert.AreEqual("Matrix123", equipment.Matrixcd);
        }
    }
}