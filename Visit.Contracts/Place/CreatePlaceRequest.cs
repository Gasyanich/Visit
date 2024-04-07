using System.Text.Json;

namespace Visit.Contracts.Place;

public class CreatePlaceRequest
{
    /// <summary>
    ///     Название
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    ///     Описание
    /// </summary>
    public string Description { get; set; }

    /// <summary>
    ///     Id категорий заведения
    /// </summary>
    public IEnumerable<int> CategoryIds { get; set; }

    /// <summary>
    ///     Список значений атрибутов
    /// </summary>
    public IEnumerable<AttributeValueRequest> Values { get; set; }
}

