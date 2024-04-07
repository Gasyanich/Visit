namespace Visit.Contracts.Place;

public class SearchPlaceFilterRequest
{
    public string Text { get; set; }

    public int Count { get; set; }

    public int Offset { get; set; }

    public IEnumerable<AttributeValueRequest> AttributeValues { get; set; }
}