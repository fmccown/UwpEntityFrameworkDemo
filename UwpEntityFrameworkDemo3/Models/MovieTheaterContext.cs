using Microsoft.EntityFrameworkCore;

namespace UwpEntityFrameworkDemo.Models
{
    public class MovieTheaterContext : DbContext
    {
        // Binds Movie class to Movies table
        public DbSet<Movie> Movies { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // theater.db file saved in C:\Users\USERNAME\AppData\Local\Packages\KEY\LocalState
            optionsBuilder.UseSqlite("Data Source=theater.db");
        }
    }

}
