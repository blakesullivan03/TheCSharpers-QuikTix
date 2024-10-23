using TheCSharpers_QuikTix.Models;

namespace TheCSharpers_QuikTix.Interfaces 
{
  public interface IMovieService 
  {
    IList<Movie> GetAllMovies();
    Movie GetMovieById(int id);
    void AddMovie(Movie movie);
    void RemoveMovie(int id);
  }

}
