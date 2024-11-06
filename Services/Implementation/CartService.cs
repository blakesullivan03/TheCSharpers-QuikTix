using TheCSharpers_QuikTix.Models;

public class CartService
{
    public Cart Cart { get; set; } = new Cart();

    public Cart GetCart()
    {
        if (Cart.Tickets.Count == 0)
        {
            Console.WriteLine("Your cart is empty.");
        }
        else
        {
            Console.WriteLine();
            Console.WriteLine("Your Cart:");

            var movieName = Cart.Tickets.First().Movie.Name;
            Console.WriteLine($"Movie: {movieName}");

            var totalTicketsInCart = Cart.Tickets.Count;
            Console.WriteLine($"Quantity: {totalTicketsInCart}");

            var ticketPrice = Cart.Tickets.First().Price;
            Console.WriteLine($"Price Per Ticket: {ticketPrice}");

            var totalAmount = Cart.Tickets.Sum(t => t.Quantity * t.Price);
            Console.WriteLine($"Total Amount: {totalAmount}");
            Console.WriteLine();
        }
        return Cart;
    }

    public void ClearCart()
    {
        Cart.Tickets.Clear();
    }

public void AddTicketToCart(Movie movie, int quantity)
{
    // Check if enough tickets are available
    if (movie.TicketsAvailable < quantity)
    {
        Console.WriteLine("Not enough tickets available.");
        return;
    }

    // Select tickets to add and remove them from the movie's available tickets
    var ticketsToAdd = movie.Tickets.Take(quantity).ToList();
    foreach (var ticket in ticketsToAdd)
    {
        Cart.Tickets.Add(ticket);
        movie.Tickets.Remove(ticket);  // Remove ticket from available tickets
        
    }

    Console.WriteLine($"{quantity} tickets added to the cart for {movie.Name}.");
}


    public void RemoveTicketFromCart(Movie movie)
    {
        var ticket = Cart.Tickets.FirstOrDefault(t => t.Movie.Id == movie.Id);
        if (ticket != null)
        {
            Cart.Tickets.Remove(ticket);
            movie.Tickets.Add(ticket); // Return ticket to available list
            Console.WriteLine("Ticket removed from cart and returned to available tickets.");
        }
    }
}
