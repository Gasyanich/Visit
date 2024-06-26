﻿namespace Visit.Domain.BL.DTO.Category;

public class CreateCategoryDto
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