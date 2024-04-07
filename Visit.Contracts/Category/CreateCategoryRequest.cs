namespace Visit.Contracts.Category;

public class CreateCategoryRequest
{
    /// <summary>
    ///     Наименование категории
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    ///     Id атрибутов категории
    /// </summary>
    public IEnumerable<int> AttributeIds { get; set; }
}