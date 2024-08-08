using Bookings.Exceptions;
using Bookings.Interfaces;
using Bookings.Models;
using Microsoft.AspNetCore.Mvc;

namespace Bookings.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BookingController : ControllerBase
    {
        private readonly ILogger<BookingController> _logger;
        private readonly IBookingService _bookingService;

        public BookingController(ILogger<BookingController> logger, IBookingService bookingService)
        {
            _logger = logger;
            _bookingService = bookingService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateBooking([FromBody] BookingModel bookingModel)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            try
            {
                var booking = await _bookingService.CreateBookingAsync(bookingModel);
                return Ok(new { bookingId = booking.Id });
            }
            catch (BookingConflictException ex)
            {
                _logger.LogError(ex, "Booking conflict");
                return Conflict();
            }
            catch (InvalidOperationException ex)
            {
                _logger.LogError(ex, "Error creating booking");
                return BadRequest();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Unexpected error: {Message}", ex.Message);
                return StatusCode(500, new { error = "An unexpected error occurred. Please try again later." });
            }
        }
    }
}