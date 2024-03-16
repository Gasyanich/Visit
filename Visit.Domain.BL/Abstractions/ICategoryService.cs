using Visit.Contracts.Category;

namespace Visit.Domain.BL.Abstractions;

public interface ICategoryService
{
    Task<Category> CreateCategory(CreateCategoryDto dto);
}