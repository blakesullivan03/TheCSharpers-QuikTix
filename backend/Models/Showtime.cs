using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
namespace TheCSharpers_QuikTix.Models
{
    public class Showtime
    {
        public int Id { get; set; }
        public DateTime StartTime { get; set; }
        public int MovieId { get; set; }
        public Movie? Movie { get; set; }
        public int AdultTicketCount { get; set; }
        public int ChildTicketCount { get; set; }
    }

}