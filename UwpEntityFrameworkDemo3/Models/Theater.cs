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
            using (var db = new MovieTheaterContext())
            {             
                db.Movies.Update(updatedMovie);
                db.SaveChanges();
                BuildMovieList();
            }
        }

        public void DeleteMovie(Movie movie)
        {
            using (var db = new MovieTheaterContext())
            {
                db.Movies.Remove(movie);
                db.SaveChanges();
                BuildMovieList();
            }
        }
    }
}
