namespace Visit.Domain;

/// <summary>
///     Атрибут. Любое свойство заведения
///     <example>Вид кухни, способ оплаты, наличие живой музыки</example>
/// </summary>
public class Attribute : IVisibleEntity
{
    public long Id { get; set; }

    private Attribute(){}
    
    public Attribute(string name,
        bool canUseInFilter,
        int order,
        bool allowMultipleValues,
        AttributeType type,
        AttributeControlType controlType,
        List<object> predefinedValues = null)
    {
        Name = name;
        CanUseInFilter = canUseInFilter;
        Order = order;
        AllowMultipleValues = allowMultipleValues;
        Type = type;
        ControlType = controlType;
        PredefinedValues = predefinedValues;
    }

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
    public List<object> PredefinedValues { get; set; }

    /// <summary>
    ///     Тип значения атрибута
    /// </summary>
    public AttributeType Type { get; set; }

    /// <summary>
    ///     Тип контрола атрибута
    /// </summary>
    public AttributeControlType ControlType { get; set; }

    /// <summary>
    ///     Ссылка на категории, к которым принадлежит атрибут
    /// </summary>
    public List<Category> Categories { get; set; }

    public bool IsVisible { get; set; }
}