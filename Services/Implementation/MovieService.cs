// Service that Handles adding, deleting, and updating Movies
using System;
using System.Collections.Generic;
using System.Linq;
using TheCSharpers_QuikTix.Interfaces;
using TheCSharpers_QuikTix.Models;

public class MovieService
{
    private List<Movie> movies = new List<Movie>();

    public List<Movie> GetAllMovies()
    {
        return movies;
    }

    public Movie GetMovieById(int id)
    {
        return movies.FirstOrDefault(m => m.Id == id)!;
    }

    public void AddMovie(Movie movie)
    {
        movies.Add(movie);
    }
    
    public void RemoveMovie(int id)
    {
        var movie = GetMovieById(id);
        if (movie != null)
            movies.Remove(movie);
    }
}