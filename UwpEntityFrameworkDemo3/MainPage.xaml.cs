using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using UwpEntityFrameworkDemo.ViewModels;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace UwpEntityFrameworkDemo
{
    public sealed partial class MainPage : Page
    {
        public TheaterViewModel Theater { get; set; }
        public MovieViewModel Movie { get; set; }

        public MainPage()
        {
            this.InitializeComponent();

            Movie = new MovieViewModel();
            Theater = new TheaterViewModel();
        }

        private void addButton_Click(object sender, RoutedEventArgs e)
        {
            Movie.Rating = ratingComboBox.SelectedValue as string;

            if (addButton.Content.ToString() == "Add Movie")
            {
                // Add a new movie
                Theater.Movies.Add(new MovieViewModel
                {
                    MovieId = Movie.MovieId,
                    Title = Movie.Title,
                    Rating = Movie.Rating
                });

                // Reset form
                titleTextBox.Text = "";
                ratingComboBox.SelectedIndex = 1;
            }
            else
            {
                // Replace selected movie with new values
                if (movieListView.SelectedItem is MovieViewModel movieViewModel)
                {
                    movieViewModel.Title = Movie.Title;
                    movieViewModel.Rating = Movie.Rating;
                    Theater.UpdateMovie(movieListView.SelectedIndex);
                }
                addButton.Content = "Add Movie";
            }
        }

        private void updateButton_Click(object sender, RoutedEventArgs e)
        {
            if (movieListView.SelectedItem is MovieViewModel selectedMovie)
            {
                Movie.Title = selectedMovie.Title;
                Movie.Rating = selectedMovie.Rating;
                ratingComboBox.SelectedValue = Movie.Rating;

                addButton.Content = "Save";
            }            
        }

        private void deleteButton_Click(object sender, RoutedEventArgs e)
        {
            // Delete selected movie
            if (movieListView.SelectedItem is MovieViewModel selectedMovie)
            {
                Theater.Movies.Remove(selectedMovie);
            }
        }

        private void fetchButton_Click(object sender, RoutedEventArgs e)
        {
            Theater.FetchMovies("star");
        }
    }
}
