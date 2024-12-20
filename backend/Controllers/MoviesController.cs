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
        [HttpGet("GetMovies")]
        public ActionResult<IEnumerable<Movie>> GetMovies()
        {
            var movies = _movieService.GetMovies();
            return Ok(movies);
        }

        // GET: api/movies/GetMovieBy/{id}
        [HttpGet("GetMovieBy/{id}")]
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

        // POST: api/movies/AddMovie
        [HttpPost("AddMovie")]
        public IActionResult AddMovie([FromBody] Movie movie)
        {
            movie.Id = 0; // Ensure the Movie Id is Not Set
            _movieService.AddMovie(movie);
            return CreatedAtAction(nameof(GetMovies), new { id = movie.Id }, movie);
        }

        // PUT: api/movies/EditMovie/{id}
        [HttpPut("EditMovie/{id}")]
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

        /* GET : Get All Tickets for a Movie
        [HttpGet("{id}/tickets")]
        public ActionResult<IEnumerable<Ticket>> GetTicketsForMovie(int id)
        {
            var tickets = _movieService.GetTicketsForMovie(id);
            return Ok(tickets);
        }*/


    }   
}
