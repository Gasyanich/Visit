namespace Visit.Domain.BL.DTO.Place;

public class CreatePlaceDto
{
    public string Name { get; set; }

    public string Description { get; set; }

    public IEnumerable<int> CategoryIds { get; set; }

    public List<AttributeValueDto> Values { get; set; }
}

public class AttributeValueDto
{
    public int AttributeId { get; set; }

    public object? Value { get; set; }

    public IEnumerable<object> Values { get; set; }
}