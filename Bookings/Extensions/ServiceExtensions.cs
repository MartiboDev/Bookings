using Bookings.Converters;
using Bookings.Interfaces;
using Bookings.Repositories;
using Bookings.Services;
using System.Text.Json.Serialization;

namespace Bookings.Extensions
{
    public static class ServiceExtensions
    {
        public static IServiceCollection ConfigureServices(this IServiceCollection services)
        {
            services.AddControllers()
                .AddJsonOptions(options =>
                {
                    options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
                    options.JsonSerializerOptions.Converters.Add(new TimeOnlyConverter());
                });

            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();

            services.AddBookingServices();

            return services;
        }

        private static IServiceCollection AddBookingServices(this IServiceCollection services)
        {
            // only a singleton so that it can store bookings in memory
            services.AddSingleton<IBookingRepository, BookingRepository>();
            services.AddScoped<IBookingService, BookingService>();

            return services;
        }
    }
}