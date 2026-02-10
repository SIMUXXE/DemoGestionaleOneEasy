using System;
using System.Collections.Generic;
using System.Text;

namespace Gestionale.Domain.Entities
{
    // Classe che rappresenta l'entità "Customer" (Cliente) nel dominio dell'applicazione
    public class Customer
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;

        public DateTime CreationDate { get; set; } = DateTime.UtcNow;

        // Navigazione
        public ICollection<Order> Orders { get; set; } = new List<Order>();
    }
}
