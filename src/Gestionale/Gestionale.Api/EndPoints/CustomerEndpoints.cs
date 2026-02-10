using Gestionale.Shared.DTOs;
using Gestionale.Api.Extensions;
using Gestionale.Api.Services.Interfaces;

namespace Gestionale.Api.EndPoints
{
    public static class CustomerEndpoints
    {
        public static void MapCustomerEndpoints(this WebApplication app)
        {
            var customers = app.MapGroup("/api/customers");


            // GET: /api/customers
            customers.MapGet("/", async (ICustomerService service) =>
            {
                var list = await service.GetAllAsync();
                return list.Select(c => c.ToDto());
            })
            .WithName("GetAllCustomers")
            .WithTags("Customers");

            // GET: /api/customers/{id}
            customers.MapGet("/{id}", async (Guid id, ICustomerService service) =>
            {
                var c = await service.GetByIdAsync(id);
                return c is null ? Results.NotFound() : Results.Ok(c.ToDto());
            })
            .WithName("GetCustomerById")
            .WithTags("Customers");

            // POST: /api/customers
            customers.MapPost("/", async (CustomerCreateDto dto, ICustomerService service) =>
            {
                var customer = dto.ToEntity();
                await service.CreateAsync(customer);
                return Results.Created($"/api/customers/{customer.Id}", customer.ToDto());
            })
            .WithName("CreateCustomer")
            .WithTags("Customers");

            // PUT: /api/customers/{id}
            customers.MapPut("/{id}", async (Guid id, CustomerCreateDto dto, ICustomerService service) =>
            {
                var c = await service.GetByIdAsync(id);
                if (c is null) return Results.NotFound();

                // Aggiornamento entity
                c.FirstName = dto.FirstName;
                c.LastName = dto.LastName;
                c.Email = dto.Email;

                await service.UpdateAsync(c);
                return Results.NoContent();
            })
            .WithName("UpdateCustomer")
            .WithTags("Customers");

            // DELETE: /api/customers/{id}
            customers.MapDelete("/{id}", async (Guid id, ICustomerService service) =>
            {
                var deleted = await service.DeleteAsync(id);
                return deleted ? Results.NoContent() : Results.NotFound();
            })
            .WithName("DeleteCustomer")
            .WithTags("Customers");
        }
    }
}

