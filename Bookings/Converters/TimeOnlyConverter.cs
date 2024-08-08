using System.Text.Json.Serialization;
using System.Text.Json;

namespace Bookings.Converters
{
    public class TimeOnlyConverter : JsonConverter<TimeOnly>
    {
        private const string TimeFormat = "HH:mm";

        public override TimeOnly Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            try
            {
                return TimeOnly.ParseExact(reader.GetString()!, TimeFormat);
            }
            catch (Exception e)
            {
                throw new JsonException("Invalid time format (HH:mm).", e);
            }
        }

        public override void Write(Utf8JsonWriter writer, TimeOnly value, JsonSerializerOptions options)
        {
            writer.WriteStringValue(value.ToString(TimeFormat));
        }
    }
}
