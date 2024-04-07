using System.Diagnostics.CodeAnalysis;
using AutoMapper;
using Visit.Contracts.Attribute;
using Visit.Contracts.Category;
using Visit.Contracts.Place;
using Visit.Domain;
using Visit.Domain.BL.DTO.Attribute;
using Visit.Domain.BL.DTO.Category;
using Visit.Domain.BL.DTO.Place;
using Attribute = Visit.Domain.Attribute;
using AttributeType = Visit.Domain.AttributeType;

namespace Visit.API.Mapping;

public class ApiMappingProfile : Profile
{
    public ApiMappingProfile()
    {
        // Category
        CreateMap<CreateCategoryRequest, CreateCategoryDto>();
        CreateMap<UpdateCategoryRequest, UpdateCategoryDto>();
        CreateMap<Category, CategoryResponse>();
        CreateMap<Category, CategoryFullResponse>();

        // Attribute
        CreateMap<CreateAttributeRequest, CreateAttributeDto>()
            .ForMember(dto => dto.PredefinedValues, opt => opt.MapFrom(r => r.PredefinedValues.MapToObjects()));
        CreateMap<UpdateAttributeRequest, UpdateAttributeDto>()
            .ForMember(dto => dto.PredefinedValues, opt => opt.MapFrom(r => r.PredefinedValues.MapToObjects()));
        CreateMap<Attribute, AttributeResponse>();
        CreateMap<Attribute, AttributeFullResponse>();

        // Place
        CreateMap<CreatePlaceRequest, CreatePlaceDto>();
        CreateMap<SearchPlaceFilterRequest, SearchPlaceFilterDto>();
        CreateMap<AttributeValueRequest, AttributeValueDto>()
            .ForMember(dto => dto.Value, opt => opt.MapFrom(r => r.Value != null ? r.Value.Value.MapToObject() : null))
            .ForMember(dto => dto.Values, opt => opt.MapFrom(r => r.Values != null ? r.Values.MapToObjects() : null));
        CreateMap<Place, PlaceFullResponse>();
        CreateMap<Place, PlaceResponse>();
        CreateMap<IEnumerable<AttributeValue>, IEnumerable<AttributeValueResponse>>()
            .ConvertUsing((values, _, ctx) => MapToResponse(values, ctx));
    }

    [SuppressMessage("ReSharper", "PossibleMultipleEnumeration")]
    private static IEnumerable<AttributeValueResponse> MapToResponse(
        IEnumerable<AttributeValue> attributeValues,
        ResolutionContext ctx)
    {
        return attributeValues.GroupBy(av => av.Attribute, (attribute, values) =>
        {
            return new AttributeValueResponse
            {
                Attribute = ctx.Mapper.Map<AttributeResponse>(attribute),
                Value = attribute.AllowMultipleValues ? null : SelectValue(attribute, values.First()),
                Values = attribute.AllowMultipleValues ? values.Select(av => SelectValue(attribute, av)) : null
            };
        });
    }

    private static object SelectValue(Attribute attribute, AttributeValue value)
    {
        return attribute.Type switch
        {
            AttributeType.String => value.StringValue,
            AttributeType.Int => value.IntValue
        };
    }
}