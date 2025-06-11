using Xunit;
namespace ClairTourTiny.Core.Models.ProjectMaintenance.Tests
{
    public class ProjectClientShippingAddressModelTests
    {
        [Fact]
        public void CustNo_Should_SetAndGetCorrectly()
        {
            // Arrange
            var model = new ProjectClientShippingAddressModel();
            var expected = "12345";
            
            // Act
            model.CustNo = expected;
            
            // Assert
            Assert.Equal(expected, model.CustNo);
        }
        
        [Fact]
        public void SubNo_Should_SetAndGetCorrectly()
        {
            // Arrange
            var model = new ProjectClientShippingAddressModel();
            var expected = "67890";
            
            // Act
            model.SubNo = expected;
            
            // Assert
            Assert.Equal(expected, model.SubNo);
        }
        
        [Fact]
        public void ShipNo_Should_SetAndGetCorrectly()
        {
            // Arrange
            var model = new ProjectClientShippingAddressModel();
            var expected = "54321";
            
            // Act
            model.ShipNo = expected;
            
            // Assert
            Assert.Equal(expected, model.ShipNo);
        }
        
        [Fact]
        public void ShipToName_Should_SetAndGetCorrectly()
        {
            // Arrange
            var model = new ProjectClientShippingAddressModel();
            var expected = "John Doe";
            
            // Act
            model.ShipToName = expected;
            
            // Assert
            Assert.Equal(expected, model.ShipToName);
        }
        
        [Fact]
        public void Contact_Should_SetAndGetCorrectly()
        {
            // Arrange
            var model = new ProjectClientShippingAddressModel();
            var expected = "Jane Doe";
            
            // Act
            model.Contact = expected;
            
            // Assert
            Assert.Equal(expected, model.Contact);
        }
        
        [Fact]
        public void Attention_Should_SetAndGetCorrectly()
        {
            // Arrange
            var model = new ProjectClientShippingAddressModel();
            var expected = "Attention";
            
            // Act
            model.Attention = expected;
            
            // Assert
            Assert.Equal(expected, model.Attention);
        }
        
        [Fact]
        public void Addr1_Should_SetAndGetCorrectly()
        {
            // Arrange
            var model = new ProjectClientShippingAddressModel();
            var expected = "123 Main St";
            
            // Act
            model.Addr1 = expected;
            
            // Assert
            Assert.Equal(expected, model.Addr1);
        }
        
        [Fact]
        public void Addr2_Should_SetAndGetCorrectly()
        {
            // Arrange
            var model = new ProjectClientShippingAddressModel();
            var expected = "Suite 100";
            
            // Act
            model.Addr2 = expected;
            
            // Assert
            Assert.Equal(expected, model.Addr2);
        }
        
        [Fact]
        public void Addr3_Should_SetAndGetCorrectly()
        {
            // Arrange
            var model = new ProjectClientShippingAddressModel();
            var expected = "Building B";
            
            // Act
            model.Addr3 = expected;
            
            // Assert
            Assert.Equal(expected, model.Addr3);
        }
        
        [Fact]
        public void City_Should_SetAndGetCorrectly()
        {
            // Arrange
            var model = new ProjectClientShippingAddressModel();
            var expected = "Metropolis";
            
            // Act
            model.City = expected;
            
            // Assert
            Assert.Equal(expected, model.City);
        }
        
        [Fact]
        public void State_Should_SetAndGetCorrectly()
        {
            // Arrange
            var model = new ProjectClientShippingAddressModel();
            var expected = "NY";
            
            // Act
            model.State = expected;
            
            // Assert
            Assert.Equal(expected, model.State);
        }
        
        [Fact]
        public void Zip_Should_SetAndGetCorrectly()
        {
            // Arrange
            var model = new ProjectClientShippingAddressModel();
            var expected = "12345";
            
            // Act
            model.Zip = expected;
            
            // Assert
            Assert.Equal(expected, model.Zip);
        }
        
        [Fact]
        public void Country_Should_SetAndGetCorrectly()
        {
            // Arrange
            var model = new ProjectClientShippingAddressModel();
            var expected = "USA";
            
            // Act
            model.Country = expected;
            
            // Assert
            Assert.Equal(expected, model.Country);
        }
        
        [Fact]
        public void Phone_Should_SetAndGetCorrectly()
        {
            // Arrange
            var model = new ProjectClientShippingAddressModel();
            var expected = "555-1234";
            
            // Act
            model.Phone = expected;
            
            // Assert
            Assert.Equal(expected, model.Phone);
        }
        
        [Fact]
        public void Ext_Should_SetAndGetCorrectly()
        {
            // Arrange
            var model = new ProjectClientShippingAddressModel();
            var expected = "101";
            
            // Act
            model.Ext = expected;
            
            // Assert
            Assert.Equal(expected, model.Ext);
        }
        
        [Fact]
        public void Email_Should_SetAndGetCorrectly()
        {
            // Arrange
            var model = new ProjectClientShippingAddressModel();
            var expected = "test@example.com";
            
            // Act
            model.Email = expected;
            
            // Assert
            Assert.Equal(expected, model.Email);
        }
        
        [Fact]
        public void Mobile_Should_SetAndGetCorrectly()
        {
            // Arrange
            var model = new ProjectClientShippingAddressModel();
            var expected = "555-6789";
            
            // Act
            model.Mobile = expected;
            
            // Assert
            Assert.Equal(expected, model.Mobile);
        }
    }
}