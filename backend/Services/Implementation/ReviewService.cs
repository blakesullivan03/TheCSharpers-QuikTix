using TheCSharpers_QuikTix.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using TheCSharpers_QuikTix.Services.Interfaces;

namespace TheCSharpers_QuikTix.Services.Implementation
{
  public class ReviewService : IReviewService
  {
    private readonly QuikTixDbContext _context;

    public ReviewService(QuikTixDbContext context)
    {
      _context = context;
    }

    public void AddReview(Movie movie, Review review)
    {
      review.MovieId = movie.Id;
      _context.Reviews.Add(review);
      _context.SaveChanges();
    }

    public void RemoveReview(int id)
    {
      var review = _context.Reviews.Find(id);
      if (review != null)
      {
        _context.Reviews.Remove(review);
        _context.SaveChanges();
      }
    }

    public void EditReview(Review review)
    {
      var existingReview = _context.Reviews.Find(review.Id);
      if (existingReview != null)
      {
        existingReview.ReviewerName = review.ReviewerName;
        existingReview.Comment = review.Comment;
        existingReview.Rating = review.Rating;
        existingReview.MovieId = review.MovieId;
        _context.SaveChanges();
      }
    }

    public IEnumerable<Review> GetReviews(Movie movie)
    {
      return _context.Reviews
        .Where(r => r.MovieId == movie.Id)
        .ToList();
    }
  }
}