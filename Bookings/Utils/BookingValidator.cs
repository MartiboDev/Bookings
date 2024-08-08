using Bookings.Constants;
using Bookings.Models;

namespace Bookings.Utils
{
    public static class BookingValidator
    {
        /// <summary>
        /// Checks whether or not a booking time is within business hours
        /// </summary>
        /// <param name="bookingTime">Booking time</param>
        /// <returns>If a time is within business hours</returns>
        public static bool IsWithinBusinessHours(TimeOnly bookingTime)
        {
            return bookingTime >= BookingConstants.OpeningTime && bookingTime <= BookingConstants.ClosingTime.AddHours(-1);
        }

        /// <summary>
        /// Determines if there is a booking conflict with other bookings
        /// </summary>
        /// <param name="bookings">A list of bookings</param>
        /// <param name="bookingTime">Booking time</param>
        /// <returns>If a conflict exists</returns>
        public static bool HasBookingConflict(IEnumerable<Booking> bookings, TimeOnly bookingTime)
        {
            var overlappingBookings = bookings.Count(booking =>
            {
                var endBookingTime = booking.Time.AddMinutes(60);
                var newBookingEndTime = bookingTime.AddMinutes(60);
                return (bookingTime < endBookingTime && newBookingEndTime > booking.Time);
            });

            return overlappingBookings >= BookingConstants.MaxSimultaneousSettlements;
        }
    }
}
