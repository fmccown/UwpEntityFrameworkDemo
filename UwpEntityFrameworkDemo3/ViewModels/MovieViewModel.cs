using System.ComponentModel;
using UwpEntityFrameworkDemo.Models;

namespace UwpEntityFrameworkDemo.ViewModels
{
    public class MovieViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private Movie movie;

        public MovieViewModel(Movie movie = null)
        {
            if (movie == null)
            {
                movie = new Movie();
            }

            this.movie = movie;
        }

        public Movie Model
        {
            get
            {
                return movie;
            }
        }

        public int MovieId
        {
            get { return movie.Id; }
            set { movie.Id = value; }
        }

        public string Title
        {
            get { return movie.Title; }

            set
            {
                movie.Title = value;
                OnPropertyChanged("Title");
            }
        }

        public string Rating
        {
            get { return movie.Rating; }

            set
            {
                movie.Rating = value;
                OnPropertyChanged("Rating");
            }
        }

        private void OnPropertyChanged(string property)
        {
            // Notify any controls bound to the ViewModel that the property changed
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        }
    }
}
