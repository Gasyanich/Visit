using System.Text.Json;

namespace Visit.API.Mapping;

public static class JsonElementMappingHelper
{
    public static IEnumerable<object> MapToObjects(this IEnumerable<JsonElement>? jsonElement)
    {
        return jsonElement?.Select(e => e.MapToObject()) ?? Enumerable.Empty<object>();
    }
    
    public static object MapToObject(this JsonElement jsonElement)
    {
        object? value = null;
        switch (jsonElement.ValueKind)
        {
            case JsonValueKind.String:
                value = jsonElement.GetString();
                break;
            case JsonValueKind.Number:
                if (jsonElement.TryGetInt32(out var intValue))
                    value = intValue;
                else if (jsonElement.TryGetDouble(out var doubleValue))
                    value = doubleValue;
                break;
            case JsonValueKind.Object:
                if (jsonElement.TryGetProperty("DateTimeValue", out var dateTimeProperty))
                    value = dateTimeProperty.GetDateTime();
                else if (jsonElement.TryGetProperty("DateTimeOffsetValue", out var dateTimeOffsetProperty))
                    value = dateTimeOffsetProperty.GetDateTimeOffset();
                break;
        }

        if (value is null)
            throw new Exception("Ошибка маппинга. JsonValueKind " + jsonElement.ValueKind);
        
        return value;
    }
}