using System;
using TheCSharpers_QuikTix.Services;
using TheCSharpers_QuikTix.Models;

namespace TheCSharpers_QuikTix.Pages
{
    // Movie Listing Page
    public class MovieListingPage
    {
        private readonly MovieService _movieService;
        private readonly CartService _cartService;

        public MovieListingPage(MovieService movieService, CartService cartService)
        {
            _movieService = movieService;
            _cartService = cartService;
        }

        // Display detailed information about a movie and option to add tickets to the cart
        public void DisplayMovieDetails(int movieId)
        {
            var movie = _movieService.GetMovieById(movieId);
            if (movie == null)
            {
                Console.WriteLine("Movie not found.");
                return;
            }

            Console.WriteLine($"Movie: {movie.Name}");
            Console.WriteLine($"Genre: {movie.Genre}");
            Console.WriteLine($"Description: {movie.Description}");
            Console.WriteLine($"Showtime: {movie.Showtime}");
            Console.WriteLine($"Tickets Available: {movie.TicketsAvailable}");

            Console.WriteLine("Would you like to add tickets to your cart? (y/n)");
            string input = Console.ReadLine() ?? string.Empty;
            if (input.ToLower() == "y")
            {
                Console.WriteLine("How many tickets would you like?");
                string quantityString = Console.ReadLine() ?? string.Empty;
                int quantity = Convert.ToInt32(quantityString);
                if (quantity > 0 && quantity <= movie.TicketsAvailable)
                {
                    Console.WriteLine($"Adding tickets to Cart for {movie.Name}");
                    _cartService.AddTicketToCart(movie, quantity);  // Example ticket price
                    Console.WriteLine("Tickets added to cart.");
                }
                else
                {
                    Console.WriteLine("Invalid quantity.");
                }
            }
        }
    }
}