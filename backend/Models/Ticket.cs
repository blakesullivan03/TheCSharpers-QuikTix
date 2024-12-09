namespace TheCSharpers_QuikTix.Models
{
    public class Ticket
    {
        public int Id { get; set; }
        public string? TicketType { get; set; } 
        public decimal Price { get; set; }
        public int MovieId { get; set; }
        public Movie? Movie { get; set; }

    }
}