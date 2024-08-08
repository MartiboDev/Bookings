namespace Bookings.Models;

public class Booking
{
    public Guid Id { get; set; }
    public required string Name { get; set; }
    public TimeOnly Time { get; set; }
}
