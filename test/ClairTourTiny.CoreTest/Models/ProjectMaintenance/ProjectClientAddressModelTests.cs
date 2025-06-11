using NUnit.Framework;
namespace ClairTourTiny.Core.Models.ProjectMaintenance.Tests
{
    [TestFixture]
    public class ProjectClientAddressModelTests
    {
        [Test]
        public void CustNo_Property_SetAndGet_ShouldReturnCorrectValue()
        {
            var model = new ProjectClientAddressModel();
            var testValue = "12345";
            model.CustNo = testValue;
            Assert.AreEqual(testValue, model.CustNo);
        }
        [Test]
        public void SubNo_Property_SetAndGet_ShouldReturnCorrectValue()
        {
            var model = new ProjectClientAddressModel();
            var testValue = "67890";
            model.SubNo = testValue;
            Assert.AreEqual(testValue, model.SubNo);
        }
        [Test]
        public void BillToName_Property_SetAndGet_ShouldReturnCorrectValue()
        {
            var model = new ProjectClientAddressModel();
            var testValue = "Test Name";
            model.BillToName = testValue;
            Assert.AreEqual(testValue, model.BillToName);
        }
        [Test]
        public void Contact_Property_SetAndGet_ShouldReturnCorrectValue()
        {
            var model = new ProjectClientAddressModel();
            var testValue = "Test Contact";
            model.Contact = testValue;
            Assert.AreEqual(testValue, model.Contact);
        }
        [Test]
        public void Attention_Property_SetAndGet_ShouldReturnCorrectValue()
        {
            var model = new ProjectClientAddressModel();
            var testValue = "Test Attention";
            model.Attention = testValue;
            Assert.AreEqual(testValue, model.Attention);
        }
        [Test]
        public void Addr1_Property_SetAndGet_ShouldReturnCorrectValue()
        {
            var model = new ProjectClientAddressModel();
            var testValue = "Address Line 1";
            model.Addr1 = testValue;
            Assert.AreEqual(testValue, model.Addr1);
        }
        [Test]
        public void Addr2_Property_SetAndGet_ShouldReturnCorrectValue()
        {
            var model = new ProjectClientAddressModel();
            var testValue = "Address Line 2";
            model.Addr2 = testValue;
            Assert.AreEqual(testValue, model.Addr2);
        }
        [Test]
        public void Addr3_Property_SetAndGet_ShouldReturnCorrectValue()
        {
            var model = new ProjectClientAddressModel();
            var testValue = "Address Line 3";
            model.Addr3 = testValue;
            Assert.AreEqual(testValue, model.Addr3);
        }
        [Test]
        public void City_Property_SetAndGet_ShouldReturnCorrectValue()
        {
            var model = new ProjectClientAddressModel();
            var testValue = "Test City";
            model.City = testValue;
            Assert.AreEqual(testValue, model.City);
        }
        [Test]
        public void State_Property_SetAndGet_ShouldReturnCorrectValue()
        {
            var model = new ProjectClientAddressModel();
            var testValue = "Test State";
            model.State = testValue;
            Assert.AreEqual(testValue, model.State);
        }
        [Test]
        public void Zip_Property_SetAndGet_ShouldReturnCorrectValue()
        {
            var model = new ProjectClientAddressModel();
            var testValue = "123456";
            model.Zip = testValue;
            Assert.AreEqual(testValue, model.Zip);
        }
        [Test]
        public void Country_Property_SetAndGet_ShouldReturnCorrectValue()
        {
            var model = new ProjectClientAddressModel();
            var testValue = "Test Country";
            model.Country = testValue;
            Assert.AreEqual(testValue, model.Country);
        }
        [Test]
        public void Phone_Property_SetAndGet_ShouldReturnCorrectValue()
        {
            var model = new ProjectClientAddressModel();
            var testValue = "123-456-7890";
            model.Phone = testValue;
            Assert.AreEqual(testValue, model.Phone);
        }
        [Test]
        public void Ext_Property_SetAndGet_ShouldReturnCorrectValue()
        {
            var model = new ProjectClientAddressModel();
            var testValue = "123";
            model.Ext = testValue;
            Assert.AreEqual(testValue, model.Ext);
        }
        [Test]
        public void Phone1_Property_SetAndGet_ShouldReturnCorrectValue()
        {
            var model = new ProjectClientAddressModel();
            var testValue = "098-765-4321";
            model.Phone1 = testValue;
            Assert.AreEqual(testValue, model.Phone1);
        }
        [Test]
        public void Email_Property_SetAndGet_ShouldReturnCorrectValue()
        {
            var model = new ProjectClientAddressModel();
            var testValue = "test@example.com";
            model.Email = testValue;
            Assert.AreEqual(testValue, model.Email);
        }
        [Test]
        public void Mobile_Property_SetAndGet_ShouldReturnCorrectValue()
        {
            var model = new ProjectClientAddressModel();
            var testValue = "987-654-3210";
            model.Mobile = testValue;
            Assert.AreEqual(testValue, model.Mobile);
        }
    }
}