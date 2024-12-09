// Review Class - Tracks Reviews for a Movie
namespace TheCSharpers_QuikTix.Models{
    public class Review
    {
        public string? ReviewerName { get; set; }
        public string? Comment { get; set; }
        public int Rating { get; set; } // 1-5 scale
    }

}