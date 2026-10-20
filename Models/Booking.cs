using System.ComponentModel.DataAnnotations;

namespace cinema_booking.Models;

public class Booking
{
    public int Id { get; set; }
    public Movie Movie { get; set; } = new();
    public string Showtime { get; set; } = string.Empty;

    [Required(ErrorMessage = "Please enter your name.")]
    [Display(Name = "Your name")]
    public string CustomerName { get; set; } = string.Empty;

    [Required(ErrorMessage = "Please enter your email.")]
    [EmailAddress(ErrorMessage = "Please enter a valid email address.")]
    public string CustomerEmail { get; set; } = string.Empty;

    [Range(1, 10, ErrorMessage = "Choose between 1 and 10 seats.")]
    [Display(Name = "Number of seats")]
    public int Seats { get; set; } = 1;

    // Calculates the total booking cost from the selected number of seats.
    public decimal TotalPrice => Seats * 12.50m;
}
