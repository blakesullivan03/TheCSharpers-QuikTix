using System;

namespace TheCSharpers_QuikTix.Models
{
    public class Movie
    {
        public int Id { get; set; }

        public required string Title { get; set; }

        public required string Genre { get; set; }

        public required string Description { get; set; }

        public double? Rating { get; set; } // Nullable to allow unrated movies

        public ICollection<Showtime>? Showtimes { get; set; }

    }
}
