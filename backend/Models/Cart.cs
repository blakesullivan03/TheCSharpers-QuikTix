namespace TheCSharpers_QuikTix.Models
{

    public class Cart
    {
        public int CartId {get; set; }
        public int MovieId { get; set; }
        public string? MovieTitle { get; set; }
        public string? TicketType { get; set; } // Adult, Child
        public int Quantity { get; set; }
        public decimal Price { get; set; }

        // List of Tickets in the Cart
         public List<Ticket> Tickets { get; set; } = new List<Ticket>();

    }

}