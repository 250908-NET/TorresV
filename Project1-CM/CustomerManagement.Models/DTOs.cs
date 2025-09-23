namespace CustomerManagement.Models.DTOs
{
    // === CUSTOMER DTOs ===
    
    public class CustomerDto
    {
        public int CustomerId { get; set; }
        public string FullName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public DateTime CreatedDate { get; set; }
        public bool IsActive { get; set; }
        public string CustomerType { get; set; } = string.Empty;
        public List<AddressDto> Addresses { get; set; } = new();
        public int TotalOrders { get; set; }
        public decimal TotalSpent { get; set; }
    }
    
    public class CreateCustomerDto
    {
        [Required]
        [MaxLength(50)]
        public string FirstName { get; set; } = string.Empty;
        
        [Required]
        [MaxLength(50)]
        public string LastName { get; set; } = string.Empty;
        
        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;
        
        [Phone]
        public string Phone { get; set; } = string.Empty;
        
        public string CustomerType { get; set; } = "Individual";
        public string? Notes { get; set; }
        public CreateAddressDto? PrimaryAddress { get; set; }
    }
    
    public class UpdateCustomerDto
    {
        [Required]
        [MaxLength(50)]
        public string FirstName { get; set; } = string.Empty;
        
        [Required]
        [MaxLength(50)]
        public string LastName { get; set; } = string.Empty;
        
        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;
        
        [Phone]
        public string Phone { get; set; } = string.Empty;
        
        public bool IsActive { get; set; } = true;
        public string CustomerType { get; set; } = "Individual";
        public string? Notes { get; set; }
    }
    
    // === ADDRESS DTOs ===
    
    public class AddressDto
    {
        public int AddressId { get; set; }
        public string AddressType { get; set; } = string.Empty;
        public string FullAddress { get; set; } = string.Empty;
        public bool IsPrimary { get; set; }
    }
    
    public class CreateAddressDto
    {
        [Required]
        public string AddressType { get; set; } = "Home";
        
        [Required]
        public string Street { get; set; } = string.Empty;
        
        [Required]
        public string City { get; set; } = string.Empty;
        
        [Required]
        public string State { get; set; } = string.Empty;
        
        [Required]
        public string ZipCode { get; set; } = string.Empty;
        
        public string Country { get; set; } = "USA";
        public bool IsPrimary { get; set; } = false;
    }
    
    // === ORDER DTOs ===
    
    public class OrderDto
    {
        public int OrderId { get; set; }
        public string OrderNumber { get; set; } = string.Empty;
        public DateTime OrderDate { get; set; }
        public decimal TotalAmount { get; set; }
        public string Status { get; set; } = string.Empty;
        public string? Description { get; set; }
        public List<CustomerSummaryDto> Customers { get; set; } = new();
    }
    
    public class CreateOrderDto
    {
        [Required]
        public string OrderNumber { get; set; } = string.Empty;
        
        [Range(0.01, double.MaxValue)]
        public decimal TotalAmount { get; set; }
        
        public string Status { get; set; } = "Pending";
        public string? Description { get; set; }
        public List<int> CustomerIds { get; set; } = new();
    }
    
    // === HELPER DTOs ===
    
    public class CustomerSummaryDto
    {
        public int CustomerId { get; set; }
        public string FullName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Role { get; set; } = string.Empty;
    }
    
    public class CustomerStatsDto
    {
        public int TotalCustomers { get; set; }
        public int ActiveCustomers { get; set; }
        public int InactiveCustomers { get; set; }
        public int TotalOrders { get; set; }
        public decimal TotalRevenue { get; set; }
        public List<CustomerTypeStatsDto> CustomerTypeBreakdown { get; set; } = new();
    }
    
    public class CustomerTypeStatsDto
    {
        public string CustomerType { get; set; } = string.Empty;
        public int Count { get; set; }
        public decimal TotalRevenue { get; set; }
    }
}