using Visit.Contracts.Attribute;

namespace Visit.Contracts.Category;

public class CategoryFullResponse
{
    /// <summary>
    ///     Id категории
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    ///     Название категории
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    ///     Список атрибутов категории
    /// </summary>
    public IEnumerable<AttributeResponse> Attributes { get; set; }
}