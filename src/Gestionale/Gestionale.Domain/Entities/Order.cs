using System;
using System.Collections.Generic;
using System.Text;

namespace Gestionale.Domain.Entities
{
    // Classe che rappresenta l'entità "Order" (Ordine) nel dominio dell'applicazione
    public class Order
    {
        public Guid Id { get; set; }

        public DateTime OrderDate { get; set; } = DateTime.UtcNow;

        public decimal TotalAmount { get; set; }

        // FK
        public Guid CustomerId { get; set; }

        // Navigazione
        public Customer? Customer { get; set; }
    }
}
