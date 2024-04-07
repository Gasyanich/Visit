using Visit.Domain.BL.DTO.Attribute;

namespace Visit.Domain.BL.Abstractions;

public interface IAttributeService
{
    Task<Attribute> CreateAttribute(CreateAttributeDto dto);

    Task<IEnumerable<Attribute>> GetAllAttributes();
    
    Task<Attribute?> GetAttributeById(int id);
    Task DeleteAttributeById(int id);
    Task<Attribute> UpdateAttribute(UpdateAttributeDto dto);
}