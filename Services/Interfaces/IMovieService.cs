using System.Collections.Generic;
using TheCSharpers_QuikTix.Models;

public interface IMovieService
{
    IEnumerable<Movie> GetMovies();
    Movie GetMovieById(int id);
    void AddMovie(Movie movie);
    void UpdateMovie(int id, Movie updatedMovie);
    void DeleteMovie(int id);
}


