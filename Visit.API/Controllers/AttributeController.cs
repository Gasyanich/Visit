using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Visit.Contracts;
using Visit.Contracts.Attribute;
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

        return ApiResponse.CreateSuccess(mapper.Map<AttributeResponse>(attribute));
    }
    
    /// <summary>
    ///     Обновить атрибут
    /// </summary>
    [HttpPut]
    public async Task<ApiResponse> Update([FromBody] UpdateAttributeRequest request)
    {
        var dto = mapper.Map<UpdateAttributeDto>(request);

        var attribute = await attributeService.UpdateAttribute(dto);

        return ApiResponse.CreateSuccess(mapper.Map<AttributeResponse>(attribute));
    }

    /// <summary>
    ///     Получить все атрибуты
    /// </summary>
    [HttpGet]
    public async Task<ApiResponse> GetAll()
    {
        var attributes = await attributeService.GetAllAttributes();

        var response = mapper.Map<IEnumerable<AttributeResponse>>(attributes);

        return ApiResponse.CreateSuccess(response);
    }

    /// <summary>
    ///     Получить подробную информацию об атрибуте
    /// </summary>
    [HttpGet("{id}")]
    public async Task<ApiResponse<AttributeFullResponse>> GetById(int id)
    {
        var attribute = await attributeService.GetAttributeById(id);

        if (attribute is null)
            return ApiResponse.CreateFailure<AttributeFullResponse>(400, "Атрибут не найден");

        var response = mapper.Map<AttributeFullResponse>(attribute);

        return ApiResponse.CreateSuccess(response);
    }

    /// <summary>
    ///     Удалить атрибут
    /// </summary>
    [HttpDelete("{id}")]
    public async Task<ApiResponse> Delete(int id)
    {
        await attributeService.DeleteAttributeById(id);

        return ApiResponse.CreateSuccess();
    }
}