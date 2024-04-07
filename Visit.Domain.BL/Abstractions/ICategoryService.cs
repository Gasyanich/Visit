using Visit.Domain.BL.DTO.Category;

namespace Visit.Domain.BL.Abstractions;

public interface ICategoryService
{
    Task<Category> CreateCategory(CreateCategoryDto dto);
    Task<IEnumerable<Category>> GetAllCategories();
    Task<Category?> GetCategoryById(int id);
    Task DeleteCategoryById(int id);
    Task<Category> UpdateCategory(UpdateCategoryDto dto);
}