namespace Bookings.Constants
{
    public static class BookingConstants
    {
        public const int MaxSimultaneousSettlements = 4;
        public readonly static TimeOnly OpeningTime = new(9, 0);
        public readonly static TimeOnly ClosingTime = new(17, 0);
    }
}
