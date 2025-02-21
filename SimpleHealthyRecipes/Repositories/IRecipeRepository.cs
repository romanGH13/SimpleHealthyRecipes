using SimpleHealthyRecipes.Models;
using SimpleHealthyRecipes.Repositories.Base;

namespace SimpleHealthyRecipes.Repositories;

public interface IRecipeRepository : IBaseRepository<Recipe>
{
    Task<List<Recipe>> GetAllWithDetailsAsync();
    Task<Recipe?> GetByIdWithDetailsAsync(int id);
}
