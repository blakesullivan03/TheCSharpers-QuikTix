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

        public Ticket CreateTicket(int showtimeId, string ticketType, decimal price, int cartId)
        {
            var ticket = new Ticket
            {
                ShowtimeId = showtimeId,
                TicketType = ticketType,
                Price = price,
                CartId = cartId
            };

            _context.Tickets.Add(ticket);
            _context.SaveChanges();
            return ticket;
        }

        // Add a new ticket
        public void AddTicket(int movieId, string ticketType, int quantity)
        {
            // You could validate if the movie exists
            var movie = _context.Movies.FirstOrDefault(m => m.Id == movieId);
            if (movie == null)
            {
                throw new Exception($"Movie with ID {movieId} not found.");
            }

            for (int i = 0; i < quantity; i++)
            {
                var ticket = new Ticket
                {
                    MovieId = movieId,
                    TicketType = ticketType,
                    Price = GetTicketPrice(movieId), // Assuming you have logic to calculate price
                    PurchaseTime = DateTime.Now
                };

                _context.Tickets.Add(ticket);
            }
            _context.SaveChanges();
        }

        // Get all tickets for a movie
        public IEnumerable<Ticket> GetTickets(int movieId)
        {
            return _context.Tickets.Where(t => t.MovieId == movieId).ToList();
        }

        // Get ticket by ID
        public Ticket GetTicketById(int id)
        {
            var ticket = _context.Tickets.Include(t => t.Movie)
                                          .FirstOrDefault(t => t.Id == id);
            if (ticket == null)
            {
                throw new Exception($"Ticket with ID {id} not found.");
            }
            return ticket;
        }

        // Update a ticket (e.g., changing ticket type or price)
        public void UpdateTicket(int id, Ticket updatedTicket, Movie movie)
        {
            var ticket = _context.Tickets.FirstOrDefault(t => t.Id == id);
            if (ticket != null)
            {
                ticket.TicketType = updatedTicket.TicketType;
                ticket.Price = updatedTicket.Price;
                ticket.MovieId = movie.Id; // Update related movie if needed
                _context.SaveChanges();
            }
        }

        // Delete a ticket
        public void DeleteTicket(int id)
        {
            var ticket = _context.Tickets.FirstOrDefault(t => t.Id == id);
            if (ticket != null)
            {
                _context.Tickets.Remove(ticket);
                _context.SaveChanges();
            }
        }

        // Get the ticket price (e.g., from a static pricing rule or a dynamic source)
        public decimal GetTicketPrice(int movieId)
        {
            // Implement pricing logic (e.g., based on movie type, time of day, etc.)
            var movie = _context.Movies.FirstOrDefault(m => m.Id == movieId);
            if (movie == null)
            {
                throw new Exception($"Movie with ID {movieId} not found.");
            }

            // Example: Fixed price for all movies
            return 12.99m; // Example price, replace with actual logic
        }
    }
}
