using System;
using NUnit.Framework;
using ClairTourTiny.Core.Models.ProjectMaintenance.Save;

namespace ClairTourTiny.Tests.Models.ProjectMaintenance.Save
{
    [TestFixture]
    public class BidRevenueTests
    {
        [Test]
        public void UpdateTime_Property_SetAndGet_ShouldReturnCorrectValue()
        {
            // Arrange
            var bidRevenue = new BidRevenue();
            var expectedDate = new DateTime(2023, 10, 1);
            
            // Act
            bidRevenue.UpdateTime = expectedDate;
            var actualDate = bidRevenue.UpdateTime;
            
            // Assert
            Assert.AreEqual(expectedDate, actualDate);
        }

        [Test]
        public void IsInsert_Property_SetAndGet_ShouldReturnCorrectValue()
        {
            // Arrange
            var bidRevenue = new BidRevenue();
            var expectedValue = true;
            
            // Act
            bidRevenue.IsInsert = expectedValue;
            var actualValue = bidRevenue.IsInsert;
            
            // Assert
            Assert.AreEqual(expectedValue, actualValue);
        }

        [Test]
        public void IsUpdate_Property_SetAndGet_ShouldReturnCorrectValue()
        {
            // Arrange
            var bidRevenue = new BidRevenue();
            var expectedValue = true;
            
            // Act
            bidRevenue.IsUpdate = expectedValue;
            var actualValue = bidRevenue.IsUpdate;
            
            // Assert
            Assert.AreEqual(expectedValue, actualValue);
        }

        [Test]
        public void IsDelete_Property_SetAndGet_ShouldReturnCorrectValue()
        {
            // Arrange
            var bidRevenue = new BidRevenue();
            var expectedValue = true;
            
            // Act
            bidRevenue.IsDelete = expectedValue;
            var actualValue = bidRevenue.IsDelete;
            
            // Assert
            Assert.AreEqual(expectedValue, actualValue);
        }

        [Test]
        public void Entityno_Property_SetAndGet_ShouldReturnCorrectValue()
        {
            // Arrange
            var bidRevenue = new BidRevenue();
            var expectedValue = "Entity123";
            
            // Act
            bidRevenue.Entityno = expectedValue;
            var actualValue = bidRevenue.Entityno;
            
            // Assert
            Assert.AreEqual(expectedValue, actualValue);
        }

        [Test]
        public void Seqno_Property_SetAndGet_ShouldReturnCorrectValue()
        {
            // Arrange
            var bidRevenue = new BidRevenue();
            var expectedValue = 123;
            
            // Act
            bidRevenue.Seqno = expectedValue;
            var actualValue = bidRevenue.Seqno;
            
            // Assert
            Assert.AreEqual(expectedValue, actualValue);
        }

        [Test]
        public void Notes_Property_SetAndGet_ShouldReturnCorrectValue()
        {
            // Arrange
            var bidRevenue = new BidRevenue();
            var expectedValue = "Some notes";
            
            // Act
            bidRevenue.Notes = expectedValue;
            var actualValue = bidRevenue.Notes;
            
            // Assert
            Assert.AreEqual(expectedValue, actualValue);
        }

        [Test]
        public void Startdate_Property_SetAndGet_ShouldReturnCorrectValue()
        {
            // Arrange
            var bidRevenue = new BidRevenue();
            var expectedDate = new DateTime(2023, 1, 1);
            
            // Act
            bidRevenue.Startdate = expectedDate;
            var actualDate = bidRevenue.Startdate;
            
            // Assert
            Assert.AreEqual(expectedDate, actualDate);
        }

        [Test]
        public void Enddate_Property_SetAndGet_ShouldReturnCorrectValue()
        {
            // Arrange
            var bidRevenue = new BidRevenue();
            var expectedDate = new DateTime(2023, 12, 31);
            
            // Act
            bidRevenue.Enddate = expectedDate;
            var actualDate = bidRevenue.Enddate;
            
            // Assert
            Assert.AreEqual(expectedDate, actualDate);
        }

        [Test]
        public void Amount_Property_SetAndGet_ShouldReturnCorrectValue()
        {
            // Arrange
            var bidRevenue = new BidRevenue();
            var expectedValue = 1000.50;
            
            // Act
            bidRevenue.Amount = expectedValue;
            var actualValue = bidRevenue.Amount;
            
            // Assert
            Assert.AreEqual(expectedValue, actualValue);
        }
    }
}