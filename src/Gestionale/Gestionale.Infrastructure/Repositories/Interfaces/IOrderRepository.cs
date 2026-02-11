using Gestionale.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Gestionale.Infrastructure.Repositories.Interfaces
{
    public interface IOrderRepository
    {
        Task<List<Order>> GetAllAsync();
        Task<Order?> GetByIdAsync(Guid id);
        Task<List<Order>> GetByCustomerIdAsync(Guid customerId);
        Task AddAsync(Order order);
        Task UpdateAsync(Order order);
        Task DeleteAsync(Order order);
    }
}
