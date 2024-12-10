namespace MovieApi.Models;
using System;
using System.Collections.Generic;

public class Ticket
{
    public long TicketId { get; set; }
    public long ShowtimeId { get; set; }
    public long MovieId { get; set; }
    public double Price { get; set; }

    public Ticket(long ticketId, long showtimeId, long movieId, double price)
    {
        TicketId = ticketId;
        ShowtimeId = showtimeId;
        MovieId = movieId;
        Price = price;
    }
}