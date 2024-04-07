using AutoMapper;
using Visit.Domain.BL.Abstractions;
using Visit.Domain.BL.Abstractions.Repository;
using Visit.Domain.BL.DTO.Category;

namespace Visit.Domain.BL;

public class CategoryService(ICategoryRepository categoryRepository, IMapper mapper) : ICategoryService
{
    public async Task<Category> CreateCategory(CreateCategoryDto dto)
    {
        var checkNameUnique = await categoryRepository.IsExistByName(dto.Name);
        if (checkNameUnique)
            throw new Exception("Категория с таким названием уже существует");

        var category = mapper.Map<Category>(dto);

        await categoryRepository.Create(category);

        return await GetCategoryById(category.Id);
    }

    public async Task<Category> UpdateCategory(UpdateCategoryDto dto)
    {
        var category = mapper.Map<Category>(dto);

        await categoryRepository.Update(category);

        return await GetCategoryById(category.Id);
    }


    public async Task<IEnumerable<Category>> GetAllCategories()
    {
        return await categoryRepository.GetAll();
    }

    public async Task<Category> GetCategoryById(int id)
    {
        return await categoryRepository.GetById(id);
    }

    public async Task DeleteCategoryById(int id)
    {
        await categoryRepository.Delete(id);
    }
}