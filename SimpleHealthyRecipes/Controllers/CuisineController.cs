using Microsoft.AspNetCore.Mvc;
using SimpleHealthyRecipes.Data;
using SimpleHealthyRecipes.Services.Interfaces;

namespace SimpleHealthyRecipes.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CuisineController : ControllerBase
{
    private readonly ICuisineService _cuisineService;

    public CuisineController(ICuisineService cuisineService)
    {
        _cuisineService = cuisineService;
    }

    // Отримання всіх кухонь
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var cuisines = await _cuisineService.GetAllCuisinesAsync();
        return Ok(cuisines);
    }

    // Отримання кухні за ID
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var cuisine = await _cuisineService.GetCuisineByIdAsync(id);
        if (cuisine == null) return NotFound();
        return Ok(cuisine);
    }
}