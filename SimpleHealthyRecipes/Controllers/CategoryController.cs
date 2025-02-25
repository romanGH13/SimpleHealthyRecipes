using Microsoft.AspNetCore.Mvc;
using SimpleHealthyRecipes.Services.Interfaces;

namespace SimpleHealthyRecipes.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CategoryController(ICategoryService categoryService) : ControllerBase
{
    private readonly ICategoryService _categoryService = categoryService;

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var categories = await _categoryService.GetAllCategoriesAsync();
        return Ok(categories);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var category = await _categoryService.GetCategoryByIdAsync(id);
        if (category == null) return NotFound();
        return Ok(category);
    }
}