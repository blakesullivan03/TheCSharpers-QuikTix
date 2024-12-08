using Microsoft.AspNetCore.Mvc;
using TheCSharpers_QuikTix.Models;
using TheCSharpers_QuikTix.Services;

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
        public ActionResult<IEnumerable<Movie>> GetMovies([FromQuery] SortCriteria sortBy = SortCriteria.AtoZ)
        {
            var movies = _movieService.GetMovies(sortBy);
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

        // GET: api/movies/images
        [HttpGet("images")]
        public ActionResult<IEnumerable<string>> GetMovieImages()
        {
            var movies = _movieService.GetMovies().ToList();
            var imagePaths = movies.Select(m => m.ImagePath).ToList();
            return Ok(imagePaths);
        }

        // GET: api/movies/image/{id}
        [HttpGet("image/{id}")]
        public ActionResult<string> GetMovieImage(int id)
        {
            try
            {
                var movie = _movieService.GetMovieById(id);
                return Ok(movie.ImagePath);
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
        }
    }
}
