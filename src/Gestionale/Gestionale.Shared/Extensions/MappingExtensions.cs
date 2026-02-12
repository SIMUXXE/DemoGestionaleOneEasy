using Gestionale.Shared.DTOs;
using Gestionale.Domain.Entities;

namespace Gestionale.Shared.Extensions
{
    public static class MappingExtensions
    {
        // Entity → DTO
        public static CustomerDto ToDto(this Customer c) =>
            new CustomerDto
            {
                Id = c.Id,
                FullName = $"{c.FirstName} {c.LastName}",
                Email = c.Email,
                CreationDate = c.CreationDate
            };

        public static OrderDto ToDto(this Order o) =>
            new OrderDto
            {
                Id = o.Id,
                OrderDate = o.OrderDate,
                TotalAmount = o.TotalAmount,
                CustomerId = o.CustomerId
            };

        // DTO → Entity
        public static Customer ToEntity(this CreateCustomerDto dto) =>
            new Customer
            {
                Id = Guid.NewGuid(),
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                Email = dto.Email,
                CreationDate = DateTime.UtcNow
            };

        public static Order ToEntity(this CreateOrderDto dto) =>
            new Order
            {
                Id = Guid.NewGuid(),
                TotalAmount = dto.TotalAmount,
                CustomerId = dto.CustomerId,
                OrderDate = DateTime.UtcNow
            };
    }
}
