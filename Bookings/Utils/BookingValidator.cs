using Bookings.Constants;
using Bookings.Models;

namespace Bookings.Utils
{
    public static class BookingValidator
    {
        public static bool IsWithinBusinessHours(TimeOnly bookingTime)
        {
            var openingHours = new TimeOnly(9, 0);
            var closingHours = new TimeOnly(17, 0);
            return bookingTime >= openingHours && bookingTime <= closingHours.AddHours(-1);
        }

        public static bool HasBookingConflict(IEnumerable<Booking> bookings, TimeOnly bookingTime)
        {
            var settlementsCount = 0;
            foreach (var booking in bookings)
            {
                var endBookingTime = booking.Time.AddMinutes(59);
                if (bookingTime >= booking.Time && bookingTime <= endBookingTime)
                {
                    settlementsCount++;
                }

                if (BookingConstants.MaxSimultaneousSettlements >= 4)
                {
                    return true;
                }
            }

            return false;
        }
    }
}
