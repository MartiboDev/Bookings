using Bookings.Models;

namespace Bookings.Interfaces
{
    public interface IBookingService
    {
        public Task<Booking> CreateBookingAsync(BookingModel bookingModel);
    }
}
