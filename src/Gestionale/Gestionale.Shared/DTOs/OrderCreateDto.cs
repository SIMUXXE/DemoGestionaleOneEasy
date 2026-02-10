namespace Gestionale.Shared.DTOs
{
    public class OrderCreateDto
    {
        public decimal TotalAmount { get; set; }
        public Guid CustomerId { get; set; }
    }
}
