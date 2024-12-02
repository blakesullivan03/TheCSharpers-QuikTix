using System.Collections.Generic;
using TheCSharpers_QuikTix.Models;

public interface ITicketService
{
    IEnumerable<Ticket> GetTickets();
    Ticket GetTicketById(int id);
    void AddTicket(Ticket ticket);
    void UpdateTicket(int id, Ticket updatedTicket);
    void DeleteTicket(int id);
    IEnumerable<Ticket> GetTicketsByMovieId(int movieId);  // Optional: to get all tickets for a specific movie

}
