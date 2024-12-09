using TheCSharpers_QuikTix.Models;
using Microsoft.EntityFrameworkCore;

namespace TheCSharpers_QuikTix.Services
{
    public class CartService : ICartService
    {
        private readonly QuikTixDbContext _context;

        public CartService(QuikTixDbContext context)
        {
            _context = context;
        }

        // Create a new cart for a user or movie
        public Cart CreateCart(int movieId, string movieTitle, string ticketType, int quantity, decimal price)
        {
            var cart = new Cart
            {
                MovieId = movieId,
                MovieTitle = movieTitle,
                TicketType = ticketType,
                Quantity = quantity,
                Price = price
            };

            _context.Carts.Add(cart);
            _context.SaveChanges();
            return cart;
        }

        // Add a ticket to an existing cart
        public void AddTicketToCart(int cartId, Ticket ticket)
        {
            var cart = _context.Carts.Include(c => c.Tickets).FirstOrDefault(c => c.CartId == cartId);
            if (cart != null)
            {
                cart.Tickets.Add(ticket);
                _context.SaveChanges();
            }
        }

        // Get the cart by ID
        public Cart GetCart(int cartId)
        {
            return _context.Carts.Include(c => c.Tickets)
                                 .FirstOrDefault(c => c.CartId == cartId);
        }

        // Update the quantity of tickets in the cart
        public void UpdateCart(int cartId, int newQuantity, decimal newPrice)
        {
            var cart = _context.Carts.FirstOrDefault(c => c.CartId == cartId);
            if (cart != null)
            {
                cart.Quantity = newQuantity;
                cart.Price = newPrice;
                _context.SaveChanges();
            }
        }

        // Delete the cart
        public void DeleteCart(int cartId)
        {
            var cart = _context.Carts.Include(c => c.Tickets).FirstOrDefault(c => c.CartId == cartId);
            if (cart != null)
            {
                _context.Carts.Remove(cart);
                _context.SaveChanges();
            }
        }
    }
}
