using Bookings.Interfaces;
using Bookings.Models;

namespace Bookings.Repositories
{
    public class BookingRepository : IBookingRepository
    {
        private readonly IList<Booking> _bookings = [];

        public Task<IEnumerable<Booking>> GetBookingsAsync()
        {
            return Task.FromResult((IEnumerable<Booking>)_bookings);
        }

        public Task<Booking?> GetBookingAsync(Guid bookingId)
        {
            var booking = _bookings.FirstOrDefault(booking => booking.Id == bookingId);
            return Task.FromResult(booking);
        }

        public Task<Booking> AddBookingAsync(Booking booking)
        {
            _bookings.Add(booking);
            return Task.FromResult(booking);
        }

        public Task RemoveBookingAsync(Booking booking)
        {
            _bookings.Remove(booking);
            return Task.CompletedTask;
        }
    }
}
