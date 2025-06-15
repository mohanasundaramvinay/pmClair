using NUnit.Framework;
using ClairTourTiny.Core.Models.ProjectMaintenance;
using System;

namespace ClairTourTiny.Tests
{
    [TestFixture]
    public class ProjectEquipmentModelTests
    {
        [Test]
        public void TestEntitynoProperty()
        {
            // Arrange
            var model = new ProjectEquipmentModel();
            var expected = "Entity123";

            // Act
            model.Entityno = expected;
            var actual = model.Entityno;

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void TestCategoryProperty()
        {
            // Arrange
            var model = new ProjectEquipmentModel();
            var expected = "CategoryA";

            // Act
            model.Category = expected;
            var actual = model.Category;

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void TestSeqnoProperty()
        {
            // Arrange
            var model = new ProjectEquipmentModel();
            var expected = 10;

            // Act
            model.Seqno = expected;
            var actual = model.Seqno;

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void TestPartnoProperty()
        {
            // Arrange
            var model = new ProjectEquipmentModel();
            var expected = "Part123";

            // Act
            model.Partno = expected;
            var actual = model.Partno;

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void TestPartDescriptionProperty()
        {
            // Arrange
            var model = new ProjectEquipmentModel();
            var expected = "Description of part";

            // Act
            model.PartDescription = expected;
            var actual = model.PartDescription;

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void TestQuantityProperty()
        {
            // Arrange
            var model = new ProjectEquipmentModel();
            var expected = 5;

            // Act
            model.Quantity = expected;
            var actual = model.Quantity;

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void TestDayBottleneckProperty()
        {
            // Arrange
            var model = new ProjectEquipmentModel();
            int? expected = 2;

            // Act
            model.DayBottleneck = expected;
            var actual = model.DayBottleneck;

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void TestWeekBottleneckProperty()
        {
            // Arrange
            var model = new ProjectEquipmentModel();
            int? expected = 3;

            // Act
            model.WeekBottleneck = expected;
            var actual = model.WeekBottleneck;

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void TestBottleneckProperty()
        {
            // Arrange
            var model = new ProjectEquipmentModel();
            int? expected = 4;

            // Act
            model.Bottleneck = expected;
            var actual = model.Bottleneck;

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void TestQuantityToSubhireProperty()
        {
            // Arrange
            var model = new ProjectEquipmentModel();
            int? expected = 6;

            // Act
            model.QuantityToSubhire = expected;
            var actual = model.QuantityToSubhire;

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void TestStartDateProperty()
        {
            // Arrange
            var model = new ProjectEquipmentModel();
            var expected = new DateTime(2023, 1, 1);

            // Act
            model.StartDate = expected;
            var actual = model.StartDate;

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void TestEndDateProperty()
        {
            // Arrange
            var model = new ProjectEquipmentModel();
            var expected = new DateTime(2023, 12, 31);

            // Act
            model.EndDate = expected;
            var actual = model.EndDate;

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void TestNotesProperty()
        {
            // Arrange
            var model = new ProjectEquipmentModel();
            var expected = "Some notes";

            // Act
            model.Notes = expected;
            var actual = model.Notes;

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void TestNoteInternalProperty()
        {
            // Arrange
            var model = new ProjectEquipmentModel();
            var expected = "Internal notes";

            // Act
            model.NoteInternal = expected;
            var actual = model.NoteInternal;

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void TestUnitPriceProperty()
        {
            // Arrange
            var model = new ProjectEquipmentModel();
            var expected = 99.99m;

            // Act
            model.UnitPrice = expected;
            var actual = model.UnitPrice;

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void TestMfgNoProperty()
        {
            // Arrange
            var model = new ProjectEquipmentModel();
            var expected = "MFG123";

            // Act
            model.MfgNo = expected;
            var actual = model.MfgNo;

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void TestCheckedOutProperty()
        {
            // Arrange
            var model = new ProjectEquipmentModel();
            var expected = 1;

            // Act
            model.CheckedOut = expected;
            var actual = model.CheckedOut;

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void TestMarkupProperty()
        {
            // Arrange
            var model = new ProjectEquipmentModel();
            var expected = 0.15;

            // Act
            model.Markup = expected;
            var actual = model.Markup;

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void TestPriceLevelValueProperty()
        {
            // Arrange
            var model = new ProjectEquipmentModel();
            double? expected = 1.25;

            // Act
            model.PriceLevelValue = expected;
            var actual = model.PriceLevelValue;

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void TestTotmatcost4Property()
        {
            // Arrange
            var model = new ProjectEquipmentModel();
            var expected = 200.50;

            // Act
            model.Totmatcost4 = expected;
            var actual = model.Totmatcost4;

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void TestMatrixCdProperty()
        {
            // Arrange
            var model = new ProjectEquipmentModel();
            string? expected = "Matrix123";

            // Act
            model.MatrixCd = expected;
            var actual = model.MatrixCd;

            // Assert
            Assert.AreEqual(expected, actual);
        }
    }
}