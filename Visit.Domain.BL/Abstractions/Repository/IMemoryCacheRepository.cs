namespace Visit.Domain.BL.Abstractions.Repository;

public interface IMemoryCacheRepository<T>
{
    void SetCache<TKey>(TKey id, T value);
    T? GetByKey<TKey>(TKey key);
    void RemoveFromCache<TKey>(TKey key);
}
