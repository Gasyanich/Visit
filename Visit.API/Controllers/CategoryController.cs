using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Visit.Contracts;
using Visit.Contracts.Category;
using Visit.Domain.BL.Abstractions;
using Visit.Domain.BL.DTO.Category;

// ReSharper disable SuggestBaseTypeForParameterInConstructor

namespace Visit.API.Controllers;

[ApiController]
[Route("api/categories")]
public class CategoryController(
    ICategoryService categoryService,
    IMapper mapper) : ControllerBase
{
    /// <summary>
    ///     Создать категорию
    /// </summary>
    [HttpPost]
    public async Task<ApiResponse<CategoryFullResponse>> Create(CreateCategoryRequest request)
    {
        var dto = mapper.Map<CreateCategoryDto>(request);

        var category = await categoryService.CreateCategory(dto);

        return ApiResponse.CreateSuccess(mapper.Map<CategoryFullResponse>(category));
    }
    
    /// <summary>
    ///     Обновить категорию
    /// </summary>
    [HttpPut]
    public async Task<ApiResponse<CategoryFullResponse>> Update(UpdateCategoryRequest request)
    {
        var dto = mapper.Map<UpdateCategoryDto>(request);

        var category = await categoryService.UpdateCategory(dto);

        return ApiResponse.CreateSuccess(mapper.Map<CategoryFullResponse>(category));
    }

    /// <summary>
    ///     Получить список всех категорий
    /// </summary>
    [HttpGet]
    public async Task<ApiResponse<IEnumerable<CategoryResponse>>> GetAll()
    {
        var categories = await categoryService.GetAllCategories();

        return ApiResponse.CreateSuccess(mapper.Map<IEnumerable<CategoryResponse>>(categories));
    }

    /// <summary>
    ///     Получить подробную информацию о категории
    /// </summary>
    [HttpGet("{id}")]
    public async Task<ApiResponse<CategoryFullResponse>> GetById(int id)
    {
        var category = await categoryService.GetCategoryById(id);

        if (category is null)
            return ApiResponse.CreateFailure<CategoryFullResponse>(400, "Категория не найдена");

        var response = mapper.Map<CategoryFullResponse>(category);

        return ApiResponse.CreateSuccess(response);
    }

    /// <summary>
    ///     Удалить категорию
    /// </summary>
    [HttpDelete("{id}")]
    public async Task<ApiResponse> Delete(int id)
    {
        await categoryService.DeleteCategoryById(id);

        return ApiResponse.CreateSuccess();
    }
}