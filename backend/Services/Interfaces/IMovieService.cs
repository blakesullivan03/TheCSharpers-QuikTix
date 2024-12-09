using System.Collections.Generic;
using TheCSharpers_QuikTix.Models;

public interface IMovieService
{
    IEnumerable<Movie> GetMovies();
    //IEnumerable<Review> GetReviewsForMovie(int movieId);
    Movie GetMovieById(int id);
    void AddMovie(Movie movie);
    void UpdateMovie(int id, Movie updatedMovie);
    void DeleteMovie(int id);
    //void AddReviewForMovie(int movieId, Review review);
    //void AddShowtimeForMovie(int movieId, Showtime showtime);

    //IEnumerable<Showtime> GetShowtimesForMovie(int movieId);

}
