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

        public IEnumerable<Ticket> GetTickets(int movieId)
        {
            return _context.Tickets.Where(t => t.MovieId == movieId).ToList();
        }

        public void AddTicket(int movieId, string ticketType, int quantity)
        {
            var movie = _context.Movies.FirstOrDefault(m => m.Id == movieId);
            if (movie == null)
            {
                throw new Exception("Movie not found.");
            }

            var ticket = _context.Tickets.FirstOrDefault(t => t.MovieId == movieId && t.TicketType == ticketType);
            if (ticket == null)
            {
                throw new Exception("Ticket type not found for the movie.");
            }

            // Add the ticket to the cart
            var cartItem = new Cart
            {
                MovieId = movieId,
                TicketType = ticketType,
                Quantity = quantity,
                Price = ticket.Price * quantity
            };
            _context.Cart.Add(cartItem);

            // Update ticket availability
            movie.TicketCount -= quantity;

            _context.SaveChanges();
        }

        public void UpdateTicket(int id, Ticket updatedTicket, Movie movie)
        {
            var ticket = _context.Tickets.FirstOrDefault(t => t.Id == id);
            if (ticket != null)
            {
                movie.TicketCount = movie.TicketCount;
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

        public decimal GetTicketPrice(int id)
        {
            var ticket = _context.Tickets.FirstOrDefault(t => t.Id == id);
            if (ticket != null)
            {
                return ticket.Price;
            }
            return 0;
        }

    }
}

