namespace Visit.Domain;

/// <summary>
///     Категория заведения
///     <example>Кафе, ресторан, фастфуд, тайм-кафе</example>
/// </summary>
public class Category : IVisibleEntity
{
    public Category()
    {
    }

    
    public Category(int id, string name, List<Attribute> attributes = null)
    {
        Id = id;
        Name = name;
        Attributes = attributes?.ToList();
    }
    
    public Category(string name, List<Attribute> attributes = null)
    {
        Name = name;
        Places = new List<Place>();
        Attributes = attributes?.ToList();
    }

    public int Id { get; set; }

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
    public List<CategoryAttribute> CategoryAttributes { get; set; }

    public bool IsVisible { get; set; }
}