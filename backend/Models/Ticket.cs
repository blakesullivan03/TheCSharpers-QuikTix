namespace TheCSharpers_QuikTix.Models
{
    public class Ticket
    {
        public int Id { get; set; }
        public int ShowtimeId { get; set; }
        public Showtime? Showtime { get; set; }
        public string? TicketType { get; set; } // "Adult" or "Child"
        public decimal Price { get; set; }
        public DateTime PurchaseTime { get; set; }

        public int CartId { get; set; }

        public Cart? Cart { get; set; }

        public int MovieId { get; set; }

        public Boolean IsAvailable { get; set; }
    }

}