using SimpleHealthyRecipes.Requests.Base;

namespace SimpleHealthyRecipes.Requests.Recipe;

public record DeleteRecipeRequest(int Id) : BaseDeleteRequest(Id);