using System;

namespace TheCSharpers_QuikTix.Models
{
    public enum SortCriteria
    {
        AtoZ,
        ZtoA,
        ReleaseDateAsc,
        ReleaseDateDesc,
        DurationAsc,
        DurationDesc,
        BestRated,
        Popular
    }
    public class Movie
    {
        public int Id { get; set; }

        public required string Title { get; set; }

        public required string Genre { get; set; }

        public required string Description { get; set; }

        public int Duration { get; set; }  // Duration in minutes

        public double? Rating { get; set; } // Nullable to allow unrated movies

        public required List<Showtime> Showtimes { get; set; } = new List<Showtime>(); // Updated from Showtime to Showtimes
            
    }
}
