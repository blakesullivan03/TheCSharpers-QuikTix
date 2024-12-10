using TheCSharpers_QuikTix.Models;
using System.Collections.Generic;

namespace TheCSharpers_QuikTix.Services.Interfaces
{
  public interface IReviewService
  {
    void AddReview(Movie movie, Review review);
    void RemoveReview(int id);
    void EditReview(Review review, int id);
    IEnumerable<Review> GetReviews(Movie movie);
  }
}