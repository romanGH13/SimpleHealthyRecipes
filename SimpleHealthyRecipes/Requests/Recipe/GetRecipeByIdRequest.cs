using SimpleHealthyRecipes.Requests.Base;

namespace SimpleHealthyRecipes.Requests.Recipe;

public record GetRecipeByIdRequest(int Id) : BaseGetByIdRequest(Id);