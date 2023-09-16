using Domain.Dtos.CategoryDto;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace QuoteApi.Controllers;

[ApiController]
[Route("[controller]")]

public class CategoryController
{
    private CategoryService _categoryService;

    public CategoryController()
    {
        _categoryService = new CategoryService();
    }

    [HttpPost("CreateCategory")]
    public string CreateCategory(AUCategoryDto category)
    {
        return _categoryService.AddCategory(category);
    }

    [HttpGet("GetAllCategories")]
    public List<GCategoryDto> GetAllCategories()
    {
        return _categoryService.GetAllCategories();
    }

    [HttpGet("GetCategoryById")]
    public GCategoryDto GetCategoryById(int id)
    {
        return _categoryService.GetCategoryById(id);
    }

    [HttpGet("GetAllCategoriesWithNumberOfQuotes")]
    public List<GetAllCategoriesWithNumberOfQuotesDto> GetAllCategoriesWithNumberOfQuotesategory()
    {
        return _categoryService.GetAllCategoriesWithNumberOfQuotes();
    }

    [HttpGet("GetCategoriesWithListOfQuotes")]
    public List<GetCategoriesWithListOfQuotesDto> GetCategoriesWithListOfQuotesategory() 
    {
        return _categoryService.GetCategoriesWithListOfQuotes();
    }

    [HttpPut("UpdateCategory")]
    public string UpdateCategory(AUCategoryDto category)
    {
        return _categoryService.UpdateCategory(category);
    }

    [HttpDelete("DeleteCategory")]
    public string DeleteCategory(int id)
    {
        return _categoryService.DeleteCategory(id);
    }
}
