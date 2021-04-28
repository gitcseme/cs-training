using Microsoft.EntityFrameworkCore;
using MovieData.Entities;

namespace MovieData.Contexts
{
    public interface IMovieContext
    {
        DbSet<Movie> Movies { get; set; }
        DbSet<Actor> Actors { get; set; }
    }
}