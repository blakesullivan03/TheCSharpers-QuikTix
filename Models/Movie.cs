using System;

namespace TheCSharpers_QuikTix.Models
{
    public class Movie
    {
        public int Id { get; set; }
        public required string Title { get; set; }
        public required string Genre { get; set; }
        public required string Description { get; set; }
        public DateTime Showtime { get; set; }
        public required List<Ticket> Tickets { get; set; }
        public int totalTickets { get; set; }

    }
}
