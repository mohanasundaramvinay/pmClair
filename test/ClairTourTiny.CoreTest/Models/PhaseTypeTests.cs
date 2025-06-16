using System;
using NUnit.Framework;
using ClairTourTiny.Core.Models;

namespace ClairTourTiny.Tests
{
    [TestFixture]
    public class PhaseTypeTests
    {
        [Test]
        public void PhaseType_ShouldContain_AllDefinedValues()
        {
            // Check that all enum values are defined
            Assert.IsTrue(Enum.IsDefined(typeof(PhaseType), PhaseType.AssignedCrew));
            Assert.IsTrue(Enum.IsDefined(typeof(PhaseType), PhaseType.BidExpenses));
            Assert.IsTrue(Enum.IsDefined(typeof(PhaseType), PhaseType.BidRevenue));
            Assert.IsTrue(Enum.IsDefined(typeof(PhaseType), PhaseType.Crew));
            Assert.IsTrue(Enum.IsDefined(typeof(PhaseType), PhaseType.Equipment));
            Assert.IsTrue(Enum.IsDefined(typeof(PhaseType), PhaseType.EquipmentSubhires));
            Assert.IsTrue(Enum.IsDefined(typeof(PhaseType), PhaseType.FavoriteProjects));
            Assert.IsTrue(Enum.IsDefined(typeof(PhaseType), PhaseType.ProjectBillingItems));
            Assert.IsTrue(Enum.IsDefined(typeof(PhaseType), PhaseType.ProjectBillingPeriodItems));
            Assert.IsTrue(Enum.IsDefined(typeof(PhaseType), PhaseType.ProjectBillingPeriods));
            Assert.IsTrue(Enum.IsDefined(typeof(PhaseType), PhaseType.ProjectClientContacts));
            Assert.IsTrue(Enum.IsDefined(typeof(PhaseType), PhaseType.ProjectEmployeeOvertimeRates));
            Assert.IsTrue(Enum.IsDefined(typeof(PhaseType), PhaseType.ProjectNotes));
            Assert.IsTrue(Enum.IsDefined(typeof(PhaseType), PhaseType.ProjectProductionSchedule));
            Assert.IsTrue(Enum.IsDefined(typeof(PhaseType), PhaseType.Projects));
            Assert.IsTrue(Enum.IsDefined(typeof(PhaseType), PhaseType.RFIs));
        }

        [Test]
        public void PhaseType_ShouldConvert_ToAndFromInt()
        {
            // Check conversion to int and back
            foreach (PhaseType phase in Enum.GetValues(typeof(PhaseType)))
            {
                int intValue = (int)phase;
                PhaseType convertedPhase = (PhaseType)intValue;
                Assert.AreEqual(phase, convertedPhase);
            }
        }

        [Test]
        public void PhaseType_ShouldParse_FromString()
        {
            // Check parsing from string
            foreach (string name in Enum.GetNames(typeof(PhaseType)))
            {
                PhaseType parsedPhase;
                bool success = Enum.TryParse(name, out parsedPhase);
                Assert.IsTrue(success);
                Assert.IsTrue(Enum.IsDefined(typeof(PhaseType), parsedPhase));
            }
        }
    }
}