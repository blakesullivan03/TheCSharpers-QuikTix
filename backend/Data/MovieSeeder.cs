using TheCSharpers_QuikTix.Models;
using Microsoft.EntityFrameworkCore;

namespace TheCSharpers_QuikTix.Data
{
    public static class MovieSeeder
    {
        public static void SeedMovies(QuikTixDbContext context)
        {
            if (!context.Movies.Any())
            {
                var movies = new List<Movie>
                {
                    new Movie
                    {
                        Title = "All Quiet On the Western Front",
                        Genre = "War",
                        Description = "A modern retake on a classic",
                        Rating = 3,
                        ReleaseDate = new DateTime(2022, 10, 14),
                        Duration = 136,  // Duration added here
                        TicketCount = 50,
                        ImagePath = "../assets/images/all-quiet-on-the-western-front.jpg"
                    },
                    new Movie
                    {
                        Title = "The Matrix",
                        Genre = "Sci-Fi",
                        Description = "A hacker discovers the truth of his reality",
                        Rating = 5,
                        ReleaseDate = new DateTime(1999, 3, 31),
                        Duration = 136,  // Duration added here
                        TicketCount = 75,
                        ImagePath = "../assets/images/the-matrix.jpg"
                    },
                    new Movie
                    {
                        Title = "The Shawshank Redemption",
                        Genre = "Drama",
                        Description = "A banker fights for hope and redemption",
                        Rating = 7,
                        ReleaseDate = new DateTime(1994, 9, 22),
                        Duration = 142,  // Duration added here
                        TicketCount = 20,
                        ImagePath = "../assets/images/the-shawshank-redemption.jpg"
                    },
                    new Movie
                    {
                        Title = "Inception",
                        Genre = "Thriller",
                        Description = "A heist within dreams",
                        Rating = 4,
                        ReleaseDate = new DateTime(2010, 7, 16),
                        Duration = 148,  // Duration added here
                        TicketCount = 63,
                        ImagePath = "../assets/images/inception.jpg"
                    },
                    new Movie
                    {
                        Title = "Interstellar",
                        Genre = "Sci-Fi",
                        Description = "A journey beyond the stars to save humanity",
                        Rating = 6,
                        ReleaseDate = new DateTime(2014, 11, 7),
                        Duration = 169,  // Duration added here
                        TicketCount = 45,
                        ImagePath = "../assets/images/interstellar.jpg"
                    }
                    /*new Movie
                    {
                        Title = "Parasite",
                        Genre = "Thriller",
                        Description = "A dark comedy about class and family dynamics",
                        Rating = 2,
                        ReleaseDate = new DateTime(2019, 5, 30),
                        Duration = 132,  // Duration added here
                        TicketCount = 89,
                        ImagePath = "assets/images/parasite.jpg"
                    },
                    new Movie
                    {
                        Title = "The Godfather",
                        Genre = "Crime",
                        Description = "The story of a powerful crime family",
                        Rating = 6,
                        ReleaseDate = new DateTime(1972, 3, 24),
                        Duration = 175,  // Duration added here
                        TicketCount = 10,
                        ImagePath = "assets/images/the-godfather.jpg"
                    },
                    new Movie
                    {
                        Title = "Forrest Gump",
                        Genre = "Drama",
                        Description = "The life journey of a simple, kind-hearted man",
                        Rating = 4,
                        ReleaseDate = new DateTime(1994, 7, 6),
                        Duration = 142,  // Duration added here
                        TicketCount = 30,
                        ImagePath = "assets/images/forrest-gump.jpg"
                    },
                    new Movie
                    {
                        Title = "Jurassic Park",
                        Genre = "Adventure",
                        Description = "Dinosaurs roam in a modern-day theme park",
                        Rating = 5,
                        ReleaseDate = new DateTime(1993, 6, 11),
                        Duration = 127,  // Duration added here
                        TicketCount = 95,
                        ImagePath = "assets/images/jurassic-park.jpg"
                    },
                    new Movie
                    {
                        Title = "The Lion King",
                        Genre = "Animation",
                        Description = "A young lion's journey to reclaim his kingdom",
                        Rating = 7,
                        ReleaseDate = new DateTime(1994, 6, 15),
                        Duration = 88,  // Duration added here
                        TicketCount = 52,
                        ImagePath = "assets/images/the-lion-king.jpg"
                    },
                    new Movie
                    {
                        Title = "Gladiator",
                        Genre = "Action",
                        Description = "A general becomes a gladiator to avenge his family",
                        Rating = 3,
                        ReleaseDate = new DateTime(2000, 5, 5),
                        Duration = 155,  // Duration added here
                        TicketCount = 12,
                        ImagePath = "assets/images/gladiator.jpg"
                    },
                    new Movie
                    {
                        Title = "Black Panther",
                        Genre = "Superhero",
                        Description = "A prince returns to his kingdom as king",
                        Rating = 6,
                        ReleaseDate = new DateTime(2018, 2, 16),
                        Duration = 134,  // Duration added here
                        TicketCount = 80,
                        ImagePath = "assets/images/black-panther.jpg"
                    },
                    new Movie
                    {
                        Title = "La La Land",
                        Genre = "Musical",
                        Description = "Two artists struggle with dreams and romance",
                        Rating = 2,
                        ReleaseDate = new DateTime(2016, 12, 9),
                        Duration = 128,  // Duration added here
                        TicketCount = 42,
                        ImagePath = "assets/images/la-la-land.jpg"
                    },
                    new Movie
                    {
                        Title = "Titanic",
                        Genre = "Romance",
                        Description = "A love story on a fateful ship",
                        Rating = 5,
                        ReleaseDate = new DateTime(1997, 12, 19),
                        Duration = 195,  // Duration added here
                        TicketCount = 90,
                        ImagePath = "assets/images/titanic.jpg"
                    },
                    new Movie
                    {
                        Title = "Casablanca",
                        Genre = "Romance",
                        Description = "A classic love story set in wartime Morocco",
                        Rating = 1,
                        ReleaseDate = new DateTime(1942, 11, 26),
                        Duration = 102,  // Duration added here
                        TicketCount = 25,
                        ImagePath = "assets/images/casablanca.jpg"
                    }*/
                };

                context.Movies.AddRange(movies);
                context.SaveChanges();
            }
        }
    }
}
