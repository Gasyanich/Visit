namespace Visit.Domain;

/// <summary>
///     Заведение
/// </summary>
public class Place : IVisibleEntity
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
    ///     Ссылка на категории, к которым принадлежит заведение
    /// </summary>
    public List<Category> Categories { get; set; }

    /// <summary>
    ///     Значения атрибутов для заведения
    /// </summary>
    public List<AttributeValue> AttributeValues { get; set; }

    public bool IsVisible { get; set; }
}