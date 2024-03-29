﻿namespace Visit.Contracts.Attribute.GetById;

public class GetAttributeByIdResponse
{
    /// <summary>
    ///     Id атрибута
    /// </summary>
    public long Id { get; set; }

    /// <summary>
    ///     Название атрибута
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    ///     Может ли атрибут использоваться в фильтрах
    /// </summary>
    public bool CanUseInFilter { get; set; }

    /// <summary>
    ///     Порядок отображения атрибута
    /// </summary>
    public int Order { get; set; }

    /// <summary>
    ///     Допустимо ли использовать несколько значений атрибута
    /// </summary>
    public bool AllowMultipleValues { get; set; }

    /// <summary>
    ///     Определенные заранее значения для атрибута
    ///     <example>Вид кухни: итальянская, греческая, грузинская..</example>
    ///     <example>Способ оплаты: картой, наличными, переводом</example>
    /// </summary>
    public List<object> PredefinedValues { get; set; }

    /// <summary>
    ///     Тип значения атрибута
    /// </summary>
    public AttributeType Type { get; set; }

    /// <summary>
    ///     Тип контрола атрибута
    /// </summary>
    public AttributeControlType ControlType { get; set; }

    /// <summary>
    ///     Список категорий, к которым принадледит атрибут
    /// </summary>
    public IEnumerable<GetAttributeCategoryModel> Categories { get; set; }
}

public class GetAttributeCategoryModel
{
    /// <summary>
    ///     Id категории
    /// </summary>
    public long Id { get; set; }

    /// <summary>
    ///     Название категории
    /// </summary>
    public string Name { get; set; }
}