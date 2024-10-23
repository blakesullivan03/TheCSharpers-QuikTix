namespace TheCSharpers_QuikTix.Models
{
    public class Movie
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public string Genre { get; set; }
        public string Description { get; set; }
        public DateTime Showtime { get; set; }
        public List<Ticket> Tickets { get; set; } = new List<Ticket>();


        // Default Constructor
        public Movie(int id, string name, string genre, string description, DateTime showtime, int ticketsAvailable)
        {
            Id = id;
            Name = name; 
            Genre = genre;
            Description = description;
            Showtime = showtime;
            ticketsAvailable = TicketsAvailable;
        }
        
        // Determine Tickets Available
        public int TicketsAvailable
        {
            get
            {
                int totalTickets = 100;
                foreach (var ticket in Tickets)
                {
                    totalTickets -= ticket.Quantity;
                }
                return totalTickets;
            }
        }
    }
}