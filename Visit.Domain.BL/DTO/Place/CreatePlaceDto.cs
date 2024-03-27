namespace Visit.Domain.BL.DTO.Place;

public class CreatePlaceDto
{
    public string Name { get; set; }

    public string Description { get; set; }

    public IEnumerable<long> CategoryIds { get; set; }

    public IEnumerable<CreatePlaceAttributeValueDto> Values { get; set; }
}

public class CreatePlaceAttributeValueDto
{
    public long AttributeId { get; set; }

    public object Value { get; set; }

    public IEnumerable<object> Values { get; set; }
}