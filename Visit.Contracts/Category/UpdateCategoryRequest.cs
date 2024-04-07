﻿namespace Visit.Contracts.Category;

public class UpdateCategoryRequest
{
    /// <summary>
    ///     Id обновляемое категории
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    ///     Наименование категории
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    ///     Id атрибутов категории
    /// </summary>
    public IEnumerable<int> AttributeIds { get; set; }
}