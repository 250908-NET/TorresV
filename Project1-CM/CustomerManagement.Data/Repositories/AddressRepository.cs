using Microsoft.EntityFrameworkCore;
using CustomerManagement.Data.Interfaces;
using CustomerManagement.Models;

namespace CustomerManagement.Data.Repositories
{
    public class AddressRepository : IAddressRepository
    {
        private readonly CustomerContext _context;

        public AddressRepository(CustomerContext context)
        {
            _context = context;
        }

        public async Task<List<Address>> GetByCustomerIdAsync(int customerId)
        {
            return await _context.Addresses
                .Where(a => a.CustomerId == customerId)
                .ToListAsync();
        }

        public async Task<Address?> GetByIdAsync(int id)
        {
            return await _context.Addresses.FindAsync(id);
        }

        public async Task AddAsync(Address address)
        {
            await _context.Addresses.AddAsync(address);
        }

        public async Task UpdateAsync(Address address)
        {
            _context.Addresses.Update(address);
        }

        public async Task DeleteAsync(int id)
        {
            var address = await GetByIdAsync(id);
            if (address != null)
            {
                _context.Addresses.Remove(address);
            }
        }

        public async Task SetPrimaryAddressAsync(int customerId, int addressId)
        {
            var addresses = await GetByCustomerIdAsync(customerId);
            
            foreach (var address in addresses)
            {
                address.IsPrimary = address.AddressId == addressId;
            }
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
