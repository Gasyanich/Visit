using AutoMapper;
using Visit.Contracts.Attribute.Create;
using Visit.Contracts.Attribute.GetAll;
using Visit.Contracts.Attribute.GetById;
using Visit.Contracts.Category.Create;
using Visit.Contracts.Category.GetAll;
using Visit.Contracts.Category.GetById;
using Visit.Contracts.Place;
using Visit.Domain;
using Visit.Domain.BL.DTO.Attribute;
using Visit.Domain.BL.DTO.Category;
using Visit.Domain.BL.DTO.Place;
using Attribute = Visit.Domain.Attribute;

namespace Visit.API.Mapping;

public class ApiMappingProfile : Profile
{
    public ApiMappingProfile()
    {
        // Category
        CreateMap<CreateCategoryRequest, CreateCategoryDto>();
        CreateMap<Category, CreateCategoryResponse>();
        CreateMap<Category, GetAllCategoriesResponse>();
        CreateMap<Category, GetCategoryByIdResponse>();
        CreateMap<Attribute, GetCategoryAttributeModel>();

        // Attribute
        CreateMap<CreateAttributeRequest, CreateAttributeDto>()
            .ForMember(dto => dto.PredefinedValues, opt => opt.MapFrom(r => r.PredefinedValues.MapToObjects()));
        CreateMap<Attribute, CreateAttributeResponse>();
        CreateMap<Attribute, GetAllAttributesResponse>();
        CreateMap<Attribute, GetAttributeByIdResponse>();
        CreateMap<Category, GetAttributeCategoryModel>();
        
        // Place
        CreateMap<CreatePlaceRequest, CreatePlaceDto>();
        CreateMap<CreatePlaceAttributeValueModel, CreatePlaceAttributeValueDto>()
            .ForMember(dto => dto.Value, opt => opt.MapFrom(r => r.Value != null ? r.Value.Value.MapToObject() : null))
            .ForMember(dto => dto.Values, opt => opt.MapFrom(r => r.Values != null ? r.Values.MapToObjects() : null));

    }
}