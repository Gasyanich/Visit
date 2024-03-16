namespace Visit.Domain;

/// <summary>
///     Категория заведения
///     <example>Кафе, ресторан, фастфуд, тайм-кафе</example>
/// </summary>
public class Category : IVisibleEntity
{
    private Category()
    {
    }

    public Category(string name)
    {
        Name = name;
        Places = new List<Place>();
        Attributes = new List<Attribute>();
    }

    public long Id { get; set; }

    /// <summary>
    ///     Название категории
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    ///     Ссылка на заведения, которые принадлежат к категории
    /// </summary>
    public List<Place> Places { get; set; }

    /// <summary>
    ///     Ссылка на атрибуты категории
    /// </summary>
    public List<Attribute> Attributes { get; set; }

    public bool IsVisible { get; set; }
}