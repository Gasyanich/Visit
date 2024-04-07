using System.Linq.Expressions;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Visit.Contracts;
using Visit.Contracts.Place;
using Visit.DAL;
using Visit.Domain.BL.Abstractions;
using Visit.Domain.BL.DTO.Place;

namespace Visit.API.Controllers;

[ApiController]
[Route("api/places")]
public class PlaceController(IPlaceService placeService, IMapper mapper) : ControllerBase
{
    /// <summary>
    ///     Создать заведение
    /// </summary>
    [HttpPost]
    public async Task<ApiResponse<PlaceFullResponse>> Create([FromBody] CreatePlaceRequest request)
    {
        var dto = mapper.Map<CreatePlaceDto>(request);

        var place = await placeService.CreatePlace(dto);

        return ApiResponse.CreateSuccess(mapper.Map<PlaceFullResponse>(place));
    }

    [HttpPost("search")]
    public async Task<ApiResponse<IEnumerable<PlaceResponse>>> Search(SearchPlaceFilterRequest request)
    {
        var dto = mapper.Map<SearchPlaceFilterDto>(request);

        var places = await placeService.Search(dto);

        return ApiResponse.CreateSuccess(mapper.Map<IEnumerable<PlaceResponse>>(places));
    }

    /// <summary>
    ///     Получить подробную информацию о заведении
    /// </summary>
    [HttpGet("{id}")]
    public async Task<ApiResponse<PlaceFullResponse>> GetById(int id)
    {
        var place = await placeService.GetPlaceById(id);

        if (place is null)
            return ApiResponse.CreateFailure<PlaceFullResponse>(400, "Заведение не найдено");

        return ApiResponse.CreateSuccess(mapper.Map<PlaceFullResponse>(place));
    }

    /// <summary>
    ///     Удалить заведение
    /// </summary>
    [HttpDelete("{id}")]
    public async Task<ApiResponse> Delete(int id)
    {
        await placeService.DeletePlaceById(id);

        return ApiResponse.CreateSuccess();
    }
}