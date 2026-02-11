using Gestionale.Application.Services.Interfaces;
using Gestionale.Shared.DTOs;
using Gestionale.Shared.Extensions;

namespace Gestionale.Api.EndPoints
{
    public static class OrderEndpoints
    {
        public static void MapOrderEndpoints(this WebApplication app)
        {
            // Gruppo di endpoint per gli ordini
            var orders = app.MapGroup("/api/orders");

            // GET: /api/orders
            orders.MapGet("/", async (IOrderService service) =>
            {
                var list = await service.GetAllAsync();
                return list;
            })
            .WithName("GetAllOrders")
            .WithTags("Orders");

            // GET: /api/orders/{id}
            orders.MapGet("/{id}", async (Guid id, IOrderService service) =>
            {
                return await service.GetByIdAsync(id);
            })
            .WithName("GetOrderById")
            .WithTags("Orders");

            // GET: /api/orders/by-customer/{customerId}
            orders.MapGet("/by-customer/{customerId}", async (Guid customerId, IOrderService service) =>
            {
                var list = await service.GetByCustomerIdAsync(customerId);
                return list;
            })
            .WithName("GetOrdersByCustomer")
            .WithTags("Orders");

            // POST: /api/orders
            orders.MapPost("/", async (CreateOrderDto dto, IOrderService service) =>
            {
                await service.CreateAsync(dto);
                return Results.Ok();
            })
            .WithName("CreateOrder")
            .WithTags("Orders");

            // PUT: /api/orders/{id}
            orders.MapPut("/{id}", async (Guid id, CreateOrderDto dto, IOrderService service) =>
            {
                await service.UpdateAsync(id, dto);
                return Results.NoContent();
            })
            .WithName("UpdateOrder")
            .WithTags("Orders");

            // DELETE: /api/orders/{id}
            orders.MapDelete("/{id}", async (Guid id, IOrderService service) =>
            {
                await service.DeleteAsync(id);
                return Results.Ok(); 
            })
            .WithName("DeleteOrder")
            .WithTags("Orders");
        }
    }
}
