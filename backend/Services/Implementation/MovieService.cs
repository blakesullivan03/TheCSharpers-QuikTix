// Service that Handles adding, deleting, and updating Movies
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using Microsoft.EntityFrameworkCore;
using TheCSharpers_QuikTix.Models;

public class MovieService : IMovieService
{
    private readonly QuikTixDbContext _context;

    public MovieService(QuikTixDbContext context)
    {
        _context = context;
    }

    public IEnumerable<Movie> GetMovies()
    {
        return _context.Movies.Include(m => m.Showtimes).ToList();
    }

    public Movie GetMovieById(int id)
    {
        var movie = _context.Movies.FirstOrDefault(m => m.Id == id);
        if (movie == null)
        {
            throw new KeyNotFoundException($"Movie with id {id} not found.");
        }
        return movie;
    }

    public void AddMovie(Movie movie)
    {
        _context.Movies.Add(movie);
        _context.SaveChanges();
    }

    public void UpdateMovie(int id, Movie updatedMovie)
    {
        var movie = _context.Movies.Find(id);
        if (movie != null)
        {
            movie.Title = updatedMovie.Title;
            movie.Genre = updatedMovie.Genre;
            movie.Description = updatedMovie.Description;
            _context.SaveChanges();
        }
    }

    public void DeleteMovie(int id)
    {
        var movie = _context.Movies.Find(id);
        if (movie != null)
        {
            _context.Movies.Remove(movie);
            _context.SaveChanges();
        }
    }

    // Book tickets for a showtime
    public void BookTickets(int movieId, int showtimeId, int adultTickets, int childTickets)
    {
        var movie = _context.Movies.FirstOrDefault(m => m.Id == movieId);

        if (movie == null)
        {
            throw new KeyNotFoundException($"Movie with id {movieId} not found.");
        }

        var showtime = _context.Showtimes.FirstOrDefault(s => s.MovieId == movieId);

        if (showtime == null)
        {
            throw new KeyNotFoundException($"Showtime with id {showtimeId} not found.");
        }

        // Validate ticket availability
        if (showtime.AdultTicketCount < adultTickets || showtime.ChildTicketCount < childTickets)
        {
            throw new InvalidOperationException("Not enough tickets available.");
        }

        // Deduct tickets
        showtime.AdultTicketCount -= adultTickets;
        showtime.ChildTicketCount -= childTickets;

        _context.SaveChanges();
    }

    public void AddTicketsToMovie(int movieId, int numberOfTickets)
    {
        var movie = _context.Movies.Find(movieId);

        for (int i = 0; i < numberOfTickets; i++)
        {
            Ticket tick = new Ticket();
            tick.MovieId = movieId;
            _context.Tickets.Add(tick);
        }

        _context.SaveChanges();
    }

    public void RemoveTicketsFromMovie(int movieId, int numberOfTickets)
    {
        var movie = _context.Movies.Find(movieId);

        for (int i = 0; i < numberOfTickets; i++)
        {
            var ticket = _context.Tickets.FirstOrDefault(t => t.MovieId == movieId);
            if (ticket != null)
            {
                _context.Tickets.Remove(ticket);
            }
        }

        _context.SaveChanges();
    }
}
