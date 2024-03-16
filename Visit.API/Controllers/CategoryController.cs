using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Visit.Contracts;
using Visit.Contracts.Category;
using Visit.Domain.BL.Abstractions;
// ReSharper disable SuggestBaseTypeForParameterInConstructor

namespace Visit.API.Controllers;

[ApiController]
[Route("api/categories")]
public class CategoryController(
    ICategoryService categoryService,
    IMapper mapper) : ControllerBase
{
    [HttpPost]
    public async Task<ApiResponse<CreateCategoryResultDto>> CreateCategory(CreateCategoryDto request)
    {
        var category = await categoryService.CreateCategory(request);

        return ApiResponse.CreateSuccess(mapper.Map<CreateCategoryResultDto>(category));
    }
}