namespace cinema_booking.Models;

public class BookingViewModel
{
    public Movie Movie { get; init; } = new();
    public Booking Booking { get; init; } = new();
}
