namespace Visit.Domain.BL.DTO.Place;

public class SearchPlaceFilterDto
{
    public string Text { get; set; }

    public int Count { get; set; }

    public int Offset { get; set; }
    
    public AttributeValueDto[] AttributeValues { get; set; }
}