using Microsoft.EntityFrameworkCore;
using TheCSharpers_QuikTix.Models;
using System.Collections.Generic;
using System.Linq;

namespace TheCSharpers_QuikTix.Services
{
    public class TicketService : ITicketService
    {
        private readonly QuikTixDbContext _context;

        public TicketService(QuikTixDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Ticket> GetTickets()
        {
            return _context.Tickets.Include(t => t.Movie).ToList();
        }

        public Ticket GetTicketById(int id)
        {
            var ticket = _context.Tickets.Include(t => t.Movie).FirstOrDefault(t => t.Id == id);
            if (ticket == null)
            {
                throw new KeyNotFoundException($"Ticket with id {id} not found.");
            }
            return ticket;
        }

        public void AddTicket(Ticket ticket)
        {
            _context.Tickets.Add(ticket);
            _context.SaveChanges();
        }

        public void UpdateTicket(int id, Ticket updatedTicket)
        {
            var ticket = _context.Tickets.FirstOrDefault(t => t.Id == id);
            if (ticket != null)
            {
                ticket.Quantity = updatedTicket.Quantity;
                ticket.Price = updatedTicket.Price;
                ticket.TicketType = updatedTicket.TicketType;

                _context.SaveChanges();
            }
        }

        public void DeleteTicket(int id)
        {
            var ticket = _context.Tickets.FirstOrDefault(t => t.Id == id);
            if (ticket != null)
            {
                _context.Tickets.Remove(ticket);
                _context.SaveChanges();
            }
        }

        public IEnumerable<Ticket> GetTicketsByMovieId(int movieId)
        {
            return _context.Tickets.Where(t => t.MovieId == movieId).ToList();
        }
    }
}

