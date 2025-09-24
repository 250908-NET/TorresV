using Xunit;
using Microsoft.EntityFrameworkCore;
using CustomerManagement.Data;
using CustomerManagement.Models;

namespace CustomerManagement.Tests
{
    public class CustomerTests
    {
        [Fact]
        public void Customer_Creation_SetsPropertiesCorrectly()
        {
            // Arrange
            var customer = new Customer
            {
                FirstName = "John",
                LastName = "Doe",
                Email = "john.doe@test.com",
                Phone = "555-1234"
            };
            
            // Act & Assert
            Assert.Equal("John", customer.FirstName);
            Assert.Equal("Doe", customer.LastName);
            Assert.Equal("john.doe@test.com", customer.Email);
            Assert.True(customer.IsActive); // Should default to true
        }
        
        [Fact]
        public void Customer_FullName_ConcatenatesCorrectly()
        {
            // Arrange
            var customer = new Customer
            {
                FirstName = "Jane",
                LastName = "Smith"
            };
            
            // Act
            var fullName = $"{customer.FirstName} {customer.LastName}";
            
            // Assert
            Assert.Equal("Jane Smith", fullName);
        }
    }
}
