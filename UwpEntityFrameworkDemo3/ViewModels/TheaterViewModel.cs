using UwpEntityFrameworkDemo.Models;
using System;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;

namespace UwpEntityFrameworkDemo.ViewModels
{
    public class TheaterViewModel
    {
        private Theater theater;

        public ObservableCollection<MovieViewModel> Movies { get; set; }

        public TheaterViewModel()
        {
            theater = new Theater();

            Movies = new ObservableCollection<MovieViewModel>();
                        
            // Create new ViewModels for each movie in the database
            foreach (var movie in theater.MovieList)
            {
                Movies.Add(new MovieViewModel(movie));
            }

            // If movies are changed, let me know
            Movies.CollectionChanged += Movies_CollectionChanged;
        }

        public void UpdateMovie(int index)
        {
            var movieViewModel = Movies.ElementAt(index);
            theater.UpdateMovie(movieViewModel.Model);
        }

        private void Movies_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.Action == NotifyCollectionChangedAction.Add)
            {
                var movieViewModel = e.NewItems[0] as MovieViewModel;
                theater.AddMovie(movieViewModel.Model);

                // Tell ViewModel what new ID is
                movieViewModel.MovieId = movieViewModel.Model.Id;
            }
            else if (e.Action == NotifyCollectionChangedAction.Replace)
            {
                // Replace Action is not being triggered when items in list are replaced
            }
            else if (e.Action == NotifyCollectionChangedAction.Remove)
            {
                var movieViewModel = e.OldItems[0] as MovieViewModel;
                theater.DeleteMovie(movieViewModel.Model);
            }
        }
    }
}
