using Gestionale.Domain.Entities;
using Gestionale.Shared.DTOs;

namespace Gestionale.Application.Services.Interfaces
{
    public interface IOrderService
    {
        Task<List<OrderDto>> GetAllAsync();
        Task<OrderDto> GetByIdAsync(Guid id);
        Task<List<OrderDto>> GetByCustomerIdAsync(Guid customerId);
        Task<Guid> CreateAsync(CreateOrderDto dto);
        Task UpdateAsync(Guid id, CreateOrderDto dto);
        Task DeleteAsync(Guid id);
    }
}
