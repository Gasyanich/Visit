using Microsoft.EntityFrameworkCore;
using Visit.DAL;
using Visit.Domain.BL.Abstractions;
using Visit.Domain.BL.DTO.Category;

namespace Visit.Domain.BL;

public class CategoryService(DataContext dataContext) : ICategoryService
{
    public async Task<Category> CreateCategory(CreateCategoryDto dto)
    {
        var checkNameUnique = await dataContext.Categories.AnyAsync(c => c.Name == dto.Name);
        if (checkNameUnique)
            throw new Exception("Категория с таким названием уже существует");

        var category = new Category(dto.Name);

        dataContext.Categories.Add(category);
        await dataContext.SaveChangesAsync();

        return category;
    }

    public async Task<IEnumerable<Category>> GetAllCategories()
    {
        return await dataContext.Categories
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task<Category?> GetCategoryById(long id)
    {
        return await dataContext.Categories
            .Include(c => c.Attributes)
            .AsNoTracking()
            .FirstOrDefaultAsync(c => c.Id == id);
    }

    public async Task DeleteCategoryById(long id)
    {
        await dataContext.Categories.Where(c => c.Id == id).ExecuteDeleteAsync();
    }
}