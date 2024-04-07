using Visit.Domain.BL.Abstractions;
using Visit.Domain.BL.Abstractions.Repository;
using Visit.Domain.BL.DTO.Place;

namespace Visit.Domain.BL;

public class PlaceService(IAttributeValueFactory attributeValueFactory,
    IPlaceRepository placeRepository) : IPlaceService
{
    public async Task<Place> CreatePlace(CreatePlaceDto dto)
    {
        var categories = dto.CategoryIds.Select(categoryId => new Category {Id = categoryId}).ToList();

        var attributeValues = await attributeValueFactory.CreateAttributeValues(dto.CategoryIds, dto.Values);

        var place = new Place(
            dto.Name,
            dto.Description,
            categories,
            attributeValues.ToList()
        );

        return await placeRepository.Create(place);
    }

    public async Task<IEnumerable<Place>> Search(SearchPlaceFilterDto dto)
    {
        return await placeRepository.GetByFilter(dto);
    }

    public async Task<Place?> GetPlaceById(int id)
    {
        return await placeRepository.GetById(id);
    }

    public async Task DeletePlaceById(int id)
    {
        await placeRepository.Delete(id);
    }
}