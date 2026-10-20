using cinema_booking.Extensions;
using cinema_booking.Models;
using Microsoft.AspNetCore.Mvc;

namespace cinema_booking.Controllers;

public class CinemaController : Controller
{
    private readonly ICinemaCatalog _catalog;

    // Initializes the controller with the cinema catalog dependency.
    public CinemaController(ICinemaCatalog catalog)
    {
        _catalog = catalog;
    }

    // Displays details and showtimes for the selected movie.
    public IActionResult Details(int id)
    {
        var movie = _catalog.GetMovie(id);
        return movie is null ? NotFound() : View(movie);
    }

    [HttpGet]
    // Displays the booking form with the selected movie and showtime.
    public IActionResult Book(int id, string? showtime)
    {
        var movie = _catalog.GetMovie(id);
        if (movie is null)
        {
            return NotFound();
        }

        var booking = new Booking { Movie = movie, Showtime = showtime ?? movie.Showtimes[0] };
        return View(new BookingViewModel { Movie = movie, Booking = booking });
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    // Validates and confirms a submitted cinema ticket booking.
    public IActionResult Book(int id, Booking booking)
    {
        var movie = _catalog.GetMovie(id);
        if (movie is null)
        {
            return NotFound();
        }

        booking.Movie = movie;
        if (!movie.Showtimes.Contains(booking.Showtime))
        {
            ModelState.AddModelError(nameof(booking.Showtime), "Please select a valid showtime.");
        }

        if (!ModelState.IsValid)
        {
            return View(new BookingViewModel { Movie = movie, Booking = booking });
        }

        booking.Id = Random.Shared.Next(10000, 99999);
        return View("Confirmation", booking);
    }
}
