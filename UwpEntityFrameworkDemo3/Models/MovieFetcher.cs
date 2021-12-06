using System.Collections.Generic;

namespace UwpEntityFrameworkDemo.Models
{
    class MovieFetcher
    {
        public static List<Movie> FetchMovies(string searchTerm)
        {
            // Pretend to send an API request to get back movies that match the search term
            return new List<Movie>
            {
                new Movie { Title = "Star Wars", Rating = "PG"},
                new Movie { Title = "The Last Starfighter", Rating = "PG-13"}
            };
        }
    }
}
