using Gestionale.Application.Services.Interfaces;
using Gestionale.Domain.Entities;
using Gestionale.Shared.DTOs;
using Gestionale.Shared.Extensions;
using Gestionale.Infrastructure.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Gestionale.Application.Services.Implementations
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _repository;

        public CustomerService(ICustomerRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<CustomerDto>> GetAllAsync()
        {
            var customers = await _repository.GetAllAsync();
            return customers.Select(c => c.ToDto()).ToList();
        }

        public async Task<CustomerDto> GetByIdAsync(Guid id)
        {
            var customer = await _repository.GetByIdAsync(id)
                ?? throw new KeyNotFoundException("Customer not found");

            return customer.ToDto();
        }

        public async Task<CustomerDto> CreateAsync(CreateCustomerDto dto)
        {
            var customer = new Customer
            {
                Id = Guid.NewGuid(),
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                Email = dto.Email
            };

            await _repository.AddAsync(customer);
            return customer.ToDto();
        }

        public async Task UpdateAsync(Guid id, CreateCustomerDto dto)
        {
            var customer = await _repository.GetByIdAsync(id)
                ?? throw new KeyNotFoundException("Customer not found");

            customer.FirstName = dto.FirstName;
            customer.LastName = dto.LastName;
            customer.Email = dto.Email;

            await _repository.UpdateAsync(customer);
        }

        public async Task DeleteAsync(Guid id)
        {
            var customer = await _repository.GetByIdAsync(id)
                ?? throw new KeyNotFoundException("Customer not found");

            await _repository.DeleteAsync(customer);
        }
    }
}
