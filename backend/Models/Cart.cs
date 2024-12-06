namespace TheCSharpers_QuikTix.Models
{
    public class Cart
    {
        public List<Ticket> Tickets { get; set; } = new List<Ticket>();
        public int TotalPrice { get; set; }

    }
}