using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using Microsoft.EntityFrameworkCore;
using TheCSharpers_QuikTix.Models;
using TheCSharpers_QuikTix.Data;
using TheCSharpers_QuikTix.Services;

namespace TheCSharpers_QuikTix.Services
{
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

        public IEnumerable<Movie> GetMovies(SortCriteria sortBy)
        {
            switch (sortBy)
            {
                case SortCriteria.AtoZ:
                    return _context.Movies.OrderBy(m => m.Title);
                case SortCriteria.ZtoA:
                    return _context.Movies.OrderByDescending(m => m.Title);
                case SortCriteria.ReleaseDateAsc:
                    return _context.Movies.OrderBy(m => m.ReleaseDate);
                case SortCriteria.ReleaseDateDesc:
                    return _context.Movies.OrderByDescending(m => m.ReleaseDate);
                case SortCriteria.DurationAsc:
                    return _context.Movies.OrderBy(m => m.Duration);
                case SortCriteria.DurationDesc:
                    return _context.Movies.OrderByDescending(m => m.Duration);
                case SortCriteria.BestRated:
                    return _context.Movies.OrderByDescending(m => m.Rating);
                case SortCriteria.Popular:
                    return _context.Movies.OrderBy(m => m.TicketCount);
                default:
                    return _context.Movies;  // Default to no sorting
            }
        }

        // Get a movie by its ID
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

        // Delete a movie by its ID
        public void DeleteMovie(int id)
        {
            var movie = _context.Movies.Where(m => m.Id == id).FirstOrDefault();
            if (movie == null)
            {
                throw new KeyNotFoundException($"Movie with id {id} not found.");
            }

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

        var showtime = movie.Showtimes.FirstOrDefault(s => s.Id == showtimeId);

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

    /*public void AddReviewForMovie(int movieId, Review review)
    {
        var movie = _context.Movies.Find(movieId);
        if (movie == null)
        {
            throw new KeyNotFoundException($"Movie with id {movieId} not found.");
        }
        movie.Reviews.Add(review);
        _context.SaveChanges();
    }*/
}
