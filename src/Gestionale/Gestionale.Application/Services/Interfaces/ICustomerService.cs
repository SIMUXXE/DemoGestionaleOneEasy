using Gestionale.Domain.Entities;
using Gestionale.Shared.DTOs;

namespace Gestionale.Application.Services.Interfaces
{
    public interface ICustomerService
    {
        Task<List<CustomerDto>> GetAllAsync();
        Task<CustomerDto?> GetByIdAsync(Guid id);
        Task<CustomerDto> CreateAsync(CreateCustomerDto customer);
        Task UpdateAsync(Guid id, CreateCustomerDto customer);
        Task DeleteAsync(Guid id);
    }
}
