using NUnit.Framework;
using ClairTourTiny.Core.Models;

namespace ClairTourTiny.Tests
{
    [TestFixture]
    public class PhaseTypeTests
    {
        [Test]
        public void PhaseType_ShouldContain_AssignedCrew()
        {
            Assert.AreEqual(0, (int)PhaseType.AssignedCrew);
        }

        [Test]
        public void PhaseType_ShouldContain_BidExpenses()
        {
            Assert.AreEqual(1, (int)PhaseType.BidExpenses);
        }

        [Test]
        public void PhaseType_ShouldContain_BidRevenue()
        {
            Assert.AreEqual(2, (int)PhaseType.BidRevenue);
        }

        [Test]
        public void PhaseType_ShouldContain_Crew()
        {
            Assert.AreEqual(3, (int)PhaseType.Crew);
        }

        [Test]
        public void PhaseType_ShouldContain_Equipment()
        {
            Assert.AreEqual(4, (int)PhaseType.Equipment);
        }

        [Test]
        public void PhaseType_ShouldContain_EquipmentSubhires()
        {
            Assert.AreEqual(5, (int)PhaseType.EquipmentSubhires);
        }

        [Test]
        public void PhaseType_ShouldContain_FavoriteProjects()
        {
            Assert.AreEqual(6, (int)PhaseType.FavoriteProjects);
        }

        [Test]
        public void PhaseType_ShouldContain_ProjectBillingItems()
        {
            Assert.AreEqual(7, (int)PhaseType.ProjectBillingItems);
        }

        [Test]
        public void PhaseType_ShouldContain_ProjectBillingPeriodItems()
        {
            Assert.AreEqual(8, (int)PhaseType.ProjectBillingPeriodItems);
        }

        [Test]
        public void PhaseType_ShouldContain_ProjectBillingPeriods()
        {
            Assert.AreEqual(9, (int)PhaseType.ProjectBillingPeriods);
        }

        [Test]
        public void PhaseType_ShouldContain_ProjectClientContacts()
        {
            Assert.AreEqual(10, (int)PhaseType.ProjectClientContacts);
        }

        [Test]
        public void PhaseType_ShouldContain_ProjectEmployeeOvertimeRates()
        {
            Assert.AreEqual(11, (int)PhaseType.ProjectEmployeeOvertimeRates);
        }

        [Test]
        public void PhaseType_ShouldContain_ProjectNotes()
        {
            Assert.AreEqual(12, (int)PhaseType.ProjectNotes);
        }

        [Test]
        public void PhaseType_ShouldContain_ProjectProductionSchedule()
        {
            Assert.AreEqual(13, (int)PhaseType.ProjectProductionSchedule);
        }

        [Test]
        public void PhaseType_ShouldContain_Projects()
        {
            Assert.AreEqual(14, (int)PhaseType.Projects);
        }

        [Test]
        public void PhaseType_ShouldContain_RFIs()
        {
            Assert.AreEqual(15, (int)PhaseType.RFIs);
        }
    }
}