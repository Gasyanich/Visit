using AutoMapper;
using Visit.Domain.BL.Abstractions;
using Visit.Domain.BL.Abstractions.Repository;
using Visit.Domain.BL.DTO.Attribute;

namespace Visit.Domain.BL;

public class AttributeService(IAttributeRepository attributeRepository, IMapper mapper) : IAttributeService
{
    public async Task<Attribute> CreateAttribute(CreateAttributeDto dto)
    {
        var isNameExists = await attributeRepository.IsExistByName(dto.Name);
        if (isNameExists)
            throw new Exception("Атрибут с таким названием уже существует");

        var attribute = mapper.Map<Attribute>(dto);

        await attributeRepository.Create(attribute);

        return await GetAttributeById(attribute.Id);
    }
    
    public async Task<Attribute> UpdateAttribute(UpdateAttributeDto dto)
    {
        var attribute = mapper.Map<Attribute>(dto);

        await attributeRepository.Update(attribute);

        return await GetAttributeById(attribute.Id);
    }

    public async Task<IEnumerable<Attribute>> GetAllAttributes()
    {
        return await attributeRepository.GetAll();
    } 
    
    public async Task<Attribute> GetAttributeById(int id)
    {
        return await attributeRepository.GetById(id);
    }

    public async Task DeleteAttributeById(int id)
    {
        await attributeRepository.Delete(id);
    }
}