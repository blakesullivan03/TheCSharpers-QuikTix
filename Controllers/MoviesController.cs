using Microsoft.AspNetCore.Mvc;
using TheCSharpers_QuikTix.Models;


namespace TheCSharpers_QuikTix.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MoviesController : ControllerBase
    {
        private readonly IMovieService _movieService;

        public MoviesController(IMovieService movieService)
        {
            _movieService = movieService;
        }

        [HttpGet("{id}")]
        public ActionResult<Movie> GetMovieById(int id)
        {
            var movie = _movieService.GetMovieById(id);
            if (movie == null)
                return NotFound();
            
            return Ok(movie);
        }


        [HttpGet("get")]
        public IActionResult GetAllMovies()
        {
            var movies = _movieService.GetMovies();
            return Ok(movies);
        }

        [HttpPost("add")]
        public IActionResult AddMovie([FromBody] Movie movie)
        {
            movie.Id = 0; //Make Sure ID is not Set Explicitly
            _movieService.AddMovie(movie);
            return CreatedAtAction(nameof(GetAllMovies), new { id = movie.Id }, movie);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateMovie(int id, Movie updatedMovie)
        {
            _movieService.UpdateMovie(id, updatedMovie);
            return NoContent();
        }

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
