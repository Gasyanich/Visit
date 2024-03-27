using System.Text.Json;

namespace Visit.Contracts.Attribute.Create;

public class CreateAttributeRequest
{
    /// <summary>
    ///     Название атрибута
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    ///     Может ли атрибут использоваться в фильтрах
    /// </summary>
    public bool? CanUseInFilter { get; set; }

    /// <summary>
    ///     Порядок отображения атрибута
    /// </summary>
    public int? Order { get; set; }

    /// <summary>
    ///     Допустимо ли использовать несколько значений атрибута
    /// </summary>
    public bool? AllowMultipleValues { get; set; }

    /// <summary>
    ///     Определенные заранее значения для атрибута
    ///     <example>Вид кухни: итальянская, греческая, грузинская..</example>
    ///     <example>Способ оплаты: картой, наличными, переводом</example>
    /// </summary>
    public IEnumerable<JsonElement> PredefinedValues { get; set; }

    /// <summary>
    ///     Тип значения атрибута
    /// </summary>
    public AttributeType? Type { get; set; }

    /// <summary>
    ///     Тип контрола атрибута
    /// </summary>
    public AttributeControlType? ControlType { get; set; }
}