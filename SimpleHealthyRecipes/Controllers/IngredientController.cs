using Microsoft.AspNetCore.Mvc;
using SimpleHealthyRecipes.Services.Interfaces;

namespace SimpleHealthyRecipes.Controllers;

[ApiController]
[Route("api/[controller]")]
public class IngredientController : ControllerBase
{
    private readonly IIngredientService _ingredientService;

    public IngredientController(IIngredientService ingredientService)
    {
        _ingredientService = ingredientService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var tags = await _ingredientService.GetAllIngredientsAsync();
        return Ok(tags);
    }

}