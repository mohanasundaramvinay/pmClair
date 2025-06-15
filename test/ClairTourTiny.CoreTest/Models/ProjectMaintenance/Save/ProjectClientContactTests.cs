using System;
using NUnit.Framework;

namespace ClairTourTiny.Core.Models.ProjectMaintenance.Save.Tests
{
    [TestFixture]
    public class ProjectClientContactTests
    {
        [Test]
        public void UpdateTime_Property_SetAndGet_ShouldReturnCorrectValue()
        {
            var contact = new ProjectClientContact();
            var now = DateTime.Now;
            contact.UpdateTime = now;
            Assert.AreEqual(now, contact.UpdateTime);
        }

        [Test]
        public void IsInsert_Property_SetAndGet_ShouldReturnCorrectValue()
        {
            var contact = new ProjectClientContact();
            contact.IsInsert = true;
            Assert.IsTrue(contact.IsInsert);
        }

        [Test]
        public void IsUpdate_Property_SetAndGet_ShouldReturnCorrectValue()
        {
            var contact = new ProjectClientContact();
            contact.IsUpdate = true;
            Assert.IsTrue(contact.IsUpdate);
        }

        [Test]
        public void IsDelete_Property_SetAndGet_ShouldReturnCorrectValue()
        {
            var contact = new ProjectClientContact();
            contact.IsDelete = true;
            Assert.IsTrue(contact.IsDelete);
        }

        [Test]
        public void Entityno_Property_SetAndGet_ShouldReturnCorrectValue()
        {
            var contact = new ProjectClientContact();
            var entityNo = "Entity123";
            contact.Entityno = entityNo;
            Assert.AreEqual(entityNo, contact.Entityno);
        }

        [Test]
        public void IdContactCategory_Property_SetAndGet_ShouldReturnCorrectValue()
        {
            var contact = new ProjectClientContact();
            var categoryId = 5;
            contact.IdContactCategory = categoryId;
            Assert.AreEqual(categoryId, contact.IdContactCategory);
        }

        [Test]
        public void ContactNo_Property_SetAndGet_ShouldReturnCorrectValue()
        {
            var contact = new ProjectClientContact();
            var contactNo = "Contact456";
            contact.ContactNo = contactNo;
            Assert.AreEqual(contactNo, contact.ContactNo);
        }
    }
}