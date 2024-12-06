using System.Collections.Generic;
using TheCSharpers_QuikTix.Models;

namespace TheCSharpers_QuikTix.Services.Interfaces
{
    public interface IMovieService
    {
        // Get all movies
        IEnumerable<Movie> GetMovies();

        // Get a movie by its ID
        Movie GetMovieById(int id);

        // Add a new movie
        void AddMovie(Movie movie);

        // Update an existing movie
        void UpdateMovie(int id, Movie updatedMovie);

        // Delete a movie by its ID
        void DeleteMovie(int id);
    }
}
