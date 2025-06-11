using System;
using NUnit.Framework;
namespace ClairTourTiny.Core.Models.ProjectMaintenance.Save.Tests
{
    [TestFixture]
    public class ProjectClientContactTests
    {
        [Test]
        public void Entityno_ShouldNotBeNullByDefault()
        {
            var contact = new ProjectClientContact();
            Assert.IsNotNull(contact.Entityno);
        }

        [Test]
        public void ContactNo_ShouldNotBeNullByDefault()
        {
            var contact = new ProjectClientContact();
            Assert.IsNotNull(contact.ContactNo);
        }

        [Test]
        public void IsInsert_ShouldBeFalseByDefault()
        {
            var contact = new ProjectClientContact();
            Assert.IsFalse(contact.IsInsert);
        }

        [Test]
        public void IsUpdate_ShouldBeFalseByDefault()
        {
            var contact = new ProjectClientContact();
            Assert.IsFalse(contact.IsUpdate);
        }

        [Test]
        public void IsDelete_ShouldBeFalseByDefault()
        {
            var contact = new ProjectClientContact();
            Assert.IsFalse(contact.IsDelete);
        }

        [Test]
        public void UpdateTime_ShouldBeSettable()
        {
            var contact = new ProjectClientContact();
            var now = DateTime.Now;
            contact.UpdateTime = now;
            Assert.AreEqual(now, contact.UpdateTime);
        }

        [Test]
        public void IdContactCategory_ShouldBeSettable()
        {
            var contact = new ProjectClientContact();
            contact.IdContactCategory = 5;
            Assert.AreEqual(5, contact.IdContactCategory);
        }
    }
}