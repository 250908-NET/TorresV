using CustomerManagement.Models;

namespace CustomerManagement.Data
{
    public static class SeedData
    {
        public static void Initialize(CustomerContext context)
        {
            if (context.Customers.Any())
                return; // DB has been seeded
                
            var customers = new Customer[]
            {
                new Customer
                {
                    FirstName = "John",
                    LastName = "Doe",
                    Email = "john.doe@email.com",
                    Phone = "(555) 123-4567",
                    CustomerType = "Individual"
                },
                new Customer
                {
                    FirstName = "Jane",
                    LastName = "Smith",
                    Email = "jane.smith@email.com",
                    Phone = "(555) 987-6543",
                    CustomerType = "Premium"
                },
                new Customer
                {
                    FirstName = "Acme",
                    LastName = "Corporation",
                    Email = "contact@acme.com",
                    Phone = "(555) 555-0123",
                    CustomerType = "Business"
                }
            };
            
            context.Customers.AddRange(customers);
            context.SaveChanges();
            
            // Add sample addresses
            var addresses = new Address[]
            {
                new Address
                {
                    CustomerId = 1,
                    AddressType = "Home",
                    Street = "123 Main St",
                    City = "Anytown",
                    State = "CA",
                    ZipCode = "12345",
                    IsPrimary = true
                },
                new Address
                {
                    CustomerId = 2,
                    AddressType = "Work",
                    Street = "456 Business Ave",
                    City = "Commerce City",
                    State = "NY",
                    ZipCode = "67890",
                    IsPrimary = true
                }
            };
            
            context.Addresses.AddRange(addresses);
            context.SaveChanges();
            
            // Add sample orders
            var orders = new Order[]
            {
                new Order
                {
                    OrderNumber = "ORD-001",
                    TotalAmount = 299.99m,
                    Status = "Completed",
                    Description = "First sample order"
                },
                new Order
                {
                    OrderNumber = "ORD-002",
                    TotalAmount = 149.50m,
                    Status = "Pending",
                    Description = "Second sample order"
                }
            };
            
            context.Orders.AddRange(orders);
            context.SaveChanges();
            
            // Create customer-order relationships (Many-to-Many)
            var customerOrders = new CustomerOrder[]
            {
                new CustomerOrder
                {
                    CustomerId = 1,
                    OrderId = 1,
                    Role = "Primary"
                },
                new CustomerOrder
                {
                    CustomerId = 2,
                    OrderId = 2,
                    Role = "Primary"
                },
                new CustomerOrder
                {
                    CustomerId = 1,
                    OrderId = 2,
                    Role = "Secondary"
                }
            };
            
            context.CustomerOrders.AddRange(customerOrders);
            context.SaveChanges();
        }
    }
}