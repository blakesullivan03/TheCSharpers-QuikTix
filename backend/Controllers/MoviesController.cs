using Microsoft.AspNetCore.Mvc;
using TheCSharpers_QuikTix.Models;
using TheCSharpers_QuikTix.Services.Interfaces;

namespace TheCSharpers_QuikTix.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly IMovieService _movieService;

        public MoviesController(IMovieService movieService)
        {
            _movieService = movieService;
        }

        // GET: api/movies/get
        [HttpGet("get")]
        public ActionResult<IEnumerable<Movie>> GetMovies()
        {
            var movies = _movieService.GetMovies();
            return Ok(movies);
        }

        // GET: api/movies/{id}
        [HttpGet("{id}")]
        public ActionResult<Movie> GetMovieById(int id)
        {
            try
            {
                var movie = _movieService.GetMovieById(id);
                return Ok(movie);
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
        }
    }
}
