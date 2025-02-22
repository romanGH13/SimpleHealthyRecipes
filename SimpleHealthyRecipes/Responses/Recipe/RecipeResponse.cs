using SimpleHealthyRecipes.DTOs;
using SimpleHealthyRecipes.Responses.Base;

namespace SimpleHealthyRecipes.Responses.Recipe;

public record RecipeResponse(string Message, bool Success, DetailedRecipeDTO? Data)
    : BaseDataResponse<DetailedRecipeDTO>(Message, Success, Data);