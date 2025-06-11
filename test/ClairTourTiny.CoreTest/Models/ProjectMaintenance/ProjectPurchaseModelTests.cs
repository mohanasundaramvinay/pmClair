using System;
using NUnit.Framework;
using ClairTourTiny.Core.Models.ProjectMaintenance;

namespace ClairTourTiny.Tests.Models.ProjectMaintenance
{
    [TestFixture]
    public class ProjectPurchaseModelTests
    {
        [Test]
        public void IdPurchaseOrder_Should_SetAndGetCorrectly()
        {
            var model = new ProjectPurchaseModel();
            model.IdPurchaseOrder = 123;
            Assert.AreEqual(123, model.IdPurchaseOrder);
        }

        [Test]
        public void PONumber_Should_SetAndGetCorrectly()
        {
            var model = new ProjectPurchaseModel();
            model.PONumber = 456;
            Assert.AreEqual(456, model.PONumber);
        }

        [Test]
        public void PODescription_Should_SetAndGetCorrectly()
        {
            var model = new ProjectPurchaseModel();
            model.PODescription = "Test Description";
            Assert.AreEqual("Test Description", model.PODescription);
        }

        [Test]
        public void Company_Should_HaveDefaultEmptyString()
        {
            var model = new ProjectPurchaseModel();
            Assert.AreEqual(string.Empty, model.Company);
        }

        [Test]
        public void EntityNo_Should_SetAndGetCorrectly()
        {
            var model = new ProjectPurchaseModel();
            model.EntityNo = "Entity123";
            Assert.AreEqual("Entity123", model.EntityNo);
        }

        [Test]
        public void RequestedBy_Should_HaveDefaultEmptyString()
        {
            var model = new ProjectPurchaseModel();
            Assert.AreEqual(string.Empty, model.RequestedBy);
        }

        [Test]
        public void DueDate_Should_SetAndGetCorrectly()
        {
            var model = new ProjectPurchaseModel();
            var dueDate = DateTime.Now;
            model.DueDate = dueDate;
            Assert.AreEqual(dueDate, model.DueDate);
        }

        [Test]
        public void Currency_Should_HaveDefaultEmptyString()
        {
            var model = new ProjectPurchaseModel();
            Assert.AreEqual(string.Empty, model.Currency);
        }

        [Test]
        public void TotalAmount_Should_SetAndGetCorrectly()
        {
            var model = new ProjectPurchaseModel();
            model.TotalAmount = 1000.50m;
            Assert.AreEqual(1000.50m, model.TotalAmount);
        }

        [Test]
        public void Purchaser_Should_SetAndGetCorrectly()
        {
            var model = new ProjectPurchaseModel();
            model.Purchaser = "John Doe";
            Assert.AreEqual("John Doe", model.Purchaser);
        }

        [Test]
        public void OrderedDate_Should_SetAndGetCorrectly()
        {
            var model = new ProjectPurchaseModel();
            var orderedDate = DateTime.Now;
            model.OrderedDate = orderedDate;
            Assert.AreEqual(orderedDate, model.OrderedDate);
        }

        [Test]
        public void VendNo_Should_SetAndGetCorrectly()
        {
            var model = new ProjectPurchaseModel();
            model.VendNo = "V123";
            Assert.AreEqual("V123", model.VendNo);
        }

        [Test]
        public void VendSiteNo_Should_SetAndGetCorrectly()
        {
            var model = new ProjectPurchaseModel();
            model.VendSiteNo = "Site456";
            Assert.AreEqual("Site456", model.VendSiteNo);
        }

        [Test]
        public void VendorName_Should_SetAndGetCorrectly()
        {
            var model = new ProjectPurchaseModel();
            model.VendorName = "Vendor ABC";
            Assert.AreEqual("Vendor ABC", model.VendorName);
        }

        [Test]
        public void CreatedBy_Should_HaveDefaultEmptyString()
        {
            var model = new ProjectPurchaseModel();
            Assert.AreEqual(string.Empty, model.CreatedBy);
        }

        [Test]
        public void CreatedDate_Should_SetAndGetCorrectly()
        {
            var model = new ProjectPurchaseModel();
            var createdDate = DateTime.Now;
            model.CreatedDate = createdDate;
            Assert.AreEqual(createdDate, model.CreatedDate);
        }

        [Test]
        public void CanceledBy_Should_SetAndGetCorrectly()
        {
            var model = new ProjectPurchaseModel();
            model.CanceledBy = "Jane Doe";
            Assert.AreEqual("Jane Doe", model.CanceledBy);
        }

        [Test]
        public void CanceledDate_Should_SetAndGetCorrectly()
        {
            var model = new ProjectPurchaseModel();
            var canceledDate = DateTime.Now;
            model.CanceledDate = canceledDate;
            Assert.AreEqual(canceledDate, model.CanceledDate);
        }
    }
}