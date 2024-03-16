using Microsoft.EntityFrameworkCore;
using Visit.Contracts.Category;
using Visit.DAL;
using Visit.Domain.BL.Abstractions;

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
}