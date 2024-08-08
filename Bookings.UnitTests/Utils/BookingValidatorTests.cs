using System;
using System.Collections.Generic;
using Bookings.Constants;
using Bookings.Models;
using Bookings.Utils;
using Xunit;

namespace Bookings.Tests.Utils
{
    public class BookingValidatorTests
    {
        [Fact]
        public void IsWithinBusinessHours_ValidTime_ReturnsTrue()
        {
            // Arrange
            var validTime = BookingConstants.OpeningTime;

            // Act
            var result = BookingValidator.IsWithinBusinessHours(validTime);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void IsWithinBusinessHours_InvalidTime_ReturnsFalse()
        {
            // Arrange
            var invalidTime = BookingConstants.OpeningTime.AddMinutes(-1);

            // Act
            var result = BookingValidator.IsWithinBusinessHours(invalidTime);

            // Assert
            Assert.False(result);
        }

        [Fact]
        public void IsWithinBusinessHours_InvalidTimeFinalHour_ReturnsFalse()
        {
            // Arrange
            var invalidTime = BookingConstants.ClosingTime.AddHours(-1).AddMinutes(1);

            // Act
            var result = BookingValidator.IsWithinBusinessHours(invalidTime);

            // Assert
            Assert.False(result);
        }

        [Fact]
        public void HasBookingConflict_NoConflict_ReturnsFalse()
        {
            // Arrange
            var bookings = new List<Booking>
            {
                new() { Id = Guid.NewGuid(), Name = "A", Time = new TimeOnly(9, 0) }
            };
            var newBookingTime = new TimeOnly(9, 30);

            // Act
            var result = BookingValidator.HasBookingConflict(bookings, newBookingTime);

            // Assert
            Assert.False(result);
        }

        [Fact]
        public void HasBookingConflict_MaxSimultaneousSettlements_ReturnsTrue()
        {
            // Arrange
            var bookings = new List<Booking>
            {
                new() { Id = Guid.NewGuid(), Name = "A", Time = new TimeOnly(9, 0) },
                new() { Id = Guid.NewGuid(), Name = "B", Time = new TimeOnly(10, 0) },
                new() { Id = Guid.NewGuid(), Name = "C", Time = new TimeOnly(10, 15) },
                new() { Id = Guid.NewGuid(), Name = "D", Time = new TimeOnly(10, 30) },
                new() { Id = Guid.NewGuid(), Name = "E", Time = new TimeOnly(10, 45) },
                new() { Id = Guid.NewGuid(), Name = "F", Time = new TimeOnly(11, 30) },
            };
            var newBookingTime = new TimeOnly(10, 30);

            // Act
            var result = BookingValidator.HasBookingConflict(bookings, newBookingTime);

            // Assert
            Assert.True(result);
        }
    }
}