namespace Visit.Domain;

public class AttributeValue
{
    public long Id { get; set; }

    public int PlaceId { get; set; }
    public Place Place { get; set; }

    public int AttributeId { get; set; }
    public Attribute Attribute { get; set; }

    public int? IntValue { get; set; }

    public double? DoubleValue { get; set; }

    public string StringValue { get; set; }
}