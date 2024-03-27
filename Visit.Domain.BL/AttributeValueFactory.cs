using Microsoft.EntityFrameworkCore;
using Visit.DAL;
using Visit.Domain.BL.Abstractions;
using Visit.Domain.BL.DTO.Place;

namespace Visit.Domain.BL;

public class AttributeValueFactory(DataContext dataContext) : IAttributeValueFactory
{
    public async Task<IEnumerable<AttributeValue>> CreateAttributeValues(IEnumerable<CreatePlaceAttributeValueDto> dtos)
    {
        var attributeValueDtos = dtos as CreatePlaceAttributeValueDto[] ?? dtos.ToArray();

        var attributeIds = attributeValueDtos.Select(dto => dto.AttributeId);

        var attributes = await dataContext.Attributes
            .Where(a => attributeIds.Contains(a.Id))
            .ToDictionaryAsync(a => a.Id, a => a);

        var result = new List<AttributeValue>();

        foreach (var dto in attributeValueDtos)
        {
            // TODO: Exception
            if (!attributes.TryGetValue(dto.AttributeId, out var attribute)) continue;

            if (attribute.AllowMultipleValues)
            {
                result.AddRange(dto.Values.Select(value => MapToAttributeValue(attribute, value)));
            }
            else
            {
                var attributeValue = MapToAttributeValue(attribute, dto.Value);
                result.Add(attributeValue);
            }
        }

        return result;
    }

    private static AttributeValue MapToAttributeValue(Attribute attribute, object value)
    {
        var attributeValue = new AttributeValue
        {
            AttributeId = attribute.Id
        };
        switch (attribute.Type)
        {
            case AttributeType.String:
                attributeValue.StringValue = (string) value;
                break;
            case AttributeType.Int:
                attributeValue.IntValue = (int) value;
                break;
            case AttributeType.Double:
                attributeValue.DoubleValue = (double) value;
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }

        return attributeValue;
    }
}