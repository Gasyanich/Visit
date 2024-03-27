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
    public IEnumerable<long> CategoryIds { get; set; }

    /// <summary>
    ///     Список значений атрибутов
    /// </summary>
    public IEnumerable<CreatePlaceAttributeValueModel> Values { get; set; }
}

public class CreatePlaceAttributeValueModel
{
    /// <summary>
    ///     Id атрибута
    /// </summary>
    public long AttributeId { get; set; }

    /// <summary>
    ///     Значение атрибута. Заполняется если атрибут может иметь только 1 значение
    ///     <remarks>Тип данных должен совпадать с типом атрибута</remarks>
    /// </summary>
    public JsonElement? Value { get; set; }

    /// <summary>
    ///     Значения атрибута. Заполняется если атрубит может иметь несколько значений
    ///     <remarks>Тип данных должен совпадать с типом атрибута</remarks>
    /// </summary>
    public IEnumerable<JsonElement> Values { get; set; }
}