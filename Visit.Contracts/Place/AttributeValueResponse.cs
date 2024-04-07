using Visit.Contracts.Attribute;

namespace Visit.Contracts.Place;

public class AttributeValueResponse
{
    /// <summary>
    ///     Атрибут
    /// </summary>
    public AttributeResponse Attribute { get; set; }

    /// <summary>
    ///     Значение атрибута. Заполняется если атрибут может иметь только 1 значение
    /// </summary>
    public object Value { get; set; }

    /// <summary>
    ///     Значения атрибута. Заполняется если атрубит может иметь несколько значений
    /// </summary>
    public object Values { get; set; }
}