using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Visit.Contracts;
using Visit.Contracts.Attribute.Create;
using Visit.Contracts.Attribute.GetAll;
using Visit.Contracts.Attribute.GetById;
using Visit.Domain.BL.Abstractions;
using Visit.Domain.BL.DTO.Attribute;

// ReSharper disable once SuggestBaseTypeForParameterInConstructor

namespace Visit.API.Controllers;

[ApiController]
[Route("api/attributes")]
public class AttributeController(IAttributeService attributeService, IMapper mapper) : ControllerBase
{
    /// <summary>
    ///     Создать атрибут
    /// </summary>
    [HttpPost]
    public async Task<ApiResponse> Create([FromBody] CreateAttributeRequest request)
    {
        var dto = mapper.Map<CreateAttributeDto>(request);

        var attribute = await attributeService.CreateAttribute(dto);

        return ApiResponse.CreateSuccess(mapper.Map<CreateAttributeResponse>(attribute));
    }

    /// <summary>
    ///     Получить все атрибуты
    /// </summary>
    [HttpGet]
    public async Task<ApiResponse> GetAll()
    {
        var attributes = await attributeService.GetAllAttributes();

        var response = mapper.Map<IEnumerable<GetAllAttributesResponse>>(attributes);

        return ApiResponse.CreateSuccess(response);
    }

    /// <summary>
    ///     Получить подробную информацию об атрибуте
    /// </summary>
    [HttpGet("{id}")]
    public async Task<ApiResponse<GetAttributeByIdResponse>> GetById(long id)
    {
        var attribute = await attributeService.GetAttributeById(id);

        if (attribute is null)
            return ApiResponse.CreateFailure<GetAttributeByIdResponse>(400, "Атрибут не найден");

        var response = mapper.Map<GetAttributeByIdResponse>(attribute);

        return ApiResponse.CreateSuccess(response);
    }

    /// <summary>
    ///     Удалить атрибут
    /// </summary>
    [HttpDelete("{id}")]
    public async Task<ApiResponse> Delete(long id)
    {
        await attributeService.DeleteAttributeById(id);

        return ApiResponse.CreateSuccess();
    }
}