using System;
using TheCSharpers_QuikTix.Services;
using TheCSharpers_QuikTix.Models;

namespace TheCSharpers_QuikTix.Pages
{
    // Welcome Page
    public class WelcomePage
    {
        public MovieService _movieService;

        public WelcomePage(MovieService movieService)
        {
            _movieService = movieService;
        }

        // Display all movies with name, genre, and description
        public void DisplayMovies()
        {
            var movies = _movieService.GetAllMovies();
            Console.WriteLine("Welcome to QuikTix!");
            Console.WriteLine();
            Console.WriteLine("Available Movies:");
            foreach (var movie in movies)
            {
                Console.WriteLine($"- {movie.Name} ({movie.Genre})");
                Console.WriteLine($"  Description: {movie.Description}");
                Console.WriteLine($"  Showtime: {movie.Showtime}");
                Console.WriteLine($"  Tickets Available: {movie.TicketsAvailable}\n");
            }
        }
    }
}
