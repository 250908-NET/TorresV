using CustomerManagement.Models;

namespace CustomerManagement.Data.Interfaces
{
    public interface IOrderRepository
    {
        Task<List<Order>> GetAllAsync();
        Task<Order?> GetByIdAsync(int id);
        Task<List<Order>> GetByCustomerIdAsync(int customerId);
        Task AddAsync(Order order);
        Task UpdateAsync(Order order);
        Task DeleteAsync(int id);
        Task AddCustomerOrderAsync(CustomerOrder customerOrder);
        Task SaveChangesAsync();
    }
}