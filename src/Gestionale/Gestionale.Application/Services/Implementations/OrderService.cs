using Gestionale.Application.Services.Interfaces;
using Gestionale.Domain.Entities;
using Gestionale.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Gestionale.Application.Services.Implementations
{
    using Gestionale.Domain.Entities;
    using Gestionale.Infrastructure.Repositories.Interfaces;
    using Gestionale.Shared.DTOs;
    using Gestionale.Shared.Extensions;

    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _repository;

        public OrderService(IOrderRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<OrderDto>> GetAllAsync()
        {
            var orders = await _repository.GetAllAsync();
            return orders.Select(o => o.ToDto()).ToList();
        }

        public async Task<OrderDto> GetByIdAsync(Guid id)
        {
            var order = await _repository.GetByIdAsync(id)
                ?? throw new KeyNotFoundException("Order not found");

            return order.ToDto();
        }

        public async Task<List<OrderDto>> GetByCustomerIdAsync(Guid customerId)
        {
            var orders = await _repository.GetByCustomerIdAsync(customerId);
            return orders.Select(o => o.ToDto()).ToList();
        }

        public async Task<Guid> CreateAsync(CreateOrderDto dto)
        {
            var order = new Order
            {
                Id = Guid.NewGuid(),
                OrderDate = dto.OrderDate == default ? DateTime.UtcNow : dto.OrderDate,
                TotalAmount = dto.TotalAmount,
                CustomerId = dto.CustomerId
            };

            await _repository.AddAsync(order);
            return order.Id;
        }

        public async Task UpdateAsync(Guid id, CreateOrderDto dto)
        {
            var order = await _repository.GetByIdAsync(id)
                ?? throw new KeyNotFoundException("Order not found");

            order.OrderDate = dto.OrderDate;
            order.TotalAmount = dto.TotalAmount;
            order.CustomerId = dto.CustomerId;

            await _repository.UpdateAsync(order);
        }

        public async Task DeleteAsync(Guid id)
        {
            var order = await _repository.GetByIdAsync(id)
                ?? throw new KeyNotFoundException("Order not found");

            await _repository.DeleteAsync(order);
        }
    }
}
