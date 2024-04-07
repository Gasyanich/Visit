using Visit.Domain.BL.DTO.Place;

namespace Visit.Domain.BL.Abstractions.Repository;

public interface IPlaceRepository
{
    Task<Place> Create(Place place);
    Task<Place> GetById(int id);
    Task Delete(int id);
    Task<IEnumerable<Place>> GetByFilter(SearchPlaceFilterDto filter);
}