using SimpleHealthyRecipes.Requests.Base;
using SimpleHealthyRecipes.Requests.Ingredient;
using System.ComponentModel.DataAnnotations;

namespace SimpleHealthyRecipes.Requests.Recipe;

public record CreateRecipeRequest(
    [Required] string Title,
    string Description,
    [Range(0, int.MaxValue, ErrorMessage = "Preparation time cannot be negative")] int PrepTimeMinutes,
    [Range(0, int.MaxValue, ErrorMessage = "Cooking time cannot be negative")] int CookTimeMinutes,
    [Range(1, int.MaxValue, ErrorMessage = "Servings must be at least 1")] int Servings,
    bool IsVegetarian,
    [MinLength(1, ErrorMessage = "Recipe must have at least one ingredient")] List<CreateIngredientRequest> Ingredients
) : BaseRequest;