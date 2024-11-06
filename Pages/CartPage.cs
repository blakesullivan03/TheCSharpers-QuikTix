using System;
using System.Linq;
using TheCSharpers_QuikTix.Services;
using TheCSharpers_QuikTix.Models;

namespace TheCSharpers_QuikTix.Pages
{
    // Cart Page
    public class CartPage
    {
        private readonly CartService _cartService;

        public CartPage(CartService cartService)
        {
            _cartService = cartService;
        }

        // Display the cart with items, quantities, and total cost
        public void DisplayCart()
        {
            var cart = _cartService.GetCart();
        
            Console.WriteLine("Do you want to remove any tickets from your cart? (y/n)");
            string input = Console.ReadLine() ?? string.Empty;
            if (input != null && input.ToLower() == "y")
            {
                Console.WriteLine("Enter the name of the movie to remove:");
                string? movieNameInput = Console.ReadLine();
                string movieName = movieNameInput ?? string.Empty;
                var movie = cart.Tickets.FirstOrDefault(t => t.Movie.Name == movieName)?.Movie;
                if (movie != null)
                {
                    _cartService.RemoveTicketFromCart(movie);
                    Console.WriteLine("Tickets removed from cart.");
                }
                else
                {
                    Console.WriteLine("Movie not found in cart.");
                }
            }
        }
    }
}
