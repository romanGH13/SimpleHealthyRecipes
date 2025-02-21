using SimpleHealthyRecipes.DTOs;
using SimpleHealthyRecipes.Responses.Base;

namespace SimpleHealthyRecipes.Responses.Recipe;

public record RecipeResponse(string Message, bool Success, RecipeDTO? Data)
    : BaseDataResponse<RecipeDTO>(Message, Success, Data);