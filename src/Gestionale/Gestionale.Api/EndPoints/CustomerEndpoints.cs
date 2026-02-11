using Gestionale.Shared.DTOs;
using Gestionale.Application.Services.Interfaces;

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
                return list;
            })
            .WithName("GetAllCustomers")
            .WithTags("Customers");

            // GET: /api/customers/{id}
            customers.MapGet("/{id}", async (Guid id, ICustomerService service) =>
            {
                var c = await service.GetByIdAsync(id);
                return c is null ? Results.NotFound() : Results.Ok(c);
            })
            .WithName("GetCustomerById")
            .WithTags("Customers");

            // POST: /api/customers
            customers.MapPost("/", async (CreateCustomerDto dto, ICustomerService service) =>
            {
                var newCustomer = await service.CreateAsync(dto);
                return Results.Ok(newCustomer);
            })
            .WithName("CreateCustomer")
            .WithTags("Customers");

            // PUT: /api/customers/{id}
            customers.MapPut("/{id}", async (Guid id, CreateCustomerDto dto, ICustomerService service) =>
            {
                await service.UpdateAsync(id, dto);
                return Results.NoContent();
            })
            .WithName("UpdateCustomer")
            .WithTags("Customers");

            // DELETE: /api/customers/{id}
            customers.MapDelete("/{id}", async (Guid id, ICustomerService service) =>
            {
                await service.DeleteAsync(id);
                return Results.Ok();
            })
            .WithName("DeleteCustomer")
            .WithTags("Customers");
        }
    }
}

