using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Visit.Contracts;
using Visit.Contracts.Category.Create;
using Visit.Contracts.Category.GetAll;
using Visit.Contracts.Category.GetById;
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
    public async Task<ApiResponse<CreateCategoryResponse>> Create(CreateCategoryRequest request)
    {
        var dto = mapper.Map<CreateCategoryDto>(request);

        var category = await categoryService.CreateCategory(dto);

        return ApiResponse.CreateSuccess(mapper.Map<CreateCategoryResponse>(category));
    }

    /// <summary>
    ///     Получить список всех категорий
    /// </summary>
    [HttpGet]
    public async Task<ApiResponse<IEnumerable<GetAllCategoriesResponse>>> GetAll()
    {
        var categories = await categoryService.GetAllCategories();

        return ApiResponse.CreateSuccess(mapper.Map<IEnumerable<GetAllCategoriesResponse>>(categories));
    }

    /// <summary>
    ///     Получить подробную информацию о категории
    /// </summary>
    [HttpGet("{id}")]
    public async Task<ApiResponse<GetCategoryByIdResponse>> GetById(long id)
    {
        var category = await categoryService.GetCategoryById(id);

        if (category is null)
            return ApiResponse.CreateFailure<GetCategoryByIdResponse>(400, "Категория не найдена");

        var response = mapper.Map<GetCategoryByIdResponse>(category);

        return ApiResponse.CreateSuccess(response);
    }

    /// <summary>
    ///     Удалить категорию
    /// </summary>
    [HttpDelete("{id}")]
    public async Task<ApiResponse> Delete(long id)
    {
        await categoryService.DeleteCategoryById(id);

        return ApiResponse.CreateSuccess();
    }
}