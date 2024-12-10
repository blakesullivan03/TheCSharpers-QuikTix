namespace MovieApi.Models;
using System;
using System.Collections.Generic;

public class Cart
{
    public long CartId { get; set; }
    public List<long> Tickets { get; set; }
}