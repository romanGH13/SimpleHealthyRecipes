using SimpleHealthyRecipes.Models;
using SimpleHealthyRecipes.Repositories.Base;
using SimpleHealthyRecipes.Requests.Recipe;

namespace SimpleHealthyRecipes.Repositories.Interfaces;

public interface IRecipeRepository : IBaseRepository<RecipeModel>
{
    Task<RecipeModel?> GetByIdWithDetailsAsync(int id);
    Task<List<RecipeModel>> GetFilteredRecipesAsync(GetRecipesRequest request);
}
