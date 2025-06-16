using Microsoft.VisualStudio.TestTools.UnitTesting;
using ClairTourTiny.Core.Models.ProjectMaintenance;

namespace ClairTourTiny.Tests
{
    [TestClass]
    public class OperationalExpenseTotalsTests
    {
        [TestMethod]
        public void TestOperationalExpenseTotalsFields()
        {
            // Arrange
            var expenseTotals = new OperationalExpenseTotals();
            double expectedEquipmentWeekly = 1000.0;
            double expectedCrewWeekly = 2000.0;

            // Act
            expenseTotals.EquipmentWeekly = expectedEquipmentWeekly;
            expenseTotals.CrewWeekly = expectedCrewWeekly;

            // Assert
            Assert.AreEqual(expectedEquipmentWeekly, expenseTotals.EquipmentWeekly, "EquipmentWeekly field did not return the expected value.");
            Assert.AreEqual(expectedCrewWeekly, expenseTotals.CrewWeekly, "CrewWeekly field did not return the expected value.");
        }
    }
}