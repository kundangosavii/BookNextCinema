namespace cinema_booking.Models;

public class Movie
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Genre { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string Duration { get; set; } = string.Empty;
    public string Rating { get; set; } = string.Empty;
    public string PosterUrl { get; set; } = string.Empty;
    public List<string> Showtimes { get; set; } = [];
}
