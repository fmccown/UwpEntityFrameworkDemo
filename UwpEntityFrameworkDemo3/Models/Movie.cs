using System.ComponentModel;


namespace UwpEntityFrameworkDemo.Models
{
    // All public properties of Movie are converted into table columns
    public class Movie : INotifyPropertyChanged
    {
        // Public property that uses "Id" is the primary key
        public int Id { get; set; }

        private string title;
        public string Title
        {
            get
            {
                return title;
            }
            set
            {
                title = value;
                OnPropertyChanged(this, new PropertyChangedEventArgs("Title"));
            }
        }

        private string rating;

        public string Rating
        {
            get
            {
                return rating;
            }
            set
            {
                rating = value;
                OnPropertyChanged(this, new PropertyChangedEventArgs("Rating"));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            PropertyChanged?.Invoke(sender, e);
        }
    }

}
