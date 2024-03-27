using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Visit.Contracts;
using Visit.Contracts.Place;
using Visit.Domain.BL.Abstractions;
using Visit.Domain.BL.DTO.Place;

namespace Visit.API.Controllers;

[ApiController]
[Route("api/places")]
public class PlaceController(IPlaceService placeService, IMapper mapper) : ControllerBase
{
    /// <summary>
    /// Создать заведение
    /// </summary>
    [HttpPost]
    public async Task<ApiResponse> Create([FromBody] CreatePlaceRequest request)
    {
        var dto = mapper.Map<CreatePlaceDto>(request);

        _ = await placeService.CreatePlace(dto);

        return ApiResponse.CreateSuccess();
    }
}