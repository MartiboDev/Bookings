using Bookings.Converters;
using System.Text.Json;

namespace Bookings.Tests.Converters
{
    public class TimeOnlyConverterTests
    {
        private readonly JsonSerializerOptions _options;

        public TimeOnlyConverterTests()
        {
            _options = new JsonSerializerOptions
            {
                Converters = { new TimeOnlyConverter() }
            };
        }

        [Fact]
        public void TimeOnlyConverter_CanConvertTimeOnly()
        {
            // Arrange
            var time = new TimeOnly(14, 30);
            var expectedJson = "\"14:30\"";

            // Act
            var json = JsonSerializer.Serialize(time, _options);

            // Assert
            Assert.Equal(expectedJson, json);
        }

        [Fact]
        public void TimeOnlyConverter_CanReadTimeOnly()
        {
            // Arrange
            var json = "\"14:30\"";
            var expectedTime = new TimeOnly(14, 30);

            // Act
            var time = JsonSerializer.Deserialize<TimeOnly>(json, _options);

            // Assert
            Assert.Equal(expectedTime, time);
        }

        [Fact]
        public void TimeOnlyConverter_ThrowsValidExceptionWithInvalidJson()
        {
            // Arrange
            var invalidJson = "invalid time";

            // Act & Assert
            Assert.Throws<JsonException>(() => JsonSerializer.Deserialize<TimeOnly>(invalidJson, _options));
        }
    }
}