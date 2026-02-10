using Gestionale.Domain.Entities;

namespace Gestionale.Api.Services.Interfaces
{
    public interface IOrderService
    {
        Task<List<Order>> GetAllAsync();
        Task<Order?> GetByIdAsync(Guid id);
        Task<Order> CreateAsync(Order order);
        Task<bool> UpdateAsync(Order order);
        Task<bool> DeleteAsync(Guid id);
        Task<List<Order>> GetOrdersByCustomerIdAsync(Guid customerId);
    }
}
