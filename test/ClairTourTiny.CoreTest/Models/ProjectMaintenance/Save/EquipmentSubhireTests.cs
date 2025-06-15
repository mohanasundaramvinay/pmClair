using System;
using NUnit.Framework;
namespace ClairTourTiny.Core.Models.ProjectMaintenance.Save.Tests
{
    [TestFixture]
    public class EquipmentSubhireTests
    {
        [Test]
        public void TestUpdateTimeProperty()
        {
            var equipmentSubhire = new EquipmentSubhire();
            var now = DateTime.Now;
            equipmentSubhire.UpdateTime = now;
            Assert.AreEqual(now, equipmentSubhire.UpdateTime);
        }
        [Test]
        public void TestIsInsertProperty()
        {
            var equipmentSubhire = new EquipmentSubhire();
            equipmentSubhire.IsInsert = true;
            Assert.IsTrue(equipmentSubhire.IsInsert);
        }
        [Test]
        public void TestIsUpdateProperty()
        {
            var equipmentSubhire = new EquipmentSubhire();
            equipmentSubhire.IsUpdate = true;
            Assert.IsTrue(equipmentSubhire.IsUpdate);
        }
        [Test]
        public void TestIsDeleteProperty()
        {
            var equipmentSubhire = new EquipmentSubhire();
            equipmentSubhire.IsDelete = true;
            Assert.IsTrue(equipmentSubhire.IsDelete);
        }
        [Test]
        public void TestEntitynoProperty()
        {
            var equipmentSubhire = new EquipmentSubhire();
            var entityNo = "Entity123";
            equipmentSubhire.Entityno = entityNo;
            Assert.AreEqual(entityNo, equipmentSubhire.Entityno);
        }
        [Test]
        public void TestPartnoProperty()
        {
            var equipmentSubhire = new EquipmentSubhire();
            var partNo = "Part456";
            equipmentSubhire.Partno = partNo;
            Assert.AreEqual(partNo, equipmentSubhire.Partno);
        }
        [Test]
        public void TestQuantityProperty()
        {
            var equipmentSubhire = new EquipmentSubhire();
            var quantity = 10;
            equipmentSubhire.Quantity = quantity;
            Assert.AreEqual(quantity, equipmentSubhire.Quantity);
        }
        [Test]
        public void TestVendnoProperty()
        {
            var equipmentSubhire = new EquipmentSubhire();
            var vendNo = "Vendor789";
            equipmentSubhire.Vendno = vendNo;
            Assert.AreEqual(vendNo, equipmentSubhire.Vendno);
            equipmentSubhire.Vendno = null;
            Assert.IsNull(equipmentSubhire.Vendno);
        }
        [Test]
        public void TestSitenoProperty()
        {
            var equipmentSubhire = new EquipmentSubhire();
            var siteNo = "Site012";
            equipmentSubhire.Siteno = siteNo;
            Assert.AreEqual(siteNo, equipmentSubhire.Siteno);
            equipmentSubhire.Siteno = null;
            Assert.IsNull(equipmentSubhire.Siteno);
        }
        [Test]
        public void TestVendorNameProperty()
        {
            var equipmentSubhire = new EquipmentSubhire();
            var vendorName = "VendorName";
            equipmentSubhire.VendorName = vendorName;
            Assert.AreEqual(vendorName, equipmentSubhire.VendorName);
        }
        [Test]
        public void TestPonumberProperty()
        {
            var equipmentSubhire = new EquipmentSubhire();
            var poNumber = "PO12345";
            equipmentSubhire.Ponumber = poNumber;
            Assert.AreEqual(poNumber, equipmentSubhire.Ponumber);
            equipmentSubhire.Ponumber = null;
            Assert.IsNull(equipmentSubhire.Ponumber);
        }
        [Test]
        public void TestRateProperty()
        {
            var equipmentSubhire = new EquipmentSubhire();
            var rate = 100.50;
            equipmentSubhire.Rate = rate;
            Assert.AreEqual(rate, equipmentSubhire.Rate);
        }
        [Test]
        public void TestRateTypeProperty()
        {
            var equipmentSubhire = new EquipmentSubhire();
            var rateType = "Hourly";
            equipmentSubhire.RateType = rateType;
            Assert.AreEqual(rateType, equipmentSubhire.RateType);
        }
        [Test]
        public void TestDeliveryRateProperty()
        {
            var equipmentSubhire = new EquipmentSubhire();
            var deliveryRate = 20.75;
            equipmentSubhire.DeliveryRate = deliveryRate;
            Assert.AreEqual(deliveryRate, equipmentSubhire.DeliveryRate);
        }
        [Test]
        public void TestReturnRateProperty()
        {
            var equipmentSubhire = new EquipmentSubhire();
            var returnRate = 15.25;
            equipmentSubhire.ReturnRate = returnRate;
            Assert.AreEqual(returnRate, equipmentSubhire.ReturnRate);
        }
        [Test]
        public void TestTotalProperty()
        {
            var equipmentSubhire = new EquipmentSubhire();
            var total = 500.00;
            equipmentSubhire.Total = total;
            Assert.AreEqual(total, equipmentSubhire.Total);
        }
        [Test]
        public void TestInvoiceNoProperty()
        {
            var equipmentSubhire = new EquipmentSubhire();
            var invoiceNo = "INV123";
            equipmentSubhire.InvoiceNo = invoiceNo;
            Assert.AreEqual(invoiceNo, equipmentSubhire.InvoiceNo);
            equipmentSubhire.InvoiceNo = null;
            Assert.IsNull(equipmentSubhire.InvoiceNo);
        }
        [Test]
        public void TestStartDateProperty()
        {
            var equipmentSubhire = new EquipmentSubhire();
            var startDate = DateTime.Today;
            equipmentSubhire.StartDate = startDate;
            Assert.AreEqual(startDate, equipmentSubhire.StartDate);
            equipmentSubhire.StartDate = null;
            Assert.IsNull(equipmentSubhire.StartDate);
        }
        [Test]
        public void TestEndDateProperty()
        {
            var equipmentSubhire = new EquipmentSubhire();
            var endDate = DateTime.Today.AddDays(1);
            equipmentSubhire.EndDate = endDate;
            Assert.AreEqual(endDate, equipmentSubhire.EndDate);
            equipmentSubhire.EndDate = null;
            Assert.IsNull(equipmentSubhire.EndDate);
        }
        [Test]
        public void TestLineNoProperty()
        {
            var equipmentSubhire = new EquipmentSubhire();
            var lineNo = 1;
            equipmentSubhire.LineNo = lineNo;
            Assert.AreEqual(lineNo, equipmentSubhire.LineNo);
        }
        [Test]
        public void TestStatusCodeProperty()
        {
            var equipmentSubhire = new EquipmentSubhire();
            var statusCode = "Active";
            equipmentSubhire.StatusCode = statusCode;
            Assert.AreEqual(statusCode, equipmentSubhire.StatusCode);
        }
        [Test]
        public void TestShopReceiptDateProperty()
        {
            var equipmentSubhire = new EquipmentSubhire();
            var shopReceiptDate = new DateOnly(2023, 10, 1);
            equipmentSubhire.ShopReceiptDate = shopReceiptDate;
            Assert.AreEqual(shopReceiptDate, equipmentSubhire.ShopReceiptDate);
        }
        [Test]
        public void TestShopReturnDateProperty()
        {
            var equipmentSubhire = new EquipmentSubhire();
            var shopReturnDate = new DateOnly(2023, 10, 2);
            equipmentSubhire.ShopReturnDate = shopReturnDate;
            Assert.AreEqual(shopReturnDate, equipmentSubhire.ShopReturnDate);
        }
        [Test]
        public void TestBillabledaysProperty()
        {
            var equipmentSubhire = new EquipmentSubhire();
            var billableDays = 5.0;
            equipmentSubhire.Billabledays = billableDays;
            Assert.AreEqual(billableDays, equipmentSubhire.Billabledays);
        }
    }
}