using Microsoft.AspNetCore.Mvc;
using TheCSharpers_QuikTix.Models;
using TheCSharpers_QuikTix.Services.Implementation;
using System.Collections.Generic;
using TheCSharpers_QuikTix.Services.Interfaces;

namespace TheCSharpers_QuikTix.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class ReviewController : ControllerBase
  {
    private readonly IReviewService _reviewService;
    private readonly IMovieService _movieService;

    public ReviewController(IReviewService reviewService, IMovieService movieService)
    {
      _reviewService = reviewService;
      _movieService = movieService;
    }

    [HttpPost]
    public IActionResult AddReview([FromBody] Review review, [FromQuery] int movieId)
    {
      var movie = _movieService.GetMovieById(movieId);
      _reviewService.AddReview(movie, review);
      return Ok();
    }

    [HttpDelete("{id}")]
    public IActionResult RemoveReview(int id)
    {
      _reviewService.RemoveReview(id);
      return Ok();
    }

    [HttpPut]
    public IActionResult EditReview([FromBody] Review review)
    {
      _reviewService.EditReview(review);
      return Ok();
    }

    [HttpGet("{movieId}")]
    public ActionResult<IEnumerable<Review>> GetReviews(int movieId)
    {
      var movie = _movieService.GetMovieById(movieId);
      var reviews = _reviewService.GetReviews(movie);
      return Ok(reviews);
    }
  }
}