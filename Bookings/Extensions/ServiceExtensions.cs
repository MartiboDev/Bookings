namespace Bookings.Extensions
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
            return services;
        }
    }
}
