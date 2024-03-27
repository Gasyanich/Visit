namespace Visit.Contracts.Category.Create;

public class CreateCategoryResponse
{
    /// <summary>
    ///     Id категории
    /// </summary>
    public long Id { get; set; }

    /// <summary>
    ///     Наименование категории
    /// </summary>
    public string Name { get; set; }
}