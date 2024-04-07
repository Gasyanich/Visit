using Visit.Contracts.Category;

namespace Visit.Contracts.Place;

public class PlaceFullResponse
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

    /// <summary>
    ///     Список значений атрибутов
    /// </summary>
    public IEnumerable<AttributeValueResponse> AttributeValues { get; set; }
}