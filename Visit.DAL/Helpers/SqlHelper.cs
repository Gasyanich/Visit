using System.Linq.Expressions;
using Visit.Domain;

namespace Visit.DAL.Helpers;

public static class SqlHelper
{
    public static string ToDbString(this IEnumerable<object> values, AttributeType type)
    {
        return type switch
        {
            AttributeType.String => $"( {string.Join(',', values.Select(v => $" '{v}' "))} )",
            AttributeType.Int => $"( {string.Join(',', values)} )",
            _ => throw new ArgumentOutOfRangeException(nameof(type), type, null)
        };
    }

    public static string ToDbString(this object value, AttributeType type)
    {
        return type switch
        {
            AttributeType.String => $"'{value}'",
            AttributeType.Int => $"{value}",
            _ => throw new ArgumentOutOfRangeException(nameof(type), type, null)
        };
    }
}