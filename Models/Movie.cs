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

        public DateTime ReleaseDate { get; set; }

        public int TicketCount { get; set; } // Tracks tickets available for the movie
    }
}
