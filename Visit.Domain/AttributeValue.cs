namespace Visit.Domain;

/// <summary>
///     Значение атрибута у  заведения
/// </summary>
public class AttributeValue
{
    public Attribute Attribute { get; set; }
    
    public int IntValue { get; set; }
    public IEnumerable<int> IntValues { get; set; }

    public double DoubleVale { get; set; }
    public IEnumerable<double> DoubleValues { get; set; }

    public string StringValue { get; set; }
    public IEnumerable<string> StringValues { get; set; }

    public DateTimeOffset DateTimeOffsetValue { get; set; }
    public IEnumerable<DateTimeOffset> DateTimeOffsetValues { get; set; }
}