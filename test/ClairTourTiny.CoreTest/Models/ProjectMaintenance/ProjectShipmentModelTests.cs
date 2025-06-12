using NUnit.Framework;
using ClairTourTiny.Core.Models.ProjectMaintenance;
using System;

namespace ClairTourTiny.Tests.Models.ProjectMaintenance
{
    [TestFixture]
    public class ProjectShipmentModelTests
    {
        [Test]
        public void ProjectLegNo_Property_SetAndGet_ShouldReturnCorrectValue()
        {
            var model = new ProjectShipmentModel();
            model.ProjectLegNo = "PL123";
            Assert.AreEqual("PL123", model.ProjectLegNo);
        }

        [Test]
        public void EntityNo_Property_SetAndGet_ShouldReturnCorrectValue()
        {
            var model = new ProjectShipmentModel();
            model.EntityNo = "EN456";
            Assert.AreEqual("EN456", model.EntityNo);
        }

        [Test]
        public void EntityDesc_Property_SetAndGet_ShouldReturnCorrectValue()
        {
            var model = new ProjectShipmentModel();
            model.EntityDesc = "Description";
            Assert.AreEqual("Description", model.EntityDesc);
        }

        [Test]
        public void ShipDate_Property_SetAndGet_ShouldReturnCorrectValue()
        {
            var model = new ProjectShipmentModel();
            var date = DateTime.Now;
            model.ShipDate = date;
            Assert.AreEqual(date, model.ShipDate);
        }

        [Test]
        public void Destination_Property_SetAndGet_ShouldReturnCorrectValue()
        {
            var model = new ProjectShipmentModel();
            model.Destination = "Destination";
            Assert.AreEqual("Destination", model.Destination);
        }

        [Test]
        public void City_Property_SetAndGet_ShouldReturnCorrectValue()
        {
            var model = new ProjectShipmentModel();
            model.City = "CityName";
            Assert.AreEqual("CityName", model.City);
        }

        [Test]
        public void State_Property_SetAndGet_ShouldReturnCorrectValue()
        {
            var model = new ProjectShipmentModel();
            model.State = "StateName";
            Assert.AreEqual("StateName", model.State);
        }

        [Test]
        public void TrackingNo_Property_SetAndGet_ShouldReturnCorrectValue()
        {
            var model = new ProjectShipmentModel();
            model.TrackingNo = "TN789";
            Assert.AreEqual("TN789", model.TrackingNo);
        }

        [Test]
        public void EstimatedCost_Property_SetAndGet_ShouldReturnCorrectValue()
        {
            var model = new ProjectShipmentModel();
            model.EstimatedCost = 100.50m;
            Assert.AreEqual(100.50m, model.EstimatedCost);
        }

        [Test]
        public void Cost_Property_SetAndGet_ShouldReturnCorrectValue()
        {
            var model = new ProjectShipmentModel();
            model.Cost = 200.75m;
            Assert.AreEqual(200.75m, model.Cost);
        }

        [Test]
        public void ShippingRequestID_Property_SetAndGet_ShouldReturnCorrectValue()
        {
            var model = new ProjectShipmentModel();
            model.ShippingRequestID = 12345;
            Assert.AreEqual(12345, model.ShippingRequestID);
        }

        [Test]
        public void ServiceType_Property_SetAndGet_ShouldReturnCorrectValue()
        {
            var model = new ProjectShipmentModel();
            model.ServiceType = "Express";
            Assert.AreEqual("Express", model.ServiceType);
        }
    }
}