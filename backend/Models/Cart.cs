namespace TheCSharpers_QuikTix.Models
{

    public class Cart
    {
        public int CartId {get; set; }

        // List of Tickets in the Cart
         public List<Ticket> Tickets { get; set; } = new List<Ticket>();

    }

}