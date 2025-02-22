using SimpleHealthyRecipes.Enums;
using SimpleHealthyRecipes.Requests.Base;
using SimpleHealthyRecipes.Requests.Ingredient;
using System.ComponentModel.DataAnnotations;

namespace SimpleHealthyRecipes.Requests.Recipe;

public record UpdateRecipeRequest(
    [Required] int Id,
    [Required] string Title,
    string Description,
    int PrepTimeMinutes,
    int CookTimeMinutes,
    int Servings,
    int? CuisineId,
    DifficultyLevel Difficulty,
    List<CreateIngredientRequest> Ingredients,
    List<CreateRecipeStepRequest> Steps,
    List<string> Tags
) : BaseRequest;