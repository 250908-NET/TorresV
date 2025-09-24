using Xunit;
using CustomerManagement.Models;

namespace CustomerManagement.Tests
{
    public class CustomerTests
    {
        [Fact]
        public void Customer_Creation_SetsPropertiesCorrectly()
        {
            // Arrange & Act
            var customer = new Customer
            {
                FirstName = "John",
                LastName = "Doe",
                Email = "john.doe@test.com",
                Phone = "555-1234",
                CustomerType = "Individual"
            };
            
            // Assert
            Assert.Equal("John", customer.FirstName);
            Assert.Equal("Doe", customer.LastName);
            Assert.Equal("john.doe@test.com", customer.Email);
            Assert.True(customer.IsActive);
            Assert.Equal("Individual", customer.CustomerType);
        }
        
        [Fact]
        public void Customer_DefaultValues_AreSetCorrectly()
        {
            // Arrange & Act
            var customer = new Customer();
            
            // Assert
            Assert.True(customer.IsActive);
            Assert.NotEqual(default(DateTime), customer.CreatedDate);
        }

        [Theory]
        [InlineData("", "Doe", false)]
        [InlineData("John", "", false)]
        [InlineData("John", "Doe", true)]
        public void Customer_IsValidName_ReturnsExpected(string firstName, string lastName, bool expected)
        {
            // Arrange
            var customer = new Customer
            {
                FirstName = firstName,
                LastName = lastName
            };
            
            // Act
            bool isValid = !string.IsNullOrEmpty(customer.FirstName) && 
                          !string.IsNullOrEmpty(customer.LastName);
            
            // Assert
            Assert.Equal(expected, isValid);
        }
    }
}
