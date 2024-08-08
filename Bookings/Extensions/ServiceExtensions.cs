using InfoTrackBookings.Repositories;
using InfoTrackBookings.Services;
using InfoTrackBookings.Store;

namespace InfoTrackBookings.Extensions
{
    public static class ServiceExtensions
    {
        public static IServiceCollection ConfigureServices(this IServiceCollection services)
        {
            services.AddControllers();

            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();

            services.AddBookingServices();

            return services;
        }

        private static IServiceCollection AddBookingServices(this IServiceCollection services)
        {
            services.AddSingleton<BookingStore>();

            return services;
        }
    }
}
