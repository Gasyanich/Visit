namespace Visit.Domain;

/// <summary>
///     Заведение
/// </summary>
public class Place : IVisibleEntity
{
    public int Id { get; set; }

    private Place()
    {
        
    }

    public Place(string name, string description, List<Category> categories, List<AttributeValue> attributeValues)
    {
        Name = name;
        Description = description;
        Categories = categories;
        AttributeValues = attributeValues;
    }

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