using Bookings.Models;

namespace Bookings.Interfaces
{
    public interface IBookingRepository
    {
        public Task<IEnumerable<Booking>> GetBookingsAsync();
        public Task<Booking?> GetBookingAsync(Guid bookingId);
        public Task<Booking> AddBookingAsync(Booking booking);
        public Task RemoveBookingAsync(Booking booking);
    }
}
