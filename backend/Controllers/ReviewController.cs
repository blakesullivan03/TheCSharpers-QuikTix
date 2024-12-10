using Microsoft.AspNetCore.Mvc;
using TheCSharpers_QuikTix.Models;
using TheCSharpers_QuikTix.Services.Implementation;
using System.Collections.Generic;

namespace TheCSharpers_QuikTix.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class ReviewController : ControllerBase
  {
    private readonly ReviewService _reviewService;
    private readonly MovieService _movieService;

    public ReviewController(ReviewService reviewService, MovieService movieService)
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