using System;

namespace TheCSharpers_QuikTix.Models
{
    public class Movie
    {
        public int Id { get; set; }

        public required string Title { get; set; } // Updated from Name to Title

        public required string Genre { get; set; }

        public required string Description { get; set; }

        public double? Rating { get; set; } // Nullable to allow unrated movies

        public required List<Review> Reviews { get; set; } = new List<Review>(); // Updated from Review to Reviews

        public required List<Showtime> Showtimes { get; set; } = new List<Showtime>(); // Updated from Showtime to Showtimes
            
    }
}
