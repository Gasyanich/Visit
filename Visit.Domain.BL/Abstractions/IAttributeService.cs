using Visit.Contracts.Attribute;

namespace Visit.Domain.BL.Abstractions;

public interface IAttributeService
{
    Task<Attribute> CreateAttribute(CreateAttributeDto dto);
}