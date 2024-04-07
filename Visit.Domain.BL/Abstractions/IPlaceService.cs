using Visit.Domain.BL.DTO.Place;

namespace Visit.Domain.BL.Abstractions;

public interface IPlaceService
{
    Task<Place> CreatePlace(CreatePlaceDto dto);
    Task<Place?> GetPlaceById(int id);
    Task DeletePlaceById(int id);
    Task<IEnumerable<Place>> Search(SearchPlaceFilterDto dto);
}