using System;
using System.Collections.Generic;
using System.Linq;
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

        // Get all movies from the database
        public IEnumerable<Movie> GetMovies()
        {
            return _context.Movies.ToList();
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

        // Add a new movie to the database
        public void AddMovie(Movie movie)
        {
            if (movie == null)
            {
                throw new ArgumentNullException(nameof(movie), "Movie cannot be null.");
            }

            _context.Movies.Add(movie);
            _context.SaveChanges();
        }

        // Update an existing movie by its ID
        public void UpdateMovie(int id, Movie updatedMovie)
        {
            if (updatedMovie == null)
            {
                throw new ArgumentNullException(nameof(updatedMovie), "Updated movie cannot be null.");
            }

            var movie = _context.Movies.Where(m => m.Id == id).FirstOrDefault();
            if (movie == null)
            {
                throw new KeyNotFoundException($"Movie with id {id} not found.");
            }

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
}
