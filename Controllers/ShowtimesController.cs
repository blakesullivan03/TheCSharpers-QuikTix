using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MovieApi.Models;

namespace MovieApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShowtimesController : ControllerBase
    {
        private readonly MovieContext _context;

        public ShowtimesController(MovieContext context)
        {
            _context = context;
        }

        // GET: api/Showtimes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Showtime>>> GetShowtimes()
        {
            return await _context.Showtimes.ToListAsync();
        }

        // GET: api/Showtimes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Showtime>> GetShowtime(long id)
        {
            var showtime = await _context.Showtimes.FindAsync(id);

            if (showtime == null)
            {
                return NotFound();
            }

            return showtime;
        }

        // PUT: api/Showtimes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutShowtime(long id, Showtime showtime)
        {
            if (id != showtime.ShowtimeId)
            {
                return BadRequest();
            }

            _context.Entry(showtime).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ShowtimeExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // PUT: api/Showtimes/AddTicketsToMovie/5/3
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("AddTicketsToMovie/{id}/quantity")]
        public async Task<IActionResult> PutShowtime(long id, Showtime showtime, long quantity)
        {
            if (id != showtime.ShowtimeId)
            {
                return BadRequest();
            }

            List<Ticket> tickets = await _context.Tickets.ToListAsync();
            Ticket lastTicket = tickets.LastOrDefault();
            Console.WriteLine(lastTicket);
            long lastTicketId = 0;

            if (lastTicket != null) {
                lastTicketId = lastTicket.TicketId;
            }

            Console.WriteLine(lastTicketId);

            List<long> newTicketIds = new List<long>();

            for (long i = lastTicketId + 1; i < lastTicketId + 1 + quantity; i++) {
                Ticket newTicket = new Ticket(i, showtime.ShowtimeId, showtime.MovieId, 7.50);
                _context.Tickets.Add(newTicket);
                newTicketIds.Add(i);
            }

            showtime.Tickets.AddRange(newTicketIds);

            _context.Entry(showtime).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ShowtimeExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        [HttpPut("RemoveTicketsFromMovie/{id}/quantity")]
        public async Task<IActionResult> PutShowtimeRemove(long id, Showtime showtime, int quantity)
        {
            if (id != showtime.ShowtimeId)
            {
                return BadRequest();
            }

            
            showtime.Tickets.RemoveRange(0, quantity);

            // TODO - Remove corresponding tickets in Tickets table

            _context.Entry(showtime).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ShowtimeExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Showtimes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Showtime>> PostShowtime(Showtime showtime)
        {
            _context.Showtimes.Add(showtime);

            foreach (long ticketId in showtime.Tickets) {
                Ticket newTicket = new Ticket(ticketId, showtime.ShowtimeId, showtime.MovieId, 7.50);
                _context.Tickets.Add(newTicket);
            }

            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetShowtime), new { id = showtime.ShowtimeId }, showtime);
        }

        // DELETE: api/Showtimes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteShowtime(long id)
        {
            var showtime = await _context.Showtimes.FindAsync(id);
            if (showtime == null)
            {
                return NotFound();
            }

            _context.Showtimes.Remove(showtime);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ShowtimeExists(long id)
        {
            return _context.Showtimes.Any(e => e.ShowtimeId == id);
        }
    }
}
