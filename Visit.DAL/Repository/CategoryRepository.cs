using Microsoft.EntityFrameworkCore;
using Visit.Domain;
using Visit.Domain.BL.Abstractions.Repository;

namespace Visit.DAL.Repository;

public class CategoryRepository(DataContext dataContext) : ICategoryRepository
{
    public async Task<bool> IsExistByName(string name)
    {
        return await dataContext.Categories.AnyAsync(c => c.Name == name);
    }

    public async Task<Category> Create(Category category)
    {
        if (category.Attributes != null)
            dataContext.Attributes.AttachRange(category.Attributes);

        dataContext.Categories.Add(category);

        await dataContext.SaveChangesAsync();

        return category;
    }

    public async Task Update(Category category)
    {
        var t = await dataContext.Database.BeginTransactionAsync();

        if (category.Attributes != null)
        {
            dataContext.AttachRange(category.Attributes);

            await dataContext.CategoryAttributes
                .Where(ca => ca.CategoryId == category.Id)
                .ExecuteDeleteAsync();

            dataContext.CategoryAttributes.AddRange(category.CategoryAttributes);
        }

        dataContext.Categories.Update(category);

        await dataContext.SaveChangesAsync();
        
        await t.CommitAsync();
    }

    public async Task<Category> GetById(int id)
    {
        return await dataContext.Categories
            .Include(c => c.Attributes)
            .AsNoTracking()
            .FirstOrDefaultAsync(c => c.Id == id);
    }

    public async Task<IEnumerable<Category>> GetByIds(IEnumerable<int> ids)
    {
        return await dataContext.Categories
            .Include(c => c.Attributes)
            .AsNoTracking()
            .Where(c => ids.Contains(c.Id))
            .ToListAsync();
    }

    public async Task<List<Category>> GetAll()
    {
        return await dataContext.Categories
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task Delete(int id)
    {
        await dataContext.Categories.Where(c => c.Id == id).ExecuteDeleteAsync();
    }
}