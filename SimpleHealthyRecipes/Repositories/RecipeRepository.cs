using Microsoft.EntityFrameworkCore;
using SimpleHealthyRecipes.Data;
using SimpleHealthyRecipes.Models;
using SimpleHealthyRecipes.Repositories.Base;

namespace SimpleHealthyRecipes.Repositories;

public class RecipeRepository : BaseRepository<Recipe>, IRecipeRepository
{
    public RecipeRepository(AppDbContext context) : base(context) { }

    public async Task<List<Recipe>> GetAllWithDetailsAsync()
    {
        return await _dbSet
            .Include(r => r.Ingredients)
            .Include(r => r.Tags)
            .Include(r => r.Ratings)
            .ToListAsync();
    }

    public async Task<Recipe?> GetByIdWithDetailsAsync(int id)
    {
        return await _dbSet
            .Include(r => r.Ingredients)
            .Include(r => r.Tags)
            .Include(r => r.Ratings)
            .FirstOrDefaultAsync(r => r.Id == id);
    }
}
