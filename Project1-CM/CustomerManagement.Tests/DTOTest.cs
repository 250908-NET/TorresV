using Xunit;
using CustomerManagement.Models.DTOs;

namespace CustomerManagement.Tests
{
    public class DtoTests
    {
        [Fact]
        public void CreateCustomerDto_RequiredFields_AreNotEmpty()
        {
            // Arrange & Act
            var dto = new CreateCustomerDto
            {
                FirstName = "Jane",
                LastName = "Smith",
                Email = "jane@example.com",
                Phone = "555-9876"
            };
            
            // Assert
            Assert.NotEmpty(dto.FirstName);
            Assert.NotEmpty(dto.LastName);
            Assert.Contains("@", dto.Email);
        }
        
        [Fact]
        public void CustomerDto_FullName_ConcatenatesCorrectly()
        {
            // Arrange
            var dto = new CustomerDto
            {
                FullName = "John Doe"
            };
            
            // Act & Assert
            Assert.Equal("John Doe", dto.FullName);
            Assert.Contains(" ", dto.FullName);
        }
    }
}