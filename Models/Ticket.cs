namespace TheCSharpers_QuikTix.Models
{
    public class Ticket
    {
        public int Id { get; set; }
         public int MovieId { get; set; }
        public Movie? Movie { get; set; }
        public string? TicketType { get; set; } 
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public decimal TotalPrice => Quantity * Price;

    }
}