using Microsoft.EntityFrameworkCore;
using TheCSharpers_QuikTix.Models;
using System.Collections.Generic;
using System.Linq;

namespace TheCSharpers_QuikTix.Services.Implementation
{
    public class ShowtimeService : IShowtimeService
    {
        private readonly QuikTixDbContext _context;

        public ShowtimeService(QuikTixDbContext context)
        {
            _context = context;
        }

        // Add a new showtime associated with a movie using movieId
        public Showtime AddShowtime(Showtime showtime)
        {
            _context.Showtimes.Add(showtime);
            _context.SaveChanges();
            if (showtime == null)
            {
                throw new KeyNotFoundException($"Showtime is null");
            }
            return showtime;
        }

        // Get all showtimes for a specific movieId
        public IEnumerable<Showtime> GetAllShowtimes(int movieId)
        {
            // Filter showtimes by the movieId
            return _context.Showtimes.Where(s => s.MovieId == movieId).ToList();
        }

        /*Get a showtime by its Id (including Movie if needed)
        public Showtime GetShowtimeById(int id)
        {
            var showtime = _context.Showtimes.Include(s => s.Movie)  // If you still need Movie details
                                              .FirstOrDefault(s => s.Id == id);
            if (showtime == null)
            {
                throw new KeyNotFoundException($"Showtime with Id {id} not found.");
            }
            return showtime;
        }*/

        // Update an existing showtime
        public Showtime UpdateShowtime(int id, Showtime updatedShowtime)
        {
            var showtime = _context.Showtimes.Find(id);
            if (showtime != null)
            {
                showtime.StartTime = updatedShowtime.StartTime;
                showtime.AdultTicketCount = updatedShowtime.AdultTicketCount;
                showtime.ChildTicketCount = updatedShowtime.ChildTicketCount;

                _context.SaveChanges();
            }
            if (showtime == null)
            {
                throw new KeyNotFoundException($"Showtime is null");
            }
            return showtime;
        }

        // Delete a showtime
        public bool DeleteShowtime(int id)
        {
            var showtime = _context.Showtimes.Find(id);
            if (showtime != null)
            {
                _context.Showtimes.Remove(showtime);
                _context.SaveChanges();
                return true;
            }
            return false;
        }
    }
}
