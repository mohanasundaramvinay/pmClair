using NUnit.Framework;
using System;
namespace ClairTourTiny.Core.Models.ProjectMaintenance.Save.Tests
{
    [TestFixture]
    public class EquipmentSubhireTests
    {
        [Test]
        public void TestProperties()
        {
            var equipmentSubhire = new EquipmentSubhire();
            
            // Test DateTime properties
            var updateTime = DateTime.Now;
            equipmentSubhire.UpdateTime = updateTime;
            Assert.AreEqual(updateTime, equipmentSubhire.UpdateTime);
            
            // Test boolean properties
            equipmentSubhire.IsInsert = true;
            Assert.IsTrue(equipmentSubhire.IsInsert);
            equipmentSubhire.IsUpdate = true;
            Assert.IsTrue(equipmentSubhire.IsUpdate);
            equipmentSubhire.IsDelete = true;
            Assert.IsTrue(equipmentSubhire.IsDelete);
            
            // Test string properties
            equipmentSubhire.Entityno = "Entity123";
            Assert.AreEqual("Entity123", equipmentSubhire.Entityno);
            equipmentSubhire.Partno = "Part456";
            Assert.AreEqual("Part456", equipmentSubhire.Partno);
            equipmentSubhire.VendorName = "VendorName";
            Assert.AreEqual("VendorName", equipmentSubhire.VendorName);
            equipmentSubhire.RateType = "Hourly";
            Assert.AreEqual("Hourly", equipmentSubhire.RateType);
            equipmentSubhire.StatusCode = "Active";
            Assert.AreEqual("Active", equipmentSubhire.StatusCode);
            
            // Test nullable string properties
            equipmentSubhire.Vendno = "Vend789";
            Assert.AreEqual("Vend789", equipmentSubhire.Vendno);
            equipmentSubhire.Siteno = "Site012";
            Assert.AreEqual("Site012", equipmentSubhire.Siteno);
            equipmentSubhire.Ponumber = "PO345";
            Assert.AreEqual("PO345", equipmentSubhire.Ponumber);
            equipmentSubhire.InvoiceNo = "INV678";
            Assert.AreEqual("INV678", equipmentSubhire.InvoiceNo);
            
            // Test int properties
            equipmentSubhire.Quantity = 10;
            Assert.AreEqual(10, equipmentSubhire.Quantity);
            equipmentSubhire.LineNo = 5;
            Assert.AreEqual(5, equipmentSubhire.LineNo);
            
            // Test double properties
            equipmentSubhire.Rate = 100.50;
            Assert.AreEqual(100.50, equipmentSubhire.Rate);
            equipmentSubhire.DeliveryRate = 20.75;
            Assert.AreEqual(20.75, equipmentSubhire.DeliveryRate);
            equipmentSubhire.ReturnRate = 15.25;
            Assert.AreEqual(15.25, equipmentSubhire.ReturnRate);
            equipmentSubhire.Total = 200.00;
            Assert.AreEqual(200.00, equipmentSubhire.Total);
            equipmentSubhire.Billabledays = 5.5;
            Assert.AreEqual(5.5, equipmentSubhire.Billabledays);
            
            // Test nullable DateTime properties
            var startDate = DateTime.Today;
            equipmentSubhire.StartDate = startDate;
            Assert.AreEqual(startDate, equipmentSubhire.StartDate);
            var endDate = DateTime.Today.AddDays(1);
            equipmentSubhire.EndDate = endDate;
            Assert.AreEqual(endDate, equipmentSubhire.EndDate);
            
            // Test DateOnly properties
            var shopReceiptDate = DateOnly.FromDateTime(DateTime.Today);
            equipmentSubhire.ShopReceiptDate = shopReceiptDate;
            Assert.AreEqual(shopReceiptDate, equipmentSubhire.ShopReceiptDate);
            var shopReturnDate = DateOnly.FromDateTime(DateTime.Today.AddDays(1));
            equipmentSubhire.ShopReturnDate = shopReturnDate;
            Assert.AreEqual(shopReturnDate, equipmentSubhire.ShopReturnDate);
        }
    }
}