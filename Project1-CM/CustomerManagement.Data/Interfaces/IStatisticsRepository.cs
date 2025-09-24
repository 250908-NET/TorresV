using CustomerManagement.Models.DTOs;

namespace CustomerManagement.Data.Interfaces
{
    public interface IStatisticsRepository
    {
        Task<CustomerStatsDto> GetCustomerStatisticsAsync();
        Task<int> GetTotalCustomersAsync();
        Task<int> GetActiveCustomersAsync();
        Task<int> GetTotalOrdersAsync();
        Task<decimal> GetTotalRevenueAsync();
        Task<List<CustomerTypeStatsDto>> GetCustomerTypeBreakdownAsync();
    }
}