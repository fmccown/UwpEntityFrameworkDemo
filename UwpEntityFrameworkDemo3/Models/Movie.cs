using System.ComponentModel;


namespace UwpEntityFrameworkDemo.Models
{
    // All public properties of Movie are converted into table columns
    public class Movie 
    {
        // Public property that uses "Id" is the primary key (auto-increment)
        public int Id { get; set; }

        public string Title { get; set; }

        public string Rating { get; set; }

    }

}
