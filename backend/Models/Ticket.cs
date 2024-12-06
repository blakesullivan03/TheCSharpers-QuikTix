namespace TheCSharpers_QuikTix.Models
{
    public class Ticket
    {
        public int Id { get; set; }
        public Movie Movie { get; set; }
        public int Quantity { get; set; } = 1;
        public float Price { get; set; }

        // Constructor
        public Ticket(int id, Movie movie, int quantity, float price)
        {
            Id = id;
            Movie = movie;
            Quantity = quantity;
            Price = price;
        }
    }
}