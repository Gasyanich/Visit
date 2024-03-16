namespace Visit.Domain;

/// <summary>
///     Сущность, которая может быть включена/отключена для отображения в UI и в поиске
/// </summary>
public interface IVisibleEntity
{
    /// <summary>
    ///     Видимость сущности
    /// </summary>
    bool IsVisible { get; set; }
}