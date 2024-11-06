using TheCSharpers_QuikTix.Models;

public class Movie
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Genre { get; set; }
    public string Description { get; set; }
    public DateTime Showtime { get; set; }
    public List<Ticket> Tickets { get; set; }
    public int totalTickets { get; set; }

    // Constructor
    public Movie(int id, string name, string genre, string description, DateTime showtime, int totalTickets)
    {
        Id = id;
        Name = name; 
        Genre = genre;
        Description = description;
        Showtime = showtime;
        Tickets = InitializeTickets(totalTickets);
    }

    // Initialize tickets with unique IDs
    private List<Ticket> InitializeTickets(int totalTickets)
    {
        var tickets = new List<Ticket>();
        for (int i = 0; i < totalTickets; i++)
        {
            tickets.Add(new Ticket(i, this, 1, 10.0f));
        }
        return tickets;
    }

    public int TicketsAvailable => Tickets.Count;
}
