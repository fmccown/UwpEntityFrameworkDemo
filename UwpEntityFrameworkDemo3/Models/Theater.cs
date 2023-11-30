using System.Collections.Generic;

namespace UwpEntityFrameworkDemo.Models
{
    public class Theater
    {
        private List<Movie> movieList;

        public List<Movie> MovieList
        {
            get
            {
                return movieList;
            }
        }

        public Theater()
        {
            movieList = new List<Movie>();

            BuildMovieList();
        }

        private void BuildMovieList()
        {
            movieList.Clear();

            // Create new ViewModels for each movie in the database
            using (var db = new MovieTheaterContext())
            {
                foreach (var movie in db.Movies)
                {
                    movieList.Add(movie);
                }
            }
        }

        public void AddMovie(Movie newMovie)
        {
            // Add new movie to the database
            using (var db = new MovieTheaterContext())
            {
                // Make sure a new Id is assigned
                newMovie.Id = 0;

                db.Movies.Add(newMovie);

                // New MovieId assigned when saved
                db.SaveChanges();

                BuildMovieList();
            }
        }

        public void UpdateMovie(Movie updatedMovie)
        {          
            // Update the movie in the database
            using (var db = new MovieTheaterContext())
            {             
                db.Movies.Update(updatedMovie);
                db.SaveChanges();
                BuildMovieList();
            }
        }

        public void DeleteMovie(Movie movie)
        {
            // Delete the movie from the database
            using (var db = new MovieTheaterContext())
            {
                db.Movies.Remove(movie);
                db.SaveChanges();
                BuildMovieList();
            }
        }

        public void FetchMovies(string searchTerm)
        {
            // Simulate fetching movie list from a web API
            var movies = MovieFetcher.FetchMovies(searchTerm);

            // Save movies to the database
            using (var db = new MovieTheaterContext())
            {
                foreach (var newMovie in movies)
                {
                    newMovie.Id = 0;
                    db.Movies.Add(newMovie);
                }

                db.SaveChanges();
            }

            // Now that ids have been assigned to each movie, build the list
            BuildMovieList();
        }
    }
}
