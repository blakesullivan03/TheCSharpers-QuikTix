using Microsoft.AspNetCore.Mvc;
using TheCSharpers_QuikTix.Models;
using TheCSharpers_QuikTix.Services;
using System.Collections.Generic;

namespace TheCSharpers_QuikTix.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StoreManager : ControllerBase
    {
        private readonly ITicketService _ticketService;

        public StoreManager(ITicketService ticketService)
        {
            _ticketService = ticketService;
        }

        /* GET: api/ticket/{id}
        [HttpGet("{id}")]
        public ActionResult<Ticket> GetTicketById(int id)
        {
            try
            {
                var ticket = _ticketService.GetTicketById(id);
                return Ok(ticket);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }*/

        // GET: api/ticket/movie/{movieId}
        /*[HttpGet("movie/{movieId}")]
        public ActionResult<IEnumerable<Ticket>> GetTicketsByMovieId(int movieId)
        {
            var tickets = _ticketService.GetTicketByMovieId(movieId);
            return Ok(tickets);
        }*/

        // POST: api/ticket
        /*[HttpPost]
        public ActionResult AddTicket([FromBody] Ticket ticket)
        {
            if (ticket == null)
            {
                return BadRequest("Ticket data is required.");
            }

            _ticketService.AddTicket(ticket.MovieId, ticket.TicketType, ticket.Quantity);
        }*/

        // PUT: api/ticket/{id}
        [HttpPut("{id}")]
        public ActionResult UpdateTicket(int id, [FromBody] Ticket updatedTicket)
        {
            if (updatedTicket == null)
            {
                return BadRequest("Updated ticket data is required.");
            }

            try
            {
                //_ticketService.UpdateTicket(id, updatedTicket);
                return NoContent();  // 204 No Content
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        // DELETE: api/ticket/{id}
        [HttpDelete("{id}")]
        public ActionResult DeleteTicket(int id)
        {
            try
            {
                _ticketService.DeleteTicket(id);
                return NoContent();  // 204 No Content
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
