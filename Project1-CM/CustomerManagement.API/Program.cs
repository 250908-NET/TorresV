// Program.cs in CustomerManagement.API
using Microsoft.EntityFrameworkCore;
using CustomerManagement.Data;
using CustomerManagement.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services
builder.Services.AddDbContext<CustomerContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure pipeline
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// === CUSTOMER ENDPOINTS ===

// GET: Get all customers
app.MapGet("/api/customers", async (CustomerContext db) =>
{
    return await db.Customers
        .Include(c => c.Addresses)
        .Include(c => c.CustomerOrders)
        .Where(c => c.IsActive)
        .Select(c => new CustomerDto
        {
            CustomerId = c.CustomerId,
            FullName = $"{c.FirstName} {c.LastName}",
            Email = c.Email,
            Phone = c.Phone,
            CreatedDate = c.CreatedDate,
            IsActive = c.IsActive,
            Addresses = c.Addresses.Select(a => new AddressDto
            {
                AddressId = a.AddressId,
                AddressType = a.AddressType,
                FullAddress = $"{a.Street}, {a.City}, {a.State} {a.ZipCode}",
                IsPrimary = a.IsPrimary
            }).ToList(),
            TotalOrders = c.CustomerOrders.Count
        })
        .ToListAsync();
})
.WithName("GetAllCustomers")
.WithOpenApi();

// GET: Get customer by ID
app.MapGet("/api/customers/{id}", async (int id, CustomerContext db) =>
{
    var customer = await db.Customers
        .Include(c => c.Addresses)
        .Include(c => c.CustomerOrders)
        .FirstOrDefaultAsync(c => c.CustomerId == id);
        
    if (customer is null) return Results.NotFound();
    
    var customerDto = new CustomerDto
    {
        CustomerId = customer.CustomerId,
        FullName = $"{customer.FirstName} {customer.LastName}",
        Email = customer.Email,
        Phone = customer.Phone,
        CreatedDate = customer.CreatedDate,
        IsActive = customer.IsActive,
        Addresses = customer.Addresses.Select(a => new AddressDto
        {
            AddressId = a.AddressId,
            AddressType = a.AddressType,
            FullAddress = $"{a.Street}, {a.City}, {a.State} {a.ZipCode}",
            IsPrimary = a.IsPrimary
        }).ToList(),
        TotalOrders = customer.CustomerOrders.Count
    };
    
    return Results.Ok(customerDto);
})
.WithName("GetCustomerById")
.WithOpenApi();

// POST: Create new customer
app.MapPost("/api/customers", async (CreateCustomerDto customerDto, CustomerContext db) =>
{
    var customer = new Customer
    {
        FirstName = customerDto.FirstName,
        LastName = customerDto.LastName,
        Email = customerDto.Email,
        Phone = customerDto.Phone,
        CreatedDate = DateTime.UtcNow,
        IsActive = true
    };
    
    // Add primary address if provided
    if (customerDto.PrimaryAddress != null)
    {
        customer.Addresses.Add(new Address
        {
            AddressType = customerDto.PrimaryAddress.AddressType,
            Street = customerDto.PrimaryAddress.Street,
            City = customerDto.PrimaryAddress.City,
            State = customerDto.PrimaryAddress.State,
            ZipCode = customerDto.PrimaryAddress.ZipCode,
            Country = customerDto.PrimaryAddress.Country,
            IsPrimary = true
        });
    }
    
    db.Customers.Add(customer);
    await db.SaveChangesAsync();
    
    return Results.Created($"/api/customers/{customer.CustomerId}", customer);
})
.WithName("CreateCustomer")
.WithOpenApi();

// PUT: Update customer
app.MapPut("/api/customers/{id}", async (int id, UpdateCustomerDto customerDto, CustomerContext db) =>
{
    var customer = await db.Customers.FindAsync(id);
    if (customer is null) return Results.NotFound();
    
    customer.FirstName = customerDto.FirstName;
    customer.LastName = customerDto.LastName;
    customer.Email = customerDto.Email;
    customer.Phone = customerDto.Phone;
    customer.IsActive = customerDto.IsActive;
    customer.LastUpdated = DateTime.UtcNow;
    
    await db.SaveChangesAsync();
    
    return Results.Ok(customer);
})
.WithName("UpdateCustomer")
.WithOpenApi();

// DELETE: Delete customer (soft delete)
app.MapDelete("/api/customers/{id}", async (int id, CustomerContext db) =>
{
    var customer = await db.Customers.FindAsync(id);
    if (customer is null) return Results.NotFound();
    
    customer.IsActive = false;
    customer.LastUpdated = DateTime.UtcNow;
    
    await db.SaveChangesAsync();
    
    return Results.NoContent();
})
.WithName("DeleteCustomer")
.WithOpenApi();

app.Run();