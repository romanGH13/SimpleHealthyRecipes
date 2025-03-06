using Microsoft.EntityFrameworkCore;
using SimpleHealthyRecipes.Data;
using SimpleHealthyRecipes.Models;
using SimpleHealthyRecipes.Repositories.Base;
using SimpleHealthyRecipes.Repositories.Interfaces;

namespace SimpleHealthyRecipes.Repositories;

public class IngredientRepository : BaseRepository<IngredientModel>, IIngredientRepository
{
    public IngredientRepository(AppDbContext context) : base(context) { }


    public async Task<List<IngredientModel>> GetAllIngredientsAsync()
    {
        return await _context.Ingredients.ToListAsync();
    }

    public async Task<List<IngredientModel>> GetByNamesAsync(List<string> names)
    {
        return await _context.Ingredients
            .Where(i => names.Contains(i.Name))
            .ToListAsync();
    }

}