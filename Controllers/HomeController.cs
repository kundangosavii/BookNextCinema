using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using cinema_booking.Models;
using cinema_booking.Extensions;

namespace cinema_booking.Controllers;

public class HomeController : Controller
{
    private readonly ICinemaCatalog _catalog;

    // Initializes the controller with the cinema catalog dependency.
    public HomeController(ICinemaCatalog catalog)
    {
        _catalog = catalog;
    }

    // Displays the movies currently available for booking.
    public IActionResult Index()
    {
        return View(new HomeViewModel { Movies = _catalog.GetMovies() });
    }

    // Displays the application's privacy information page.
    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    // Displays the error page with the current request identifier.
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
