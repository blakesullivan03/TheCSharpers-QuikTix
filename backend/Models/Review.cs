// Review Class - Tracks Reviews for a Movie
namespace TheCSharpers_QuikTix.Models{
    public class Review
    {
        public int Id { get; set; } // Unique ID for the review

        public string? Author { get; set; } // Name of the reviewer

        public string? UserReview { get; set; } // Review content

        public int Rating { get; set; } // Rating given by the reviewer (out of 5)
    }
}