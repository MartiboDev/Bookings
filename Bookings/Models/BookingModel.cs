namespace Bookings.Models
{
    public class BookingModel
    {
        public TimeOnly BookingTime { get; set; }
        public required string Name { get; set; }
    }
}
