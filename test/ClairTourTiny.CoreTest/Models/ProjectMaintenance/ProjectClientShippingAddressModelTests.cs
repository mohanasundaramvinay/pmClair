using NUnit.Framework;
namespace ClairTourTiny.Core.Models.ProjectMaintenance.Tests
{
    [TestFixture]
    public class ProjectClientShippingAddressModelTests
    {
        [Test]
        public void CustNo_ShouldBeSetAndRetrievedCorrectly()
        {
            var model = new ProjectClientShippingAddressModel();
            model.CustNo = "12345";
            Assert.AreEqual("12345", model.CustNo);
        }

        [Test]
        public void SubNo_ShouldBeSetAndRetrievedCorrectly()
        {
            var model = new ProjectClientShippingAddressModel();
            model.SubNo = "67890";
            Assert.AreEqual("67890", model.SubNo);
        }

        [Test]
        public void ShipNo_ShouldBeSetAndRetrievedCorrectly()
        {
            var model = new ProjectClientShippingAddressModel();
            model.ShipNo = "54321";
            Assert.AreEqual("54321", model.ShipNo);
        }

        [Test]
        public void ShipToName_ShouldBeSetAndRetrievedCorrectly()
        {
            var model = new ProjectClientShippingAddressModel();
            model.ShipToName = "John Doe";
            Assert.AreEqual("John Doe", model.ShipToName);
        }

        [Test]
        public void Contact_ShouldBeSetAndRetrievedCorrectly()
        {
            var model = new ProjectClientShippingAddressModel();
            model.Contact = "Jane Doe";
            Assert.AreEqual("Jane Doe", model.Contact);
        }

        [Test]
        public void Attention_ShouldBeSetAndRetrievedCorrectly()
        {
            var model = new ProjectClientShippingAddressModel();
            model.Attention = "Attention";
            Assert.AreEqual("Attention", model.Attention);
        }

        [Test]
        public void Addr1_ShouldBeSetAndRetrievedCorrectly()
        {
            var model = new ProjectClientShippingAddressModel();
            model.Addr1 = "123 Main St";
            Assert.AreEqual("123 Main St", model.Addr1);
        }

        [Test]
        public void Addr2_ShouldBeSetAndRetrievedCorrectly()
        {
            var model = new ProjectClientShippingAddressModel();
            model.Addr2 = "Suite 100";
            Assert.AreEqual("Suite 100", model.Addr2);
        }

        [Test]
        public void Addr3_ShouldBeSetAndRetrievedCorrectly()
        {
            var model = new ProjectClientShippingAddressModel();
            model.Addr3 = "Building 5";
            Assert.AreEqual("Building 5", model.Addr3);
        }

        [Test]
        public void City_ShouldBeSetAndRetrievedCorrectly()
        {
            var model = new ProjectClientShippingAddressModel();
            model.City = "Metropolis";
            Assert.AreEqual("Metropolis", model.City);
        }

        [Test]
        public void State_ShouldBeSetAndRetrievedCorrectly()
        {
            var model = new ProjectClientShippingAddressModel();
            model.State = "NY";
            Assert.AreEqual("NY", model.State);
        }

        [Test]
        public void Zip_ShouldBeSetAndRetrievedCorrectly()
        {
            var model = new ProjectClientShippingAddressModel();
            model.Zip = "12345";
            Assert.AreEqual("12345", model.Zip);
        }

        [Test]
        public void Country_ShouldBeSetAndRetrievedCorrectly()
        {
            var model = new ProjectClientShippingAddressModel();
            model.Country = "USA";
            Assert.AreEqual("USA", model.Country);
        }

        [Test]
        public void Phone_ShouldBeSetAndRetrievedCorrectly()
        {
            var model = new ProjectClientShippingAddressModel();
            model.Phone = "555-1234";
            Assert.AreEqual("555-1234", model.Phone);
        }

        [Test]
        public void Ext_ShouldBeSetAndRetrievedCorrectly()
        {
            var model = new ProjectClientShippingAddressModel();
            model.Ext = "101";
            Assert.AreEqual("101", model.Ext);
        }

        [Test]
        public void Email_ShouldBeSetAndRetrievedCorrectly()
        {
            var model = new ProjectClientShippingAddressModel();
            model.Email = "test@example.com";
            Assert.AreEqual("test@example.com", model.Email);
        }

        [Test]
        public void Mobile_ShouldBeSetAndRetrievedCorrectly()
        {
            var model = new ProjectClientShippingAddressModel();
            model.Mobile = "555-6789";
            Assert.AreEqual("555-6789", model.Mobile);
        }

        [Test]
        public void DefaultValues_ShouldBeCorrect()
        {
            var model = new ProjectClientShippingAddressModel();
            Assert.AreEqual(string.Empty, model.CustNo);
            Assert.AreEqual(string.Empty, model.SubNo);
            Assert.AreEqual(string.Empty, model.ShipNo);
            Assert.AreEqual(string.Empty, model.Contact);
            Assert.AreEqual(string.Empty, model.Attention);
            Assert.AreEqual(string.Empty, model.Zip);
            Assert.AreEqual(string.Empty, model.Phone);
            Assert.AreEqual(string.Empty, model.Ext);
            Assert.AreEqual(string.Empty, model.Email);
            Assert.AreEqual(string.Empty, model.Mobile);
        }
    }
}