// Service that Handles adding, deleting, and updating Movies
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
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
        return _context.Movies.ToList();
    }

    /*public IEnumerable<Review> GetReviewsForMovie(int movieId)
    {
        var movie = _context.Movies.Find(movieId);
        if (movie == null)
        {
            throw new KeyNotFoundException($"Movie with id {movieId} not found.");
        }
        return movie.Reviews;
    }*/

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
}
