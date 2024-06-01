using Microsoft.Extensions.Caching.Memory;
using Visit.Domain.BL.Abstractions.Repository;

namespace Visit.DAL.Repository;

public class MemoryCacheRepository<T>(IMemoryCache memoryCache) : IMemoryCacheRepository<T>
{
    public void SetCache<TKey>(TKey key, T value)
    {
         memoryCache.Set(key, value);
    }
    public T? GetByKey<TKey>(TKey key)
    {
        return memoryCache.TryGetValue(key, out T value) ? value : default;
    }
    public void RemoveFromCache<TKey>(TKey key)
    {
        memoryCache.Remove(key);
    }
}
