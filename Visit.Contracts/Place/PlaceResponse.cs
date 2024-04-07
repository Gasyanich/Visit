using Visit.Contracts.Category;

namespace Visit.Contracts.Place;

public class PlaceResponse
{
    public int Id { get; set; }
    
    /// <summary>
    ///     Наименование заведения
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    ///     Описание заведения
    /// </summary>
    public string Description { get; set; }
    
    /// <summary>
    ///     Список категорий
    /// </summary>
    public IEnumerable<CategoryResponse> Categories { get; set; }
}