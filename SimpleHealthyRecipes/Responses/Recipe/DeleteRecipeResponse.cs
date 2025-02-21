using SimpleHealthyRecipes.Responses.Base;

namespace SimpleHealthyRecipes.Responses.Recipe;

public record DeleteRecipeResponse(string Message, bool Success)
    : BaseResponse(Message, Success);