using System.Text.Json.Serialization;
using System.Text.Json;

namespace Bookings.Converters
{
    public class TimeOnlyConverter : JsonConverter<TimeOnly>
    {
        private const string TimeFormat = "HH:mm";

        public override TimeOnly Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            var timeString = reader.GetString();
            if (TimeOnly.TryParseExact(timeString, TimeFormat, out var time))
            {
                return time;
            }
            throw new JsonException($"Invalid time format ({TimeFormat}).");
        }

        public override void Write(Utf8JsonWriter writer, TimeOnly value, JsonSerializerOptions options)
        {
            writer.WriteStringValue(value.ToString(TimeFormat));
        }
    }
}