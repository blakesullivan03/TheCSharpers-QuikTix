/*using System;
using System.Linq;
using TheCSharpers_QuikTix.Services;
using TheCSharpers_QuikTix.Models;
using System.Collections.Generic;

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

        // Display sorted movies based on user choice
        public void DisplayMovies()
        {
            Console.WriteLine("Welcome to QuikTix!");
            Console.WriteLine();
            Console.WriteLine("Enter 'a' to view movies alphabetically, 's' to view soonest showtime, 't' for latest showtime:");
            var choice = Console.ReadLine()?.ToLower();

            var movies = _movieService.GetAllMovies();

            // Sorting based on user choice
            movies = choice switch
            {
                "a" => movies.OrderBy(m => m.Name).ToList(),
                "s" => movies.OrderBy(m => m.Showtime).ToList(),
                "t" => movies.OrderByDescending(m => m.Showtime).ToList(),
                _ => movies // Default if input is invalid
            };

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
}*/
