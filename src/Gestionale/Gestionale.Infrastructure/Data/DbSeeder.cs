using Gestionale.Domain.Entities;

namespace Gestionale.Infrastructure.Data
{
    public static class DbSeeder
    {
        public static void Seed(AppDbContext context)
        {
            if (context.Customers.Any())
                return;

            var customers = new List<Customer>
            {
                new Customer
                {
                    FirstName = "Mario",
                    LastName = "Rossi",
                    Email = "mario.rossi@test.it",
                    Orders =
                    {
                        new Order { OrderDate = DateTime.UtcNow.AddDays(-1), TotalAmount = 120.50m },
                        new Order { OrderDate = DateTime.UtcNow.AddDays(-2), TotalAmount = 89.99m }
                    }
                },
                new Customer
                {
                    FirstName = "Luigi",
                    LastName = "Bianchi",
                    Email = "luigi.bianchi@test.it",
                    Orders =
                    {
                        new Order { OrderDate = DateTime.UtcNow, TotalAmount = 45.00m }
                    }
                },
                new Customer
                {
                    FirstName = "Anna",
                    LastName = "Verdi",
                    Email = "anna.verdi@test.it",
                    Orders =
                    {
                        new Order { OrderDate = DateTime.UtcNow, TotalAmount = 200.00m },
                        new Order { OrderDate = DateTime.UtcNow.AddDays(-3), TotalAmount = 150.75m },
                        new Order { OrderDate = DateTime.UtcNow.AddDays(-5), TotalAmount = 99.99m }
                    }
                },
                new Customer
                {
                    FirstName = "Carlo",
                    LastName = "Neri",
                    Email = "carlo.neri@test.it",
                    Orders =
                    {
                        new Order { OrderDate = DateTime.UtcNow, TotalAmount = 320.00m },
                        new Order { OrderDate = DateTime.UtcNow.AddDays(-1), TotalAmount = 215.50m }
                    }
                }
            };

            context.Customers.AddRange(customers);
            context.SaveChanges();
        }
    }
}
