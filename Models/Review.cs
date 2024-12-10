namespace MovieApi.Models;
using System;
using System.Collections.Generic;

public class Review
{
    public long ReviewId { get; set; }
    public long MovieId { get; set; }
    public long Score { get; set; }
}