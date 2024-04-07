using AutoMapper;
using Visit.Domain.BL.DTO.Attribute;
using Visit.Domain.BL.DTO.Category;

namespace Visit.Domain.BL.Mapping;

public class DomainMappingProfile : Profile
{
    public DomainMappingProfile()
    {
        CreateMap<CreateCategoryDto, Category>()
            .ForMember(c => c.Attributes, opt => opt.MapFrom(dto => dto.AttributeIds.Select(id => new Attribute
            {
                Id = id
            })));

        CreateMap<UpdateCategoryDto, Category>()
            .ForMember(c => c.Attributes,
                opt => opt.MapFrom(dto => dto.AttributeIds.Select(id => new Attribute {Id = id})))
            .ForMember(c => c.CategoryAttributes, opt => opt.MapFrom(dto => dto.AttributeIds.Select(id =>
                new CategoryAttribute
                {
                    CategoryId = dto.Id,
                    AttributeId = id
                })));

        CreateMap<CreateAttributeDto, Attribute>();
        CreateMap<UpdateAttributeDto, Attribute>();
    }
}