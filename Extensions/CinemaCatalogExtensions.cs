using cinema_booking.Models;

namespace cinema_booking.Extensions;

public static class CinemaCatalogExtensions
{
    // Registers the cinema catalog as a singleton application service.
    public static IServiceCollection AddCinemaCatalog(this IServiceCollection services)
    {
        services.AddSingleton<ICinemaCatalog, CinemaCatalog>();
        return services;
    }
}

public interface ICinemaCatalog
{
    // Returns all movies available in the cinema catalog.
    IReadOnlyList<Movie> GetMovies();

    // Returns a movie by identifier or null when it does not exist.
    Movie? GetMovie(int id);
}

internal sealed class CinemaCatalog : ICinemaCatalog
{
    private readonly IReadOnlyList<Movie> _movies =
    [
        new()
        {
            Id = 1,
            Title = "The Last Horizon",
            Genre = "Sci-Fi · Adventure",
            Description = "A daring crew races beyond the edge of the known galaxy to bring humanity home.",
            Duration = "2h 18m",
            Rating = "PG-13",
            PosterUrl = "https://images.unsplash.com/photo-1440404653325-ab127d49abc1?auto=format&fit=crop&w=800&q=80",
            Showtimes = ["10:30 AM", "1:45 PM", "5:15 PM", "8:30 PM"]
        },
        new()
        {
            Id = 2,
            Title = "Midnight in Paris",
            Genre = "Romance · Drama",
            Description = "A chance meeting turns an ordinary evening into an unforgettable journey through the city.",
            Duration = "1h 52m",
            Rating = "PG",
            PosterUrl = "https://images.unsplash.com/photo-1502602898657-3e91760cbb34?auto=format&fit=crop&w=800&q=80",
            Showtimes = ["11:00 AM", "2:30 PM", "6:00 PM", "9:15 PM"]
        },
        new()
        {
            Id = 3,
            Title = "The Silent Forest",
            Genre = "Mystery · Thriller",
            Description = "When the lights go out in a remote town, one detective follows the only remaining clue.",
            Duration = "2h 05m",
            Rating = "15",
            PosterUrl = "https://images.unsplash.com/photo-1500534623283-312aade485b7?auto=format&fit=crop&w=800&q=80",
            Showtimes = ["12:15 PM", "3:45 PM", "7:00 PM", "10:00 PM"]
        }
    ];

    // Returns the complete in-memory movie catalog.
    public IReadOnlyList<Movie> GetMovies() => _movies;

    // Finds a movie in the catalog by its identifier.
    public Movie? GetMovie(int id) => _movies.FirstOrDefault(movie => movie.Id == id);
}
