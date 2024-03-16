namespace Visit.Contracts.Category;

public class CreateCategoryResultDto
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