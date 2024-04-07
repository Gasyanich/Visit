using System.Text.Json;

namespace Visit.Contracts.Place;

public class AttributeValueRequest
{
    /// <summary>
    ///     Id атрибута
    /// </summary>
    public int AttributeId { get; set; }

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