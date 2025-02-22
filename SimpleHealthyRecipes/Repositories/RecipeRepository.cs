using Microsoft.EntityFrameworkCore;
using SimpleHealthyRecipes.Data;
using SimpleHealthyRecipes.Models;
using SimpleHealthyRecipes.Repositories.Base;
using SimpleHealthyRecipes.Requests.Recipe;

namespace SimpleHealthyRecipes.Repositories;

public class RecipeRepository : BaseRepository<RecipeModel>, IRecipeRepository
{
    public RecipeRepository(AppDbContext context) : base(context) { }

    public async Task<RecipeModel?> GetByIdWithDetailsAsync(int id)
    {
        return await _dbSet
            .Include(r => r.Ingredients)
            .Include(r => r.Tags)
            .Include(r => r.Ratings)
            .Include(r => r.Steps)
            .Include(r => r.Cuisine)
            .Include(r => r.MovieReference)
            .FirstOrDefaultAsync(r => r.Id == id);
    }

    public async Task<List<RecipeModel>> GetFilteredRecipesAsync(GetRecipesRequest request)
    {
        var query = _dbSet.AsQueryable();

        if (!string.IsNullOrWhiteSpace(request.SearchTerm))
            query = query.Where(r => r.Title.Contains(request.SearchTerm));

        if (request.Tags != null && request.Tags.Any())
        {
            query = query.Where(r => request.Tags.All(tag => r.Tags.Select(t => t.Name).Contains(tag)));
        }

        if (request.MinPrepTime.HasValue)
            query = query.Where(r => r.PrepTimeMinutes >= request.MinPrepTime);

        if (request.MaxPrepTime.HasValue)
            query = query.Where(r => r.PrepTimeMinutes <= request.MaxPrepTime);

        if (request.MinCookTime.HasValue)
            query = query.Where(r => r.CookTimeMinutes >= request.MinCookTime);

        if (request.MaxCookTime.HasValue)
            query = query.Where(r => r.CookTimeMinutes <= request.MaxCookTime);

        if (request.MinServings.HasValue)
            query = query.Where(r => r.Servings >= request.MinServings);

        if (request.MaxServings.HasValue)
            query = query.Where(r => r.Servings <= request.MaxServings);

        if (request.Difficulty.HasValue)
            query = query.Where(r => r.Difficulty == request.Difficulty);

        if (request.CuisineId.HasValue)
            query = query.Where(r => r.CuisineId == request.CuisineId);

        return await query.Skip((request.Page - 1) * request.PageSize)
                          .Take(request.PageSize)
                          .ToListAsync();
    }
}
