namespace MovieApi.Models;
using System;
using System.Collections.Generic;

public class Showtime
{
    public long ShowtimeId { get; set; }
    public long MovieId { get; set; }
    public string Time { get; set; }
    public List<long> Tickets { get; set; }
}