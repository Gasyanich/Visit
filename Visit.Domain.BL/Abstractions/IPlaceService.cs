using Visit.Domain.BL.DTO.Place;

namespace Visit.Domain.BL.Abstractions;

public interface IPlaceService
{
    Task<Place> CreatePlace(CreatePlaceDto dto);
}