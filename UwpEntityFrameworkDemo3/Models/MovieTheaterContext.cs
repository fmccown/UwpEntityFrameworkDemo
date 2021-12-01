using Microsoft.EntityFrameworkCore;

namespace UwpEntityFrameworkDemo.Models
{
    public class MovieTheaterContext : DbContext
    {
        // Binds to Movies table
        public DbSet<Movie> Movies { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=theater.db");
        }
    }

}
