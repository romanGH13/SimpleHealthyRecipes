using Microsoft.AspNetCore.Mvc;
using SimpleHealthyRecipes.Requests.Recipe;
using SimpleHealthyRecipes.Responses.Recipe;
using SimpleHealthyRecipes.Services.Interfaces;

namespace SimpleHealthyRecipes.Controllers;

[Route("api/[controller]")]
[ApiController]
public class RecipeController(IRecipeService recipeService) : ControllerBase
{

    /// <summary>
    /// Отримати список рецептів (з підтримкою фільтрації, пошуку та пагінації)
    /// </summary>
    [HttpGet]
    public async Task<IActionResult> GetAll([FromQuery] GetRecipesRequest request)
    {
        var response = await recipeService.GetAllAsync(request);
        return Ok(response);
    }

    /// <summary>
    /// Отримати рецепт за ідентифікатором
    /// </summary>
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        var response = await recipeService.GetByIdAsync(new GetRecipeByIdRequest(id));
        var dataResponse = new RecipeResponse("", true, response);
        return response != null ? Ok(dataResponse) : NotFound(dataResponse);
    }

    /// <summary>
    /// Створити новий рецепт
    /// </summary>
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateRecipeRequest request)
    {
        var response = await recipeService.CreateAsync(request);
        return response.Success ? CreatedAtAction(nameof(GetById), new { id = response.Id }, response) : BadRequest(response);
    }

    /// <summary>
    /// Оновити існуючий рецепт
    /// </summary>
    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateRecipeRequest request)
    {
        var response = await recipeService.UpdateAsync(request);
        return response != null ? Ok(response) : NotFound(response);
    }

    /// <summary>
    /// Видалити рецепт за ідентифікатором
    /// </summary>
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        var response = await recipeService.DeleteAsync(new DeleteRecipeRequest(id));
        return response.Success ? Ok(response) : NotFound(response);
    }
}
