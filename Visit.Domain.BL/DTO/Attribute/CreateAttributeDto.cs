namespace Visit.Domain.BL.DTO.Attribute;

public class CreateAttributeDto
{
    /// <summary>
    ///     Название атрибута
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    ///     Может ли атрибут использоваться в фильтрах
    /// </summary>
    public bool CanUseInFilter { get; set; }

    /// <summary>
    ///     Порядок отображения атрибута
    /// </summary>
    public int Order { get; set; }

    /// <summary>
    ///     Допустимо ли использовать несколько значений атрибута
    /// </summary>
    public bool AllowMultipleValues { get; set; }

    /// <summary>
    ///     Определенные заранее значения для атрибута
    ///     <example>Вид кухни: итальянская, греческая, грузинская..</example>
    ///     <example>Способ оплаты: картой, наличными, переводом</example>
    /// </summary>
    public IEnumerable<object> PredefinedValues { get; set; }

    /// <summary>
    ///     Тип значения атрибута
    /// </summary>
    public AttributeType Type { get; set; }

    /// <summary>
    ///     Тип контрола атрибута
    /// </summary>
    public AttributeControlType ControlType { get; set; }
    
    /// <summary>
    ///     Использовать значения атрибута в полнотекстовом поиске
    /// </summary>
    public bool IsUseValuesForTextSearch { get; set; }

    /// <summary>
    ///     Обязательность заполнения атрибута
    /// </summary>
    public bool IsRequired { get; set; }

    /// <summary>
    ///     Уникальный код атрибута. Может пригодится в дальнейшем при построении UI
    /// </summary>
    public string Code { get; set; }
}