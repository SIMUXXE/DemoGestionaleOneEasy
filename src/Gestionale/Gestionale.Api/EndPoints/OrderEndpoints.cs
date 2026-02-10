using Gestionale.Api.DTOs;
using Gestionale.Api.Mapping;
using Gestionale.Api.Services.Interfaces;

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
                return list.Select(o => o.ToDto());
            })
            .WithName("GetAllOrders")
            .WithTags("Orders");

            // GET: /api/orders/{id}
            orders.MapGet("/{id}", async (Guid id, IOrderService service) =>
            {
                var o = await service.GetByIdAsync(id);
                return o is null ? Results.NotFound() : Results.Ok(o.ToDto());
            })
            .WithName("GetOrderById")
            .WithTags("Orders");

            // GET: /api/orders/by-customer/{customerId}
            orders.MapGet("/by-customer/{customerId}", async (Guid customerId, IOrderService service) =>
            {
                var list = await service.GetOrdersByCustomerIdAsync(customerId);
                return list.Select(o => o.ToDto());
            })
            .WithName("GetOrdersByCustomer")
            .WithTags("Orders");

            // POST: /api/orders
            orders.MapPost("/", async (OrderCreateDto dto, IOrderService service) =>
            {
                var order = dto.ToEntity();
                await service.CreateAsync(order);
                return Results.Created($"/api/orders/{order.Id}", order.ToDto());
            })
            .WithName("CreateOrder")
            .WithTags("Orders");

            // PUT: /api/orders/{id}
            orders.MapPut("/{id}", async (Guid id, OrderCreateDto dto, IOrderService service) =>
            {
                var o = await service.GetByIdAsync(id);
                if (o is null) return Results.NotFound();

                // Aggiorno campi modificabili
                o.TotalAmount = dto.TotalAmount;
                o.CustomerId = dto.CustomerId;

                await service.UpdateAsync(o);
                return Results.NoContent();
            })
            .WithName("UpdateOrder")
            .WithTags("Orders");

            // DELETE: /api/orders/{id}
            orders.MapDelete("/{id}", async (Guid id, IOrderService service) =>
            {
                var deleted = await service.DeleteAsync(id);
                return deleted ? Results.NoContent() : Results.NotFound();
            })
            .WithName("DeleteOrder")
            .WithTags("Orders");
        }
    }
}
