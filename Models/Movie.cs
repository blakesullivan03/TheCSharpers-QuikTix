namespace MovieApi.Models;
using System;
using System.Collections.Generic;

public class Movie
{
    public long MovieId { get; set; }
    public string Name { get; set; }
    public string Genre { get; set; }
    public string Description { get; set; }
    public List<long> Showtimes { get; set; }
    public List<long> Reviews { get; set; }
}