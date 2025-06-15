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
            // Arrange
            var model = new ProjectShipmentModel();
            var expectedValue = "Leg123";
            
            // Act
            model.ProjectLegNo = expectedValue;
            var actualValue = model.ProjectLegNo;
            
            // Assert
            Assert.AreEqual(expectedValue, actualValue);
        }

        [Test]
        public void EntityNo_Property_SetAndGet_ShouldReturnCorrectValue()
        {
            // Arrange
            var model = new ProjectShipmentModel();
            var expectedValue = "Entity456";
            
            // Act
            model.EntityNo = expectedValue;
            var actualValue = model.EntityNo;
            
            // Assert
            Assert.AreEqual(expectedValue, actualValue);
        }

        [Test]
        public void EntityDesc_Property_SetAndGet_ShouldReturnCorrectValue()
        {
            // Arrange
            var model = new ProjectShipmentModel();
            var expectedValue = "Description";
            
            // Act
            model.EntityDesc = expectedValue;
            var actualValue = model.EntityDesc;
            
            // Assert
            Assert.AreEqual(expectedValue, actualValue);
        }

        [Test]
        public void ShipDate_Property_SetAndGet_ShouldReturnCorrectValue()
        {
            // Arrange
            var model = new ProjectShipmentModel();
            var expectedValue = new DateTime(2023, 10, 1);
            
            // Act
            model.ShipDate = expectedValue;
            var actualValue = model.ShipDate;
            
            // Assert
            Assert.AreEqual(expectedValue, actualValue);
        }

        [Test]
        public void Destination_Property_SetAndGet_ShouldReturnCorrectValue()
        {
            // Arrange
            var model = new ProjectShipmentModel();
            var expectedValue = "New York";
            
            // Act
            model.Destination = expectedValue;
            var actualValue = model.Destination;
            
            // Assert
            Assert.AreEqual(expectedValue, actualValue);
        }

        [Test]
        public void City_Property_SetAndGet_ShouldReturnCorrectValue()
        {
            // Arrange
            var model = new ProjectShipmentModel();
            var expectedValue = "Los Angeles";
            
            // Act
            model.City = expectedValue;
            var actualValue = model.City;
            
            // Assert
            Assert.AreEqual(expectedValue, actualValue);
        }

        [Test]
        public void State_Property_SetAndGet_ShouldReturnCorrectValue()
        {
            // Arrange
            var model = new ProjectShipmentModel();
            var expectedValue = "CA";
            
            // Act
            model.State = expectedValue;
            var actualValue = model.State;
            
            // Assert
            Assert.AreEqual(expectedValue, actualValue);
        }

        [Test]
        public void TrackingNo_Property_SetAndGet_ShouldReturnCorrectValue()
        {
            // Arrange
            var model = new ProjectShipmentModel();
            var expectedValue = "TRACK123";
            
            // Act
            model.TrackingNo = expectedValue;
            var actualValue = model.TrackingNo;
            
            // Assert
            Assert.AreEqual(expectedValue, actualValue);
        }

        [Test]
        public void EstimatedCost_Property_SetAndGet_ShouldReturnCorrectValue()
        {
            // Arrange
            var model = new ProjectShipmentModel();
            var expectedValue = 100.50m;
            
            // Act
            model.EstimatedCost = expectedValue;
            var actualValue = model.EstimatedCost;
            
            // Assert
            Assert.AreEqual(expectedValue, actualValue);
        }

        [Test]
        public void Cost_Property_SetAndGet_ShouldReturnCorrectValue()
        {
            // Arrange
            var model = new ProjectShipmentModel();
            var expectedValue = 200.75m;
            
            // Act
            model.Cost = expectedValue;
            var actualValue = model.Cost;
            
            // Assert
            Assert.AreEqual(expectedValue, actualValue);
        }

        [Test]
        public void ShippingRequestID_Property_SetAndGet_ShouldReturnCorrectValue()
        {
            // Arrange
            var model = new ProjectShipmentModel();
            var expectedValue = 12345;
            
            // Act
            model.ShippingRequestID = expectedValue;
            var actualValue = model.ShippingRequestID;
            
            // Assert
            Assert.AreEqual(expectedValue, actualValue);
        }

        [Test]
        public void ServiceType_Property_SetAndGet_ShouldReturnCorrectValue()
        {
            // Arrange
            var model = new ProjectShipmentModel();
            var expectedValue = "Express";
            
            // Act
            model.ServiceType = expectedValue;
            var actualValue = model.ServiceType;
            
            // Assert
            Assert.AreEqual(expectedValue, actualValue);
        }
    }
}