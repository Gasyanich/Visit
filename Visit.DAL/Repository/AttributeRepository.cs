using Microsoft.EntityFrameworkCore;
using Visit.Domain.BL.Abstractions.Repository;
using Attribute = Visit.Domain.Attribute;

namespace Visit.DAL.Repository;

public class AttributeRepository(DataContext dataContext, IMemoryCacheRepository<Attribute> memoryCache) : IAttributeRepository
{

    public async Task<bool> IsExistByName(string name) => 
        memoryCache.GetByKey(name) != null || await dataContext.Attributes.AnyAsync(c => c.Name == name);

    public async Task<Attribute> Create(Attribute attribute)
    {
        dataContext.Attributes.Add(attribute);

        await dataContext.SaveChangesAsync();

        return attribute;
    }
    
    public async Task<Attribute> Update(Attribute attribute)
    {
        dataContext.Attributes.Update(attribute);

        await dataContext.SaveChangesAsync();

        return attribute;
    }


    public async Task<Attribute> GetById(int id)
    {
        return await dataContext.Attributes
            .Include(c => c.Categories)
            .AsNoTracking()
            .FirstOrDefaultAsync(c => c.Id == id);
    }

    public async Task<List<Attribute>> GetAll()
    {
        return await dataContext.Attributes
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task Delete(int id)
    {
        await dataContext.Attributes.Where(c => c.Id == id).ExecuteDeleteAsync();
    }
}