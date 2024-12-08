namespace TheCSharpers_QuikTix.Models
{
    public class Review
    {
        public int Id { get; set; }
        public int MovieId { get; set; }
        public string? UserReview { get; set; }
        public int Rating { get; set; }
    }
}