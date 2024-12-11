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
        public Cart CreateCart(int cartId, List<Ticket> tickets)
        {
            var cart = new Cart
            {
                CartId = cartId,
                Tickets = tickets
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
            var cart = _context.Carts.Include(c => c.Tickets)
                                      .FirstOrDefault(c => c.CartId == cartId);
            if (cart == null)
            {
                throw new InvalidOperationException($"Cart with ID {cartId} not found.");
            }
            return cart;
        }

        // Update the quantity of tickets in the cart
        public void UpdateCart(int cartId, int newQuantity, decimal newPrice)
        {
            var cart = _context.Carts.FirstOrDefault(c => c.CartId == cartId);
            if (cart != null)
            {
                //cart.Quantity = newQuantity;
                //cart.Price = newPrice;
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
