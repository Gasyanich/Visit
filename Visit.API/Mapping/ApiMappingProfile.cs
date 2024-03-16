using AutoMapper;
using Visit.Contracts.Attribute;
using Visit.Contracts.Category;
using Visit.Domain;
using Attribute = Visit.Domain.Attribute;

namespace Visit.API.Mapping;

public class ApiMappingProfile : Profile
{
    public ApiMappingProfile()
    {
        CreateMap<Category, CreateCategoryResultDto>();
        CreateMap<Attribute, AttributeDto>();
    }
}