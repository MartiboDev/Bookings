using System;
using System.ComponentModel.DataAnnotations;

namespace Bookings.Models
{
    public class BookingModel
    {
        [Required]
        [Range(typeof(TimeOnly), "00:00", "23:59", ErrorMessage = "Booking time must be between 00:00 and 23:59.")]
        public TimeOnly BookingTime { get; set; }

        [Required]
        [StringLength(int.MaxValue, MinimumLength = 1, ErrorMessage = "Name must be a non-empty string.")]
        public string Name { get; set; } = string.Empty;
    }
}