using System.Collections.Generic;
using TheCSharpers_QuikTix.Models;

public interface ITicketService
{
    IEnumerable<Ticket> GetTickets(int movieId);
    Ticket GetTicketById(int id);
    Ticket CreateTicket(int showtimeId, string ticketType, decimal price);
    void AddTicket(int movieId, string ticketType, int quantity);
    void UpdateTicket(int id, Ticket updatedTicket, Movie movie);
    void DeleteTicket(int id);
    decimal GetTicketPrice(int id);

}