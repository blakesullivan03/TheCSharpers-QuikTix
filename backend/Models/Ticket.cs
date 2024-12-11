namespace TheCSharpers_QuikTix.Models
{
    public class Ticket
    {
        public int Id { get; set; }
        public int MovieId { get; set; }
        public int ShowtimeId { get; set; }
        public string? TicketType { get; set; } // "Adult" or "Child"
        public decimal Price { get; set; }

        public int Quantity { get; set; }

    }

}