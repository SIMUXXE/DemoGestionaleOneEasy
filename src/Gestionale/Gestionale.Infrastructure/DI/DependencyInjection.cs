using Gestionale.Infrastructure.Data;
using Gestionale.Infrastructure.Repositories.Implementations;
using Gestionale.Infrastructure.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Gestionale.Infrastructure.DI
{
    public static class DependencyInjection
    {
        /// <summary>
        /// Estensione per registrare tutte le dipendenze della soluzione
        /// </summary>
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            // Registrazione DbContext
            services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(
                    configuration.GetConnectionString("DefaultConnection"),
                    sql => sql.MigrationsAssembly("Gestionale.Infrastructure")
                ));

            services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddScoped<IOrderRepository, OrderRepository>();
            return services;
        }
    }
}
