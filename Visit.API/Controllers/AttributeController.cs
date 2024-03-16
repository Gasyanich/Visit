using System.Text.Json;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Visit.Contracts;
using Visit.Contracts.Attribute;
using Visit.Domain.BL.Abstractions;

// ReSharper disable once SuggestBaseTypeForParameterInConstructor

namespace Visit.API.Controllers;

[ApiController]
[Route("api/attributes")]
public class AttributeController(IAttributeService attributeService, IMapper mapper) : ControllerBase
{
    [HttpPost]
    public async Task<ApiResponse> CreateAttribute([FromBody] CreateAttributeDto request)
    {
        FixJsonElemToObj(request);
        
        var attribute = await attributeService.CreateAttribute(request);

        return ApiResponse.CreateSuccess(mapper.Map<AttributeDto>(attribute));
    }

    private void FixJsonElemToObj(CreateAttributeDto request)
    {
        if (request.PredefinedValues is not null)
            request.PredefinedValues = request.PredefinedValues.OfType<JsonElement>().Select(JsonElemToObj).ToList();
    }
    
    private static object? JsonElemToObj(JsonElement jsonElement)
    {
        object? value = null;
        switch (jsonElement.ValueKind)
        {
            case JsonValueKind.String:
                value = jsonElement.GetString();
                break;
            case JsonValueKind.Number:
                if (jsonElement.TryGetInt32(out var intValue))
                    value = intValue;
                else if (jsonElement.TryGetDouble(out var doubleValue))
                    value = doubleValue;
                break;
            case JsonValueKind.Object:
                if (jsonElement.TryGetProperty("DateTimeValue", out var dateTimeProperty))
                    value = dateTimeProperty.GetDateTime();
                else if (jsonElement.TryGetProperty("DateTimeOffsetValue", out var dateTimeOffsetProperty))
                    value = dateTimeOffsetProperty.GetDateTimeOffset();
                break;
        }

        return value;
    }
}