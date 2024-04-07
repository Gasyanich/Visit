using Visit.Domain.BL.Abstractions;
using Visit.Domain.BL.Abstractions.Repository;
using Visit.Domain.BL.DTO.Place;

namespace Visit.Domain.BL;

public class AttributeValueFactory(ICategoryRepository categoryRepository) : IAttributeValueFactory
{
    public async Task<IEnumerable<AttributeValue>> CreateAttributeValues(
        IEnumerable<int> categoryIds,
        IEnumerable<AttributeValueDto> attributeValues)
    {
        var categories = await categoryRepository.GetByIds(categoryIds);

        var attributesDict = categories.SelectMany(c => c.Attributes).ToDictionary(a => a.Id, a => a);

        var result = new List<AttributeValue>();

        foreach (var dto in attributeValues)
        {
            // TODO: Exception
            if (!attributesDict.TryGetValue(dto.AttributeId, out var attribute)) continue;

            if (attribute.AllowMultipleValues)
            {
                // TODO: проверять, что все значения имеют тот же тип, что и атрибут
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
            default:
                throw new ArgumentOutOfRangeException();
        }

        return attributeValue;
    }
}