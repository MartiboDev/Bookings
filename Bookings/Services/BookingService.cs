using Bookings.Exceptions;
using Bookings.Interfaces;
using Bookings.Models;
using Bookings.Utils;

namespace Bookings.Services
{
    public class BookingService : IBookingService
    {
        private readonly IBookingRepository _bookingRepository;

        public BookingService(IBookingRepository bookingRepository)
        {
            _bookingRepository = bookingRepository;
        }

        public async Task<Booking> CreateBookingAsync(BookingModel bookingModel)
        {
            // Invalid data check ??? BadRequest

            // Checks to see if the booking time is within business hours
            if (!BookingValidator.IsWithinBusinessHours(bookingModel.BookingTime))
            {
                throw new InvalidOperationException("Booking time is outside of opening hours.");
            }

            // Check for booking conflicts
            var bookings = await _bookingRepository.GetBookingsAsync();
            if (BookingValidator.HasBookingConflict(bookings, bookingModel.BookingTime))
            {
                // throw and exception with an object that has a message and a status code
                throw new BookingConflictException("Booking time conflicts with existing booking.");
            }

            // Create a new Booking object
            var booking = new Booking
            {
                Id = new Guid(),
                Time = bookingModel.BookingTime,
                Name = bookingModel.Name
            };

            // Add booking to our repository
            await _bookingRepository.AddBookingAsync(booking);

            return booking;

        }
    }
}
