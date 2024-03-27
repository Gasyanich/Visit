using Microsoft.EntityFrameworkCore;
using Visit.DAL;
using Visit.Domain.BL.Abstractions;
using Visit.Domain.BL.DTO.Attribute;

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

    public async Task<IEnumerable<Attribute>> GetAllAttributes()
    {
        return await dataContext.Attributes
            .AsNoTracking()
            .ToListAsync();
    } 
    
    public async Task<Attribute?> GetAttributeById(long id)
    {
        return await dataContext.Attributes
            .Include(a => a.Categories)
            .AsNoTracking()
            .FirstOrDefaultAsync(a => a.Id == id);
    }

    public async Task DeleteAttributeById(long id)
    {
        await dataContext.Attributes.Where(a => a.Id == id).ExecuteDeleteAsync();
    }
}