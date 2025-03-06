using SimpleHealthyRecipes.DTOs;

namespace SimpleHealthyRecipes.Services.Interfaces;
public interface IIngredientService
{
    Task<List<IngredientDTO>> GetAllIngredientsAsync();
}