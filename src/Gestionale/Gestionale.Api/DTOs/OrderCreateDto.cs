namespace Gestionale.Api.DTOs
{
    public class OrderCreateDto
    {
        public decimal TotalAmount { get; set; }
        public Guid CustomerId { get; set; }
    }
}
