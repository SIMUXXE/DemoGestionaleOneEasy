using Gestionale.Api.EndPoints;
using Gestionale.Api.Services.Implementations;
using Gestionale.Api.Services.Interfaces;
using Gestionale.Infrastructure.Data;
using Gestionale.Infrastructure.DI;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// Registrazione DI centralizzata
builder.Services.AddInfrastructureServices(builder.Configuration);

// Registrazione Servizi API
builder.Services.AddScoped<ICustomerService, CustomerService>();
builder.Services.AddScoped<IOrderService, OrderService>();


builder.Services.AddEndpointsApiExplorer(); 
builder.Services.AddSwaggerGen();


builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();

    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

// Seed dei dati fittizi all'avvio dell'applicazione
using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();

    // Applica eventuali migration
    context.Database.Migrate();

    // Seed dei dati fittizi
    DbSeeder.Seed(context);
}

// Mapping endpoints minimal API
app.MapCustomerEndpoints();
app.MapOrderEndpoints();


app.Run();
