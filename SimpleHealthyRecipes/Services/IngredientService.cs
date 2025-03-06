using AutoMapper;
using SimpleHealthyRecipes.DTOs;
using SimpleHealthyRecipes.Repositories.Interfaces;
using SimpleHealthyRecipes.Services.Interfaces;

namespace SimpleHealthyRecipes.Services;

public class IngredientService(IIngredientRepository ingredientRepository, IMapper mapper) : IIngredientService
{
    private readonly IIngredientRepository _ingredientRepository = ingredientRepository;

    public async Task<List<IngredientDTO>> GetAllIngredientsAsync()
    {
        var ingredients = await _ingredientRepository.GetAllIngredientsAsync();
        return mapper.Map<List<IngredientDTO>>(ingredients);
    }

}