using Microsoft.EntityFrameworkCore;
using MovieData.Entities;

namespace MovieData.Contexts
{
    public class MovieContext : DbContext
    {
        private string connectionString { get; set; }

        public MovieContext(DbContextOptions<MovieContext> options) : base(options) 
        { 
            connectionString = "Server=DESKTOP-M8Q0094;Database=MovieDB;Trusted_Connection=True;MultipleActiveResultSets=true";
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured) {
                optionsBuilder.UseSqlServer(connectionString, b => b.MigrationsAssembly("MovieTracker"));
            }

            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Movie>()
                .HasMany(m => m.Actors)
                .WithOne(a => a.Movie);
        }

        public DbSet<Movie> Movies { get; set; }
        public DbSet<Actor> Actors { get; set; }
    }
}