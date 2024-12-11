using TheCSharpers_QuikTix.Models;
using System.Collections.Generic;

namespace TheCSharpers_QuikTix.Services
{
    public interface IShowtimeService
    {
        Showtime AddShowtime(Showtime showtime);
        IEnumerable<Showtime> GetAllShowtimes(int movieId);
        Showtime GetShowtimeById(int movieId, int id);
        Showtime UpdateShowtime(int id, Showtime updatedShowtime);
        bool DeleteShowtime(int id);
    }
}
