using NUnit.Framework;
using ClairTourTiny.Core.Models.ProjectMaintenance;

namespace ClairTourTiny.Tests.Models.ProjectMaintenance
{
    [TestFixture]
    public class ProjectClientAddressModelTests
    {
        [Test]
        public void DefaultValues_ShouldBeInitializedCorrectly()
        {
            var model = new ProjectClientAddressModel();

            Assert.AreEqual(string.Empty, model.CustNo);
            Assert.AreEqual(string.Empty, model.SubNo);
            Assert.AreEqual(string.Empty, model.BillToName);
            Assert.AreEqual(string.Empty, model.Contact);
            Assert.AreEqual(string.Empty, model.Attention);
            Assert.AreEqual(string.Empty, model.Addr1);
            Assert.AreEqual(string.Empty, model.Addr2);
            Assert.IsNull(model.Addr3);
            Assert.AreEqual(string.Empty, model.City);
            Assert.AreEqual(string.Empty, model.State);
            Assert.AreEqual(string.Empty, model.Zip);
            Assert.AreEqual(string.Empty, model.Country);
            Assert.AreEqual(string.Empty, model.Phone);
            Assert.AreEqual(string.Empty, model.Ext);
            Assert.AreEqual(string.Empty, model.Phone1);
            Assert.AreEqual(string.Empty, model.Email);
            Assert.AreEqual(string.Empty, model.Mobile);
        }

        [Test]
        public void Properties_ShouldBeSetAndRetrievedCorrectly()
        {
            var model = new ProjectClientAddressModel();

            model.CustNo = "123";
            model.SubNo = "456";
            model.BillToName = "Test Name";
            model.Contact = "Test Contact";
            model.Attention = "Test Attention";
            model.Addr1 = "Address 1";
            model.Addr2 = "Address 2";
            model.Addr3 = "Address 3";
            model.City = "Test City";
            model.State = "Test State";
            model.Zip = "12345";
            model.Country = "Test Country";
            model.Phone = "123-456-7890";
            model.Ext = "123";
            model.Phone1 = "098-765-4321";
            model.Email = "test@example.com";
            model.Mobile = "555-555-5555";

            Assert.AreEqual("123", model.CustNo);
            Assert.AreEqual("456", model.SubNo);
            Assert.AreEqual("Test Name", model.BillToName);
            Assert.AreEqual("Test Contact", model.Contact);
            Assert.AreEqual("Test Attention", model.Attention);
            Assert.AreEqual("Address 1", model.Addr1);
            Assert.AreEqual("Address 2", model.Addr2);
            Assert.AreEqual("Address 3", model.Addr3);
            Assert.AreEqual("Test City", model.City);
            Assert.AreEqual("Test State", model.State);
            Assert.AreEqual("12345", model.Zip);
            Assert.AreEqual("Test Country", model.Country);
            Assert.AreEqual("123-456-7890", model.Phone);
            Assert.AreEqual("123", model.Ext);
            Assert.AreEqual("098-765-4321", model.Phone1);
            Assert.AreEqual("test@example.com", model.Email);
            Assert.AreEqual("555-555-5555", model.Mobile);
        }
    }
}