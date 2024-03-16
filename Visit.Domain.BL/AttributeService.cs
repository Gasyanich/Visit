using Microsoft.EntityFrameworkCore;
using Visit.Contracts.Attribute;
using Visit.DAL;
using Visit.Domain.BL.Abstractions;

namespace Visit.Domain.BL;

public class AttributeService(DataContext dataContext) : IAttributeService
{
    public async Task<Attribute> CreateAttribute(CreateAttributeDto dto)
    {
        var checkNameUnique = await dataContext.Attributes.AnyAsync(c => c.Name == dto.Name);
        if (checkNameUnique)
            throw new Exception("Атрибут с таким названием уже существует");

        var attribute = new Attribute(
            dto.Name,
            dto.CanUseInFilter,
            dto.Order,
            dto.AllowMultipleValues,
            (AttributeType) dto.Type,
            (AttributeControlType) dto.ControlType,
            dto.PredefinedValues?.ToList()
        );

        dataContext.Attributes.Add(attribute);
        await dataContext.SaveChangesAsync();

        return attribute;
    }
}