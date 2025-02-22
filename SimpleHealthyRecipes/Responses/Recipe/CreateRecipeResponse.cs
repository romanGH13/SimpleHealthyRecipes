using SimpleHealthyRecipes.DTOs;
using SimpleHealthyRecipes.Responses.Base;

namespace SimpleHealthyRecipes.Responses.Recipe;

public record CreateRecipeResponse(string Message, bool Success, int Id)
    : BaseCreateResponse<int>(Message, Success, Id);