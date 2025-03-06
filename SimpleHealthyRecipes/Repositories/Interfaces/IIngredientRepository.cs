using SimpleHealthyRecipes.Models;
using SimpleHealthyRecipes.Repositories.Base;

namespace SimpleHealthyRecipes.Repositories.Interfaces;

public interface IIngredientRepository : IBaseRepository<IngredientModel>
{
    Task<List<IngredientModel>> GetAllIngredientsAsync();
    Task<List<IngredientModel>> GetByNamesAsync(List<string> names);
}