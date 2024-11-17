using System;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using System.Text.Encodings.Web;
using TheCSharpers_QuikTix.Services;

namespace TheCSharpers_QuikTix.Controllers;

public class HomeController : Controller
{
    // 
    // GET: /Home/
    public string Index()
    {
        return "This is my default action...";
    }
    // 
    // GET: /Home/Welcome
    public string GetMovies()
    {
        var backendService = new StorageService();
        var _movieService = new MovieService(backendService);

        var movies = _movieService.GetAllMovies();
        StringBuilder sb = new StringBuilder();

        foreach (var movie in movies)
        {
            sb.Append($"- {movie.Name} ({movie.Genre})");
            sb.Append($"  Description: {movie.Description}");
            sb.Append($"  Showtime: {movie.Showtime}");
            sb.Append($"  Tickets Available: {movie.TicketsAvailable}\n");
        }

        return sb.ToString();
    }
}