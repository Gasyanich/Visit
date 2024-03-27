using Visit.DAL;
using Visit.Domain.BL.Abstractions;
using Visit.Domain.BL.DTO.Place;

namespace Visit.Domain.BL;

public class PlaceService(DataContext dataContext, IAttributeValueFactory attributeValueFactory) : IPlaceService
{
    public async Task<Place> CreatePlace(CreatePlaceDto dto)
    {
        var categories = dto.CategoryIds.Select(categoryId => new Category {Id = categoryId}).ToList();
        var attributeValues = await attributeValueFactory.CreateAttributeValues(dto.Values);

        var place = new Place(
            dto.Name,
            dto.Description,
            categories,
            attributeValues.ToList()
        );
        
        dataContext.Categories.AttachRange(place.Categories);
        dataContext.Places.Add(place);
        await dataContext.SaveChangesAsync();

        return place;
    }
}