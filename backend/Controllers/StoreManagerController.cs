using Microsoft.AspNetCore.Mvc;
using TheCSharpers_QuikTix.Models;
using TheCSharpers_QuikTix.Services;
using Microsoft.AspNetCore.Cors;

namespace TheCSharpers_QuikTix.Controllers
{
    [EnableCors("AllowAll")]
    [Route("api/[controller]")]
    [ApiController]
    public class StoreManager : ControllerBase
    {
        private readonly IShowtimeService _showtimeService;

        public StoreManager(IShowtimeService showtimeService)
        {
            _showtimeService = showtimeService;
        }

        // POST: Add Tickets to Showtime
        [HttpPost("AddTicketsToMovieShowtime")]
        public IActionResult AddTicketsToShowtime(int movieId, int showtimeID, int adultTicketCount, int childTicketCount)
        {
            if (adultTicketCount < 0 || childTicketCount < 0)
                return BadRequest("Ticket counts cannot be negative.");

            // Retrieve the showtime instance by ID (assumes a GetShowtimeById method exists in the service)
            var showtime = _showtimeService.GetShowtimeById(movieId, showtimeID);
            if (showtime == null)
                return NotFound($"Showtime with ID {showtimeID} not found.");

            // Update The Ticket Counts
            showtime.AdultTicketCount += adultTicketCount;
            showtime.ChildTicketCount += childTicketCount;

            // Update the Showtime in the Database
            _showtimeService.UpdateShowtime(showtimeID, showtime);

            return Ok(new
            {
                MovieId = showtime.MovieId,
                ShowtimeId = showtime.Id,
                TotalAdultTickets = showtime.AdultTicketCount,
                TotalChildTickets = showtime.ChildTicketCount
            });
        }

        // DELETE: Remove Tickets from Showtime
        [HttpPost("RemoveTicketsFromMovieShowtime")]
        public IActionResult RemoveTicketsFromShowtime(int movieId, int showtimeID, int adultTicketCount, int childTicketCount)
        {
            if (adultTicketCount < 0 || childTicketCount < 0)
                return BadRequest("Ticket counts cannot be negative.");

            // Retrieve the showtime instance by ID (assumes a GetShowtimeById method exists in the service)
            var showtime = _showtimeService.GetShowtimeById(movieId, showtimeID);
            if (showtime == null)
                return NotFound($"Showtime with ID {showtimeID} not found.");

            // Update The Ticket Counts
            showtime.AdultTicketCount -= adultTicketCount;
            showtime.ChildTicketCount -= childTicketCount;

            // Update the Showtime in the Database
            _showtimeService.UpdateShowtime(showtimeID, showtime);

            return Ok(new
            {
                MovieId = showtime.MovieId,
                ShowtimeId = showtime.Id,
                TotalAdultTickets = showtime.AdultTicketCount,
                TotalChildTickets = showtime.ChildTicketCount
            });
        }


        /*PUT : Update Ticket Quantity for an Existing Showtime
        [HttpPut("update")]
        public IActionResult UpdateTickets([FromBody] List<Ticket> tickets)
        {
            _showtimeService.UpdateTickets(tickets);
            return NoContent();
        }*/


    }
}