using Microsoft.EntityFrameworkCore;
using CustomerManagement.Data.Interfaces;
using CustomerManagement.Models;

namespace CustomerManagement.Data.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly CustomerContext _context;

        public CustomerRepository(CustomerContext context)
        {
            _context = context;
        }

        public async Task<List<Customer>> GetAllActiveAsync()
        {
            return await _context.Customers
                .Include(c => c.Addresses)
                .Include(c => c.CustomerOrders)
                .Where(c => c.IsActive)
                .ToListAsync();
        }

        public async Task<Customer?> GetByIdAsync(int id)
        {
            return await _context.Customers.FindAsync(id);
        }

        public async Task<Customer?> GetByIdWithIncludesAsync(int id)
        {
            return await _context.Customers
                .Include(c => c.Addresses)
                .Include(c => c.CustomerOrders)
                .FirstOrDefaultAsync(c => c.CustomerId == id);
        }

        public async Task<List<Customer>> SearchAsync(string query)
        {
            return await _context.Customers
                .Include(c => c.Addresses)
                .Include(c => c.CustomerOrders)
                .Where(c => c.IsActive && 
                           (c.FirstName.Contains(query) || 
                            c.LastName.Contains(query) || 
                            c.Email.Contains(query)))
                .ToListAsync();
        }

        public async Task<List<Customer>> FilterByTypeAsync(string customerType)
        {
            return await _context.Customers
                .Include(c => c.Addresses)
                .Include(c => c.CustomerOrders)
                .Where(c => c.IsActive && c.CustomerType == customerType)
                .ToListAsync();
        }

        public async Task<Customer?> GetByEmailAsync(string email)
        {
            return await _context.Customers
                .FirstOrDefaultAsync(c => c.Email == email);
        }

        public async Task AddAsync(Customer customer)
        {
            await _context.Customers.AddAsync(customer);
        }

        public async Task UpdateAsync(Customer customer)
        {
            customer.LastUpdated = DateTime.UtcNow;
            _context.Customers.Update(customer);
        }

        public async Task DeleteAsync(int id)
        {
            var customer = await GetByIdAsync(id);
            if (customer != null)
            {
                customer.IsActive = false;
                customer.LastUpdated = DateTime.UtcNow;
            }
        }

        public async Task<bool> EmailExistsAsync(string email, int? excludeCustomerId = null)
        {
            var query = _context.Customers.Where(c => c.Email == email);
            
            if (excludeCustomerId.HasValue)
            {
                query = query.Where(c => c.CustomerId != excludeCustomerId.Value);
            }
            
            return await query.AnyAsync();
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}