using Microsoft.AspNetCore.Mvc;
using TheCSharpers_QuikTix.Models;
using Microsoft.AspNetCore.Cors;
using TheCSharpers_QuikTix.Services;

namespace TheCSharpers_QuikTix.Controllers
{
    [EnableCors("AllowAll")]
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

        // POST: api/movies/add
        [HttpPost("add")]
        public IActionResult AddMovie([FromBody] Movie movie)
        {
            movie.Id = 0; // Ensure the Movie Id is Not Set
            _movieService.AddMovie(movie);
            return CreatedAtAction(nameof(GetMovies), new { id = movie.Id }, movie);
        }

        // PUT: api/movies/{id}
        [HttpPut("{id}")]
        public IActionResult UpdateMovie(int id, Movie updatedMovie)
        {
            _movieService.UpdateMovie(id, updatedMovie);
            return NoContent();
        }

        // DELETE: api/movies/{id}
        [HttpDelete("{id}")]
        public IActionResult DeleteMovie(int id)
        {
            var movie = _movieService.GetMovieById(id);
            if (movie == null)
            {
                return NotFound("Movie not found.");
            }

            _movieService.DeleteMovie(id);
            return NoContent();
        }

    }   
}
