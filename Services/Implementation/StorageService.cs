using System.IO;
using System.Net.Mail;
using Microsoft.VisualBasic;
using TheCSharpers_QuikTix.Models;

public class StorageService
{

    private String MovieFile = "movies.txt";
    private String CustomerFile = "customers.txt";


    public List<Movie> ReadMovies()
    {
        List<Movie> movies = new List<Movie>();

        using (StreamReader sr = new StreamReader(MovieFile))
        {
            string? line;
            while ((line = sr.ReadLine()) != null)
            {
                String[] processed = line.Split('|');
                Movie movie = new Movie(int.Parse(processed[0]),
                processed[1],
                processed[2],
                processed[3],
                DateTime.Now.AddHours(int.Parse(processed[4])),
                int.Parse(processed[5]));
                movies.Add(movie);

                //Console.WriteLine(movie.Tickets);
            }
        }
        return movies;
    }

    public List<Customer> ReadCustomers()
    {
        List<Customer> customers = new List<Customer>();

        using (StreamReader sr = new StreamReader(CustomerFile))
        {
            string? line;
            while ((line = sr.ReadLine()) != null)
            {
                String[] processed = line.Split('|');

                Customer customer = new Customer(int.Parse(processed[0]),
                processed[1],
                processed[2],
                processed[3]);

                customers.Add(customer);
            }
        }
        return customers;
    }
}